using DuckDB.EFCore.Extensions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;
    
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
    
    private SqlExpression GenerateOneBasedIndexExpression(SqlExpression expression)
        => expression is SqlConstantExpression constant
            ? _sqlExpressionFactory.Constant(Convert.ToInt32(constant.Value) + 1, constant.TypeMapping)
            : _sqlExpressionFactory.Add(expression, _sqlExpressionFactory.Constant(1));
}
