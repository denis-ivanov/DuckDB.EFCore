using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPHInheritanceTableSplittingQueryDuckDBTest: TPHInheritanceTableSplittingQueryRelationalTestBase<TPHInheritanceQueryDuckDBFixture>
{
    public TPHInheritanceTableSplittingQueryDuckDBTest(TPHInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
