using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTManyToManyQueryDuckDBTest : TPTManyToManyQueryRelationalTestBase<TPTManyToManyQueryDuckDBFixture>
{
    public TPTManyToManyQueryDuckDBTest(TPTManyToManyQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
