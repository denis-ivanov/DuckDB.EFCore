using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQueryCompilationContextFactory : IQueryCompilationContextFactory
{
    private readonly QueryCompilationContextDependencies _compilationContextDependencies;
    private readonly RelationalQueryCompilationContextDependencies _relationalQueryCompilationContextDependencies;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBQueryCompilationContextFactory(
        QueryCompilationContextDependencies compilationContextDependencies,
        RelationalQueryCompilationContextDependencies relationalQueryCompilationContextDependencies)
    {
        _compilationContextDependencies = compilationContextDependencies;
        _relationalQueryCompilationContextDependencies = relationalQueryCompilationContextDependencies;
    }

    /// <inheritdoc />
    public QueryCompilationContext Create(bool async)
    {
        return new DuckDBQueryCompilationContext(
            _compilationContextDependencies,
            _relationalQueryCompilationContextDependencies,
            async);
    }
}
