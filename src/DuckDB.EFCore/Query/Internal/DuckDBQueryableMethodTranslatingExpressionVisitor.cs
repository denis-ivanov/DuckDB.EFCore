using DuckDB.EFCore.Extensions.Internal;
using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;
    private RelationalTypeMapping? _ordinalityTypeMapping;
    
    public DuckDBQueryableMethodTranslatingExpressionVisitor(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
        RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
        RelationalQueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)relationalDependencies.SqlExpressionFactory;
    }
    
    protected override ShapedQueryExpression? TranslateElementAtOrDefault(
        ShapedQueryExpression source,
        Expression index,
        bool returnDefault)
    {
        if (!returnDefault && TranslateExpression(index) is { } translatedIndex)
        {
            switch (source)
            {
                case var _ when source.TryExtractArray(out var array, out var projectedColumn):
                {
                    return source.UpdateQueryExpression(
                        new SelectExpression(
                            _sqlExpressionFactory.ArrayIndex(
                                array,
                                GenerateOneBasedIndexExpression(translatedIndex), projectedColumn.IsNullable),
                            ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager));
                }

                case var _ when source.TryExtractJsonArray(out var jsonArray, out var projectedElement, out var isElementNullable):
                {
                    var (json, path) = jsonArray is JsonScalarExpression innerJsonScalarExpression
                        ? (innerJsonScalarExpression.Json, innerJsonScalarExpression.Path.Append(new(translatedIndex)).ToArray())
                        : (jsonArray, [new(translatedIndex)]);

                    var translation = new JsonScalarExpression(
                        json,
                        path,
                        projectedElement.Type,
                        projectedElement.TypeMapping,
                        isElementNullable);

                    return source.UpdateQueryExpression(new SelectExpression(translation, ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager));
                }
            }
        }

        return base.TranslateElementAtOrDefault(source, index, returnDefault);
    }

    protected override ShapedQueryExpression? TranslateTake(ShapedQueryExpression source, Expression count)
    {
        if (source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(count) is { } translatedCount)
        {
            DuckDBArraySliceExpression sliceExpression;

            if (array is DuckDBArraySliceExpression existingSliceExpression)
            {
                if (existingSliceExpression is
                    {
                        LowerBound: SqlConstantExpression { Value: int lowerBoundValue } lowerBound,
                        UpperBound: null
                    })
                {
                    sliceExpression = existingSliceExpression.Update(
                        existingSliceExpression.Array,
                        existingSliceExpression.LowerBound,
                        translatedCount is SqlConstantExpression { Value: int takeCount }
                            ? _sqlExpressionFactory.Constant(lowerBoundValue + takeCount - 1, lowerBound.TypeMapping)
                            : _sqlExpressionFactory.Subtract(
                                _sqlExpressionFactory.Add(lowerBound, translatedCount),
                                _sqlExpressionFactory.Constant(1, lowerBound.TypeMapping)));
                }
                else
                {
                    return base.TranslateTake(source, count);
                }
            }
            else
            {
                sliceExpression = _sqlExpressionFactory.ArraySlice(
                    array,
                    lowerBound: null,
                    upperBound: translatedCount,
                    projectedColumn.IsNullable);
            }

#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [new DuckDBUnnestExpression(tableAlias, sliceExpression, "value")],
                new ColumnExpression("value", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                [GenerateOrdinalityIdentifier(tableAlias)],
                ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager);
#pragma warning restore EF1001 // Internal EF Core API usage.

            Expression shaperExpression = new ProjectionBindingExpression(
                selectExpression, new ProjectionMember(), source.ShaperExpression.Type.MakeNullable());

            if (source.ShaperExpression.Type != shaperExpression.Type)
            {
                Debug.Assert(
                    source.ShaperExpression.Type.MakeNullable() == shaperExpression.Type,
                    "expression.Type must be nullable of targetType");

                shaperExpression = Expression.Convert(shaperExpression, source.ShaperExpression.Type);
            }

            return new ShapedQueryExpression(selectExpression, shaperExpression);
        }
        
        return base.TranslateTake(source, count);
    }

    private (ColumnExpression, ValueComparer) GenerateOrdinalityIdentifier(string tableAlias)
    {
        _ordinalityTypeMapping ??= RelationalDependencies.TypeMappingSource.FindMapping("INT")!;
        return (new ColumnExpression("ordinality", tableAlias, typeof(int), _ordinalityTypeMapping, nullable: false),
            _ordinalityTypeMapping.Comparer);
    }

    private SqlExpression GenerateOneBasedIndexExpression(SqlExpression expression)
        => expression is SqlConstantExpression constant
            ? _sqlExpressionFactory.Constant(Convert.ToInt32(constant.Value) + 1, constant.TypeMapping)
            : _sqlExpressionFactory.Add(expression, _sqlExpressionFactory.Constant(1));
}
