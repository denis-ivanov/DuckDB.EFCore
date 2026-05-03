using DuckDB.EFCore.FunctionalTests.Query;

namespace Microsoft.EntityFrameworkCore.Query;

public class NorthwindQueryFiltersQueryDuckDBTest : NorthwindQueryFiltersQueryTestBase<NorthwindQueryDuckDBFixture<NorthwindQueryFiltersCustomizer>>
{
    public NorthwindQueryFiltersQueryDuckDBTest(NorthwindQueryDuckDBFixture<NorthwindQueryFiltersCustomizer> fixture) : base(fixture)
    {
    }
}
