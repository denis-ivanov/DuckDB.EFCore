using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    public DuckDBQueryableMethodTranslatingExpressionVisitor(QueryableMethodTranslatingExpressionVisitorDependencies dependencies, RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies, RelationalQueryCompilationContext queryCompilationContext) : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }
}
