using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBParameterBasedSqlProcessorFactory : IRelationalParameterBasedSqlProcessorFactory
{
    private readonly RelationalParameterBasedSqlProcessorDependencies _dependencies;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBParameterBasedSqlProcessorFactory(RelationalParameterBasedSqlProcessorDependencies dependencies)
    {
        _dependencies = dependencies;
    }

    /// <inheritdoc />
    public RelationalParameterBasedSqlProcessor Create(RelationalParameterBasedSqlProcessorParameters parameters)
    {
        return new DuckDBParameterBasedSqlProcessor(_dependencies, parameters);
    }
}
