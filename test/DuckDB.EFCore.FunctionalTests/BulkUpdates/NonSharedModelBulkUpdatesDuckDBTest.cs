using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class NonSharedModelBulkUpdatesDuckDBTest : NonSharedModelBulkUpdatesRelationalTestBase
{
    public NonSharedModelBulkUpdatesDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory => DuckDBTestStoreFactory.Instance;
}
