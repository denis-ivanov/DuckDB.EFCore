using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPCInheritanceTableSplittingQueryDuckDBTest : TPCInheritanceTableSplittingQueryRelationalTestBase<TPCInheritanceQueryDuckDBFixture>
{
    public TPCInheritanceTableSplittingQueryDuckDBTest(TPCInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
