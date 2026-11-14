using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPHInheritanceJsonQueryDuckDBTest : TPHInheritanceJsonQueryRelationalTestBase<TPHInheritanceJsonQueryDuckDBFixture>
{
    public TPHInheritanceJsonQueryDuckDBTest(TPHInheritanceJsonQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
