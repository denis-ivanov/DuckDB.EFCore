using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class OptionalDependentQueryDuckDBTest: OptionalDependentQueryTestBase<OptionalDependentQueryDuckDBFixture>
{
    public OptionalDependentQueryDuckDBTest(OptionalDependentQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
