using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class ManyToManyNoTrackingQueryDuckDBTest : ManyToManyNoTrackingQueryRelationalTestBase<ManyToManyQueryDuckDBFixture>
{
    public ManyToManyNoTrackingQueryDuckDBTest(ManyToManyQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
