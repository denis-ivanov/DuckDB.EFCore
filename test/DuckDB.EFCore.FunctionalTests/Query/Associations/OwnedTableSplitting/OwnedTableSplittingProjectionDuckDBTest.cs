using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingProjectionDuckDBTest : OwnedTableSplittingProjectionRelationalTestBase<OwnedTableSplittingDuckDBFixture>
{
    public OwnedTableSplittingProjectionDuckDBTest(OwnedTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
