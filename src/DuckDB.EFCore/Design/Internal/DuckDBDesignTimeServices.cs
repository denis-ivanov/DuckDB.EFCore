using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;

[assembly: DesignTimeProviderServices("DuckDB.EFCore.Design.Internal.DuckDBDesignTimeServices")]

namespace DuckDB.EFCore.Design.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBDesignTimeServices : IDesignTimeServices
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddEntityFrameworkDuckDB();
#pragma warning disable EF1001 // Internal EF Core API usage.
        new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
            .TryAdd<ICSharpRuntimeAnnotationCodeGenerator, DuckDBCSharpRuntimeAnnotationCodeGenerator>()
#pragma warning restore EF1001 // Internal EF Core API usage.
            .TryAdd<IDatabaseModelFactory, DuckDBDatabaseModelFactory>()
            .TryAdd<IProviderConfigurationCodeGenerator, DuckDBCodeGenerator>()
            .TryAddCoreServices();
    }
}
