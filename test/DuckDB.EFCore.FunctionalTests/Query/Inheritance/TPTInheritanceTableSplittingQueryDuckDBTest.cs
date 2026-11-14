using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPTInheritanceTableSplittingQueryDuckDBTest : TPTInheritanceTableSplittingQueryRelationalTestBase<TPTInheritanceQueryDuckDBFixture>
{
    public TPTInheritanceTableSplittingQueryDuckDBTest(TPTInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
