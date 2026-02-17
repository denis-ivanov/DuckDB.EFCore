using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlTranslatingExpressionVisitorFactory : IRelationalSqlTranslatingExpressionVisitorFactory
{
    private readonly RelationalSqlTranslatingExpressionVisitorDependencies _relationalDependencies;

    public DuckDBSqlTranslatingExpressionVisitorFactory(RelationalSqlTranslatingExpressionVisitorDependencies relationalDependencies)
    {
        _relationalDependencies = relationalDependencies;
    }

    public RelationalSqlTranslatingExpressionVisitor Create(
        QueryCompilationContext queryCompilationContext,
        QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
    {
        return new DuckDBSqlTranslatingExpressionVisitor(
            _relationalDependencies,
            queryCompilationContext,
            queryableMethodTranslatingExpressionVisitor);
    }
}