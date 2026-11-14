using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class ToSqlQueryDuckDBTest : ToSqlQueryTestBase
{
    public ToSqlQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
