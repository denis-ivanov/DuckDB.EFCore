using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
{
    private readonly QuerySqlGeneratorDependencies _dependencies;
    private readonly IDuckDBSingletonOptions _duckDbSingletonOptions;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBQuerySqlGeneratorFactory(
        QuerySqlGeneratorDependencies dependencies,
        IDuckDBSingletonOptions duckDbSingletonOptions,
        IServiceProvider serviceProvider)
    {
        _dependencies = dependencies;
        _duckDbSingletonOptions = duckDbSingletonOptions;
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public QuerySqlGenerator Create()
    {
        return new DuckDBQuerySqlGenerator(
            _dependencies,
            _duckDbSingletonOptions.ReverseNullOrderingEnabled,
            _serviceProvider as ServiceProvider);
    }
}
