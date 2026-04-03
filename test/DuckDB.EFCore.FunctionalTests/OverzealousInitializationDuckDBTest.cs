using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests;

public class OverzealousInitializationDuckDBTest : OverzealousInitializationTestBase<OverzealousInitializationDuckDBTest.OverzealousInitializationDuckDBFixture>
{
    public OverzealousInitializationDuckDBTest(OverzealousInitializationDuckDBFixture fixture) : base(fixture)
    {
    }

    public class OverzealousInitializationDuckDBFixture : OverzealousInitializationFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
