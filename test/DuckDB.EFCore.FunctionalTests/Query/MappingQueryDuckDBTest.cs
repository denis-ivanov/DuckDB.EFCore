using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class MappingQueryDuckDBTest : MappingQueryTestBase<MappingQueryDuckDBTest.MappingQueryDuckDBFixture>
{
    public MappingQueryDuckDBTest(MappingQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void All_customers()
    {
        base.All_customers();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void All_employees()
    {
        base.All_employees();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void All_orders()
    {
        base.All_orders();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Project_nullable_enum()
    {
        base.Project_nullable_enum();
    }

    public class MappingQueryDuckDBFixture : MappingQueryFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBNorthwindTestStoreFactory.Instance;

        protected override string DatabaseSchema { get; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<MappedCustomer>(e =>
            {
                e.Property(c => c.CompanyName2).Metadata.SetColumnName("CompanyName");
                e.Metadata.SetTableName("Customers");
            });
        }
    }
}