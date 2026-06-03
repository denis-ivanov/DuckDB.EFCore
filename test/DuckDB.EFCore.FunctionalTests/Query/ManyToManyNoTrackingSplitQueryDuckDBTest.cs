using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class ManyToManyNoTrackingSplitQueryDuckDBTest : ManyToManyNoTrackingQueryRelationalTestBase<ManyToManySplitQueryDuckDBFixture>
{
    public ManyToManyNoTrackingSplitQueryDuckDBTest(ManyToManySplitQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
