using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class EntitySplittingDuckDBTest : EntitySplittingTestBase
{
    public EntitySplittingDuckDBTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
