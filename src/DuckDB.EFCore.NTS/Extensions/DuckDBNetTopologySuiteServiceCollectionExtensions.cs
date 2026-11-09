using DuckDB.EFCore.NTS.Query.Internal;
using DuckDB.EFCore.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetTopologySuite;

namespace DuckDB.EFCore.NTS.Extensions;

/// <summary>
///     DuckDB.EFCore.NTS extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class DuckDBNetTopologySuiteServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the services required for NetTopologySuite support in the DuckDB provider for Entity Framework Core.
    /// </summary>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddEntityFrameworkDuckDBNetTopologySuite(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton(NtsGeometryServices.Instance);

        new EntityFrameworkRelationalServicesBuilder(serviceCollection)
            .TryAdd<IRelationalTypeMappingSourcePlugin, DuckDBNetTopologySuiteTypeMappingSourcePlugin>()
            .TryAdd<IMethodCallTranslatorPlugin, DuckDBNetTopologySuiteMethodCallTranslatorPlugin>()
            .TryAdd<IAggregateMethodCallTranslatorPlugin, DuckDBNetTopologySuiteAggregateMethodCallTranslatorPlugin>()
            .TryAdd<IMemberTranslatorPlugin, DuckDBNetTopologySuiteMemberTranslatorPlugin>();

        // Replace the SQL generator factory so that geometry projections are wrapped
        // with ST_AsWKT() – DuckDB.NET cannot read native GEOMETRY columns (type ID 40).
        serviceCollection.Replace(
            ServiceDescriptor.Singleton<IQuerySqlGeneratorFactory, DuckDBNtsQuerySqlGeneratorFactory>());

        return serviceCollection;
    }
}
