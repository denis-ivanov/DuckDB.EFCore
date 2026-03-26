using DuckDB.EFCore.Extensions.Internal;
using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    private readonly RelationalQueryCompilationContext _queryCompilationContext;
    private readonly DuckDBTypeMappingSource _typeMappingSource;
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;
    private RelationalTypeMapping? _ordinalityTypeMapping;

    public DuckDBQueryableMethodTranslatingExpressionVisitor(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
        RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
        RelationalQueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
        _queryCompilationContext = queryCompilationContext;
        _typeMappingSource = (DuckDBTypeMappingSource)relationalDependencies.TypeMappingSource;
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)relationalDependencies.SqlExpressionFactory;
    }

    protected DuckDBQueryableMethodTranslatingExpressionVisitor(DuckDBQueryableMethodTranslatingExpressionVisitor parentVisitor)
        : base(parentVisitor)
    {
        _queryCompilationContext = parentVisitor._queryCompilationContext;
        _typeMappingSource = parentVisitor._typeMappingSource;
        _sqlExpressionFactory = parentVisitor._sqlExpressionFactory;
    }

    protected override QueryableMethodTranslatingExpressionVisitor CreateSubqueryVisitor()
    {
        return new DuckDBQueryableMethodTranslatingExpressionVisitor(this);
    }

    protected override ShapedQueryExpression? TranslatePrimitiveCollection(SqlExpression sqlExpression, IProperty? property, string tableAlias)
    {
        var elementClrType = sqlExpression.Type.GetSequenceType();
        var elementTypeMapping = (RelationalTypeMapping?)sqlExpression.TypeMapping?.ElementTypeMapping;

        var isElementNullable = property?.GetElementType() is null
            ? elementClrType.IsNullableType()
            : property.GetElementType()!.IsNullable;

        SelectExpression selectExpression;

#pragma warning disable EF1001 // SelectExpression constructors are pubternal
        switch (sqlExpression.TypeMapping)
        {
            case DuckDBArrayTypeMapping or null:
            {
                var (ordinalityColumn, ordinalityComparer) = GenerateOrdinalityIdentifier(tableAlias);
                selectExpression = new SelectExpression(
                    [new DuckDBUnnestExpression(tableAlias, sqlExpression, "unnest")],
                    new ColumnExpression(
                        "unnest",
                        tableAlias,
                        elementClrType.UnwrapNullableType(),
                        elementTypeMapping,
                        isElementNullable),
                    identifier: [(ordinalityColumn, ordinalityComparer)],
                    _queryCompilationContext.SqlAliasManager);

                selectExpression.AppendOrdering(new OrderingExpression(ordinalityColumn, ascending: true));
                break;
            }

            default:
                throw new UnreachableException();
        }
#pragma warning restore EF1001 // SelectExpression constructors are pubternal

        Expression shaperExpression = new ProjectionBindingExpression(
            selectExpression, new ProjectionMember(), elementClrType.MakeNullable());

        if (elementClrType != shaperExpression.Type)
        {
            Debug.Assert(
                elementClrType.MakeNullable() == shaperExpression.Type,
                "expression.Type must be nullable of targetType");

            shaperExpression = Expression.Convert(shaperExpression, elementClrType);
        }

        return new ShapedQueryExpression(selectExpression, shaperExpression);
    }

    protected override ShapedQueryExpression? TransformJsonQueryToTable(JsonQueryExpression jsonQueryExpression)
    {
        return base.TransformJsonQueryToTable(jsonQueryExpression);
    }

    protected override ShapedQueryExpression? TranslateAll(ShapedQueryExpression source, LambdaExpression predicate)
    {
        return base.TranslateAll(source, predicate);
    }

    protected override ShapedQueryExpression? TranslateAny(ShapedQueryExpression source, LambdaExpression? predicate)
    {
        if (source.QueryExpression is SelectExpression { Tables: [{ Alias: var tableAlias }] })
        {
            if (source.TryExtractArray(out var array, ignoreOrderings: true)
                || source.TryConvertToArray(out array, ignoreOrderings: true))
            {
                // Pattern match: x.Array.Any()
                // Translation: array_length(x.array) > 0 instead of EXISTS (SELECT 1 FROM FROM unnest(x.Array))
                if (predicate is null)
                {
                    return BuildSimplifiedShapedQuery(
                        source,
                        _sqlExpressionFactory.GreaterThan(
                            _sqlExpressionFactory.Function(
                                "array_length",
                                [array],
                                nullable: true,
                                argumentsPropagateNullability: [true],
                                typeof(int)),
                            _sqlExpressionFactory.Constant(0)));
                }
            }
        }

        return base.TranslateAny(source, predicate);
    }

    protected override ShapedQueryExpression TranslateConcat(ShapedQueryExpression source1, ShapedQueryExpression source2)
    {
        return base.TranslateConcat(source1, source2);
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
            }
        }

        return base.TranslateElementAtOrDefault(source, index, returnDefault);
    }

    protected override ShapedQueryExpression? TranslateSkip(ShapedQueryExpression source, Expression count)
    {
        if (source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(count) is { } translatedCount)
        {
#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [
                    new DuckDBUnnestExpression(
                        tableAlias,
                        _sqlExpressionFactory.ArraySlice(
                            array,
                            lowerBound: GenerateOneBasedIndexExpression(translatedCount),
                            upperBound: null,
                            projectedColumn.IsNullable),
                        "value"),
                ],
                new ColumnExpression("value", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                identifier: [GenerateOrdinalityIdentifier(tableAlias)],
                _queryCompilationContext.SqlAliasManager);
#pragma warning restore EF1001

            // TODO: Simplify by using UpdateQueryExpression after https://github.com/dotnet/efcore/issues/31511
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

        return base.TranslateSkip(source, count);
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
                [new DuckDBUnnestExpression(tableAlias, sliceExpression, "unnest")],
                new ColumnExpression("unnest", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
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

    protected override ShapedQueryExpression? TranslateWhere(ShapedQueryExpression source, LambdaExpression predicate)
    {
        // Simplify x.Array.Where(i => i != 3) => array_remove(x.Array, 3) instead of subquery
        if (predicate.Body is BinaryExpression
            {
                NodeType: ExpressionType.NotEqual,
                Left: var left,
                Right: var right
            }
            && (left == predicate.Parameters[0] ? right : right == predicate.Parameters[0] ? left : null) is Expression itemToFilterOut
            && source.TryExtractArray(out var array, out var projectedColumn)
            && TranslateExpression(itemToFilterOut) is SqlExpression translatedItemToFilterOut)
        {
            var simplifiedTranslation = _sqlExpressionFactory.Function(
                "array_remove",
                [array, translatedItemToFilterOut],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                array.Type,
                array.TypeMapping);

#pragma warning disable EF1001 // SelectExpression constructors are currently internal
            var tableAlias = ((SelectExpression)source.QueryExpression).Tables[0].Alias!;
            var selectExpression = new SelectExpression(
                [new DuckDBUnnestExpression(tableAlias, simplifiedTranslation, "unnest")],
                new ColumnExpression("unnest", tableAlias, projectedColumn.Type, projectedColumn.TypeMapping, projectedColumn.IsNullable),
                [GenerateOrdinalityIdentifier(tableAlias)],
                _queryCompilationContext.SqlAliasManager);
#pragma warning restore EF1001 // Internal EF Core API usage.

            // TODO: Simplify by using UpdateQueryExpression after https://github.com/dotnet/efcore/issues/31511
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

        return base.TranslateWhere(source, predicate);
    }

    protected override ShapedQueryExpression? TranslateCount(ShapedQueryExpression source, LambdaExpression? predicate)
    {
        // Simplify x.Array.Count() => array_length(x.Array) instead of SELECT COUNT(*) FROM unnest(x.Array)
        if (predicate is null)
        {
            switch (source)
            {
                case var _ when source.TryExtractArray(out var array, ignoreOrderings: true):
                {
                    var translation = _sqlExpressionFactory.Function(
                        "array_length",
                        [array],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        typeof(int));

#pragma warning disable EF1001 // SelectExpression constructors are currently internal
                    return source.Update(
                        new SelectExpression(translation, _queryCompilationContext.SqlAliasManager),
                        Expression.Convert(
                            new ProjectionBindingExpression(source.QueryExpression, new ProjectionMember(), typeof(int?)),
                            typeof(int)));
#pragma warning restore EF1001
                }
            }
        }

        return base.TranslateCount(source, predicate);
    }

    protected override bool IsNaturallyOrdered(SelectExpression selectExpression)
    {
        return selectExpression is { Tables: [DuckDBUnnestExpression unnest, ..] }
               && (selectExpression.Orderings is []
                   || selectExpression.Orderings is
                       [{ Expression: ColumnExpression { Name: "ordinality", TableAlias: var orderingTableAlias } }]
                   && orderingTableAlias == unnest.Alias);
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
    
#pragma warning disable EF1001 // SelectExpression constructors are currently internal
    private ShapedQueryExpression BuildSimplifiedShapedQuery(ShapedQueryExpression source, SqlExpression translation)
        => source.Update(
            new SelectExpression(translation, _queryCompilationContext.SqlAliasManager),
            Expression.Convert(
                new ProjectionBindingExpression(translation, new ProjectionMember(), typeof(bool?)), typeof(bool)));
#pragma warning restore EF1001
}
