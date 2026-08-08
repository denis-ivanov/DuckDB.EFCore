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

    [ConditionalFact]
    public void GroupBy_ArgMax_translates_to_ARG_MAX()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                LatestOrderId = g.ArgMax(o => o.OrderID, o => o.OrderDate)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MAX(o."OrderID", o."OrderDate") AS "LatestOrderId"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgMax_with_count_translates_to_ARG_MAX()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                LatestOrderIds = g.ArgMax(o => o.OrderID, o => o.OrderDate, 3)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.NotEmpty(r.LatestOrderIds));

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MAX(o."OrderID", o."OrderDate", 3) AS "LatestOrderIds"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgMaxNull_translates_to_ARG_MAX_NULL()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                LatestEmployeeId = g.ArgMaxNull(o => o.EmployeeID, o => o.OrderDate)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MAX_NULL(o."EmployeeID", o."OrderDate") AS "LatestEmployeeId"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
