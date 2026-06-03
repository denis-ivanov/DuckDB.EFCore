using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTManyToManyNoTrackingQueryDuckDBTest : TPTManyToManyNoTrackingQueryRelationalTestBase<TPTManyToManyQueryDuckDBFixture>
{
    public TPTManyToManyNoTrackingQueryDuckDBTest(TPTManyToManyQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
