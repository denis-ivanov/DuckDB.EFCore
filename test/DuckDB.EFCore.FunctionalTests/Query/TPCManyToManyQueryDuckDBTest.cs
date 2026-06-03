using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPCManyToManyQueryDuckDBTest : TPCManyToManyQueryRelationalTestBase<TPCManyToManyQueryDuckDBFixture>
{
    public TPCManyToManyQueryDuckDBTest(TPCManyToManyQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
