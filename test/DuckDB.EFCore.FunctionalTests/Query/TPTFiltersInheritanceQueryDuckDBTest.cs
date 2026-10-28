using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTFiltersInheritanceQueryDuckDBTest : TPTFiltersInheritanceQueryTestBase<TPTFiltersInheritanceQueryDuckDBFixture>
{
    public TPTFiltersInheritanceQueryDuckDBTest(TPTFiltersInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_use_derived_set(bool async)
    {
        return base.Can_use_derived_set(async);
    }
}
