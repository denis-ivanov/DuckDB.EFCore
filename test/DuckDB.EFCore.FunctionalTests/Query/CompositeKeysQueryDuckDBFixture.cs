using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class CompositeKeysQueryDuckDBFixture : CompositeKeysQueryRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}