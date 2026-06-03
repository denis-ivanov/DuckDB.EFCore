using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class ManyToManyQueryDuckDBTest : ManyToManyQueryRelationalTestBase<ManyToManyQueryDuckDBFixture>
{
    public ManyToManyQueryDuckDBTest(ManyToManyQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
