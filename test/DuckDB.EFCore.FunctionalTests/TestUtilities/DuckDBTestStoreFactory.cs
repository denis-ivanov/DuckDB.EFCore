using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.NTS.Extensions;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.FunctionalTests.TestUtilities;

public class DuckDBTestStoreFactory : RelationalTestStoreFactory
{
    public static DuckDBTestStoreFactory Instance { get; } = new();
    
    public override TestStore Create(string storeName)
    {
        return DuckDBTestStore.Create(storeName);
    }

    public override TestStore GetOrCreate(string storeName)
    {
        return DuckDBTestStore.GetOrCreate(storeName);
    }

    public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddEntityFrameworkDuckDB()
            .AddEntityFrameworkDuckDBNetTopologySuite();
    }
}
