using DuckDB.EFCore.Design.Internal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

// TODO: Again and again EF Core team make tests non-virtual.
public abstract class RuntimeMigrationDuckDBTest : RuntimeMigrationTestBase<RuntimeMigrationDuckDBTest.RuntimeMigrationDuckDBFixture>
{
    public RuntimeMigrationDuckDBTest(RuntimeMigrationDuckDBFixture fixture) : base(fixture)
    {
    }
    
    public class RuntimeMigrationDuckDBFixture : RuntimeMigrationFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }

    protected override Assembly ProviderAssembly 
        => typeof(DuckDBDesignTimeServices).Assembly;
}
