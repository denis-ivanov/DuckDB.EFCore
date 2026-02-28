using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NullKeysDuckDBTest : NullKeysTestBase<NullKeysDuckDBTest.NullKeysDuckDBFixture>
{
    public NullKeysDuckDBTest(NullKeysDuckDBFixture fixture) : base(fixture)
    {
    }

    public class NullKeysDuckDBFixture : NullKeysFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}