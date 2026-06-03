using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class ManyToManySplitQueryDuckDBTest : ManyToManyQueryRelationalTestBase<ManyToManySplitQueryDuckDBFixture>
{
    public ManyToManySplitQueryDuckDBTest(ManyToManySplitQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
