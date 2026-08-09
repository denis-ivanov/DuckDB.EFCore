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

    [ConditionalFact]
    public void GroupBy_ArgMin_translates_to_ARG_MIN()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EarliestOrderId = g.ArgMin(o => o.OrderID, o => o.OrderDate)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MIN(o."OrderID", o."OrderDate") AS "EarliestOrderId"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgMin_with_count_translates_to_ARG_MIN()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EarliestOrderIds = g.ArgMin(o => o.OrderID, o => o.OrderDate, 3)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.NotEmpty(r.EarliestOrderIds));

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MIN(o."OrderID", o."OrderDate", 3) AS "EarliestOrderIds"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgMinNull_translates_to_ARG_MIN_NULL()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EarliestEmployeeId = g.ArgMinNull(o => o.EmployeeID, o => o.OrderDate)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", ARG_MIN_NULL(o."EmployeeID", o."OrderDate") AS "EarliestEmployeeId"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BitAnd_translates_to_BIT_AND()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EmployeeIdBits = g.BitAnd(o => o.EmployeeID)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BIT_AND(o."EmployeeID") AS "EmployeeIdBits"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BitOr_translates_to_BIT_OR()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EmployeeIdBits = g.BitOr(o => o.EmployeeID)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BIT_OR(o."EmployeeID") AS "EmployeeIdBits"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BitXor_translates_to_BIT_XOR()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EmployeeIdBits = g.BitXor(o => o.EmployeeID)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BIT_XOR(o."EmployeeID") AS "EmployeeIdBits"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BitStringAgg_with_bounds_translates_to_BITSTRING_AGG()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                EmployeeIds = g.BitStringAgg(o => o.EmployeeID, 1, 9)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.Equal(9, r.EmployeeIds.Length));

        AssertSql(
            """
            SELECT o."CustomerID", BITSTRING_AGG(o."EmployeeID", 1, 9) AS "EmployeeIds"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BitStringAgg_translates_to_BITSTRING_AGG()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                OrderIds = g.BitStringAgg(o => o.OrderID)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BITSTRING_AGG(o."OrderID") AS "OrderIds"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BoolAnd_translates_to_BOOL_AND()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                AllHaveOrderDate = g.BoolAnd(o => o.OrderDate != null)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BOOL_AND(o."OrderDate" IS NOT NULL) AS "AllHaveOrderDate"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BoolOr_translates_to_BOOL_OR()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                AnyHasOrderDate = g.BoolOr(o => o.OrderDate != null)
            })
            .ToList();

        Assert.NotEmpty(results);

        AssertSql(
            """
            SELECT o."CustomerID", BOOL_OR(o."OrderDate" IS NOT NULL) AS "AnyHasOrderDate"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_BoolAnd_with_nullable_selector_returns_null_for_all_null_group()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                AllLateOrders = g.BoolAnd(o => o.OrderID > 11000 ? true : (bool?)null)
            })
            .ToList();

        Assert.Contains(results, r => r.AllLateOrders == null);

        AssertSql(
            """
            SELECT o."CustomerID", BOOL_AND(CASE
                WHEN o."OrderID" > 11000 THEN true
            END) AS "AllLateOrders"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_CountIf_translates_to_COUNTIF()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                LateOrders = g.CountIf(o => o.OrderID > 11000)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.Contains(results, r => r.LateOrders > 0);

        AssertSql(
            """
            SELECT o."CustomerID", COUNTIF(o."OrderID" > 11000) AS "LateOrders"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_CountIf_with_nullable_selector_returns_null_for_all_null_group()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                LateOrders = g.CountIf(o => o.OrderID > 11000 ? true : (bool?)null)
            })
            .ToList();

        Assert.Contains(results, r => r.LateOrders == null);

        AssertSql(
            """
            SELECT o."CustomerID", COUNTIF(CASE
                WHEN o."OrderID" > 11000 THEN true
            END) AS "LateOrders"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_FAvg_translates_to_FAVG()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                AverageOrderID = g.FAvg(o => o.OrderID)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.NotNull(r.AverageOrderID));

        AssertSql(
            """
            SELECT o."CustomerID", FAVG(o."OrderID") AS "AverageOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_FAvg_with_nullable_selector_returns_null_for_all_null_group()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                AverageLateOrderID = g.FAvg(o => o.OrderID > 11000 ? o.OrderID : (int?)null)
            })
            .ToList();

        Assert.Contains(results, r => r.AverageLateOrderID == null);

        AssertSql(
            """
            SELECT o."CustomerID", FAVG(CASE
                WHEN o."OrderID" > 11000 THEN o."OrderID"
            END) AS "AverageLateOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_FSum_translates_to_FSUM()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                TotalOrderID = g.FSum(o => o.OrderID)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.NotNull(r.TotalOrderID));

        AssertSql(
            """
            SELECT o."CustomerID", FSUM(o."OrderID") AS "TotalOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_FSum_with_nullable_selector_returns_null_for_all_null_group()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                TotalLateOrderID = g.FSum(o => o.OrderID > 11000 ? o.OrderID : (int?)null)
            })
            .ToList();

        Assert.Contains(results, r => r.TotalLateOrderID == null);

        AssertSql(
            """
            SELECT o."CustomerID", FSUM(CASE
                WHEN o."OrderID" > 11000 THEN o."OrderID"
            END) AS "TotalLateOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgFirst_translates_to_FIRST()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                FirstOrderID = g.ArgFirst(o => o.OrderID)
            })
            .ToList();

        Assert.NotEmpty(results);
        Assert.All(results, r => Assert.NotEqual(0, r.FirstOrderID));

        AssertSql(
            """
            SELECT o."CustomerID", FIRST(o."OrderID") AS "FirstOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    [ConditionalFact]
    public void GroupBy_ArgFirst_with_nullable_selector_translates_to_FIRST()
    {
        using var context = CreateContext();

        var results = context.Orders
            .GroupBy(o => o.CustomerID)
            .Select(g => new
            {
                CustomerID = g.Key,
                FirstLateOrderID = g.ArgFirst(o => o.OrderID > 11000 ? o.OrderID : (int?)null)
            })
            .ToList();

        Assert.Contains(results, r => r.FirstLateOrderID == null);

        AssertSql(
            """
            SELECT o."CustomerID", FIRST(CASE
                WHEN o."OrderID" > 11000 THEN o."OrderID"
            END) AS "FirstLateOrderID"
            FROM "Orders" AS o
            GROUP BY o."CustomerID"
            """
        );
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
