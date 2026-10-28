using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class EntitySplittingQueryDuckDBTest : EntitySplittingQueryTestBase
{
    public EntitySplittingQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}
