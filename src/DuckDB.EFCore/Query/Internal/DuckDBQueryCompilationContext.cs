using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryCompilationContext : RelationalQueryCompilationContext
{
    public DuckDBQueryCompilationContext(QueryCompilationContextDependencies dependencies, RelationalQueryCompilationContextDependencies relationalDependencies, bool async) : base(dependencies, relationalDependencies, async)
    {
    }
}