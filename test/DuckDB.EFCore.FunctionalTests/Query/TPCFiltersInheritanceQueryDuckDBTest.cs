using Microsoft.EntityFrameworkCore.Query.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPCFiltersInheritanceQueryDuckDBTest : TPCFiltersInheritanceQueryTestBase<TPCFiltersInheritanceQueryDuckDBFixture>
{
    public TPCFiltersInheritanceQueryDuckDBTest(TPCFiltersInheritanceQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Can_use_derived_set(bool async)
    {
        return base.Can_use_derived_set(async);
    }
}
