using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;

[assembly: DesignTimeProviderServices("DuckDB.EFCore.Design.Internal.DuckDBDesignTimeServices")]

namespace DuckDB.EFCore.Design.Internal;

public class DuckDBDesignTimeServices : IDesignTimeServices
{
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
