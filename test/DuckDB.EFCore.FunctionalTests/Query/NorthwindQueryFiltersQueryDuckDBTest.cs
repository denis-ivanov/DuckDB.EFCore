using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindQueryFiltersQueryDuckDBTest : NorthwindQueryFiltersQueryTestBase<NorthwindQueryDuckDBFixture<NorthwindQueryFiltersCustomizer>>
{
    public NorthwindQueryFiltersQueryDuckDBTest(NorthwindQueryDuckDBFixture<NorthwindQueryFiltersCustomizer> fixture) : base(fixture)
    {
    }
}