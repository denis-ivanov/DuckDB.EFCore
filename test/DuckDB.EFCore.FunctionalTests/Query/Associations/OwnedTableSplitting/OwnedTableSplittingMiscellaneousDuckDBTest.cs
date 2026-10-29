using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingMiscellaneousDuckDBTest : OwnedTableSplittingMiscellaneousRelationalTestBase<OwnedTableSplittingDuckDBFixture>
{
    public OwnedTableSplittingMiscellaneousDuckDBTest(OwnedTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
