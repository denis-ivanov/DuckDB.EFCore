using Microsoft.EntityFrameworkCore.Query.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class IncompleteMappingInheritanceQueryDuckDBTest : TPHInheritanceQueryTestBase<IncompleteMappingInheritanceQueryDuckDBFixture>
{
    public IncompleteMappingInheritanceQueryDuckDBTest(IncompleteMappingInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Setting_foreign_key_to_a_different_type_throws()
    {
        return base.Setting_foreign_key_to_a_different_type_throws();
    }
}
