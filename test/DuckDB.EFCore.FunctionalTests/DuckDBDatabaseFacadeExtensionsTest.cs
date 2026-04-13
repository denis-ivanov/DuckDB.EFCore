using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class DuckDBDatabaseFacadeExtensionsTest
{
    [ConditionalFact]
    public void IsDuckDB_when_using_DuckDB()
    {
        using var context = new ProviderContext(
            new DbContextOptionsBuilder()
                .UseInternalServiceProvider(
                    new ServiceCollection()
                        .AddEntityFrameworkDuckDB()
                        .BuildServiceProvider(validateScopes: true))
                .UseDuckDB("Database=Maltesers").Options);
        Assert.True(context.Database.IsDuckDB());
    }

    private class ProviderContext(DbContextOptions options) : DbContext(options);
}
