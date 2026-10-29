using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Update;

public class NonSharedModelUpdatesDuckDBTest : NonSharedModelUpdatesTestBase
{
    public NonSharedModelUpdatesDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
