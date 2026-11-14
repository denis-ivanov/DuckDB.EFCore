using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Inheritance;

public class TPTInheritanceJsonQueryDuckDBTest : TPTInheritanceJsonQueryRelationalTestBase<TPTInheritanceJsonQueryDuckDBFixture>
{
    public TPTInheritanceJsonQueryDuckDBTest(TPTInheritanceJsonQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
