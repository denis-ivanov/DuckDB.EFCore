using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore;

public class LoadDuckDBTest : LoadTestBase<LoadDuckDBTest.LoadDuckDBFixture>
{
    public LoadDuckDBTest(LoadDuckDBFixture fixture) : base(fixture)
    {
    }

    public class LoadDuckDBFixture : LoadFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
