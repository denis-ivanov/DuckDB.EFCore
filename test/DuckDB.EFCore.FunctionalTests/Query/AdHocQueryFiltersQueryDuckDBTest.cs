using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class AdHocQueryFiltersQueryDuckDBTest : AdHocQueryFiltersQueryRelationalTestBase
{
    public AdHocQueryFiltersQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}