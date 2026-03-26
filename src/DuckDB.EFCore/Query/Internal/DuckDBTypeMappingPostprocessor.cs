using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBTypeMappingPostprocessor : RelationalTypeMappingPostprocessor
{
    private readonly IModel _model;
    private readonly IRelationalTypeMappingSource _typeMappingSource;
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBTypeMappingPostprocessor(QueryTranslationPostprocessorDependencies dependencies, RelationalQueryTranslationPostprocessorDependencies relationalDependencies, RelationalQueryCompilationContext queryCompilationContext) : base(dependencies, relationalDependencies, queryCompilationContext)
    {
        _model = queryCompilationContext.Model;
        _typeMappingSource = relationalDependencies.TypeMappingSource;
        _sqlExpressionFactory = relationalDependencies.SqlExpressionFactory;
    }

    protected override Expression VisitExtension(Expression expression)
    {
        switch (expression)
        {
            case DuckDBUnnestExpression unnestExpression
                when TryGetInferredTypeMapping(unnestExpression.Alias, unnestExpression.ColumnName, out var elementTypeMapping):
                {
                    var collectionTypeMapping = RelationalDependencies.TypeMappingSource.FindMapping(unnestExpression.Array.Type, _model, elementTypeMapping);

                    if (collectionTypeMapping is null)
                    {
                        throw new InvalidOperationException(RelationalStrings.NullTypeMappingInSqlTree(expression.Print()));
                    }

                    return unnestExpression.Update(
                        _sqlExpressionFactory.ApplyTypeMapping(unnestExpression.Array, collectionTypeMapping));
                }

            default:
                return base.VisitExtension(expression);
        }
    }
}