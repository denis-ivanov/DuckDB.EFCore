using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryCompilationContextFactory : IQueryCompilationContextFactory
{
    private readonly QueryCompilationContextDependencies _compilationContextDependencies;
    private readonly RelationalQueryCompilationContextDependencies _relationalQueryCompilationContextDependencies;

    public DuckDBQueryCompilationContextFactory(
        QueryCompilationContextDependencies compilationContextDependencies,
        RelationalQueryCompilationContextDependencies relationalQueryCompilationContextDependencies)
    {
        _compilationContextDependencies = compilationContextDependencies;
        _relationalQueryCompilationContextDependencies = relationalQueryCompilationContextDependencies;
    }

    public QueryCompilationContext Create(bool async)
    {
        return new DuckDBQueryCompilationContext(
            _compilationContextDependencies,
            _relationalQueryCompilationContextDependencies,
            async);
    }
}