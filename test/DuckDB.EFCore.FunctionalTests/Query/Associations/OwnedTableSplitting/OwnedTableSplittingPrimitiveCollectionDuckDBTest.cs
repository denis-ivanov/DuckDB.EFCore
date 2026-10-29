using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingPrimitiveCollectionDuckDBTest : OwnedTableSplittingPrimitiveCollectionRelationalTestBase<OwnedTableSplittingDuckDBFixture>
{
    public OwnedTableSplittingPrimitiveCollectionDuckDBTest(OwnedTableSplittingDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
