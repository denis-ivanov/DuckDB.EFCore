using DuckDB.EFCore.NTS.Scaffolding.Internal;
using DuckDB.EFCore.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.NTS.Design.Internal;

public class DuckDBNetTopologySuiteDesignTimeServices : IDesignTimeServices
{
    public virtual void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IRelationalTypeMappingSourcePlugin, DuckDBNetTopologySuiteTypeMappingSourcePlugin>()
            .AddSingleton<IProviderCodeGeneratorPlugin, DuckDBNetTopologySuiteCodeGeneratorPlugin>();
    }
}