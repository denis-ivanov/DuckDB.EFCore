using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class NorthwindGroupByQueryDuckDBTest : NorthwindGroupByQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindGroupByQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        fixture.TestSqlLoggerFactory.Clear();
        fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_aggregate_projecting_conditional_expression(bool async)
    {
        return base.GroupBy_aggregate_projecting_conditional_expression(async);
    }

    [ConditionalFact]
    public void GroupBy_AnyValue_translates_to_ANY_VALUE()
    {
        using var context = CreateContext();

        var _ = context.Customers
            .GroupBy(c => c.City)
            .Select(g => new
            {
                City = g.Key,
                AnyContactName = g.AnyValue(c => c.ContactName),
                AnyCompanyName = g.AnyValue(c => c.CompanyName)
            })
            .ToList();

        AssertSql(
            """
            SELECT c."City", ANY_VALUE(c."ContactName") AS "AnyContactName", ANY_VALUE(c."CompanyName") AS "AnyCompanyName"
            FROM "Customers" AS c
            GROUP BY c."City"
            """
        );
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
