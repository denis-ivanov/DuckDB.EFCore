using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingStructuralEqualityDuckDBTest : OwnedTableSplittingStructuralEqualityRelationalTestBase<OwnedTableSplittingDuckDBFixture>
{
    public OwnedTableSplittingStructuralEqualityDuckDBTest(OwnedTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
