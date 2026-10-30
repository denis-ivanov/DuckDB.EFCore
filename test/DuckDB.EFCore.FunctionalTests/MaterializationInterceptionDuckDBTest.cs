using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore;

public class MaterializationInterceptionDuckDBTest : MaterializationInterceptionTestBase<MaterializationInterceptionDuckDBTest.DuckDBLibraryContext>
{
    public MaterializationInterceptionDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    public class DuckDBLibraryContext(DbContextOptions options) : LibraryContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestEntity30244>().OwnsMany(e => e.Settings, b => b.ToJson());
        }
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
