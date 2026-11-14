using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPCInheritanceJsonQueryDuckDBTest : TPCInheritanceJsonQueryRelationalTestBase<TPCInheritanceJsonQueryDuckDBFixture>
{
    public TPCInheritanceJsonQueryDuckDBTest(TPCInheritanceJsonQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
