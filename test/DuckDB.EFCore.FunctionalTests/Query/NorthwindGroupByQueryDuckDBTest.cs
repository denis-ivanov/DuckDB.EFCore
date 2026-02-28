using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindGroupByQueryDuckDBTest : NorthwindGroupByQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindGroupByQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task AsEnumerable_in_subquery_for_GroupBy(bool async)
    {
        return base.AsEnumerable_in_subquery_for_GroupBy(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_query_with_group_by_in_subquery5(bool async)
    {
        return base.Complex_query_with_group_by_in_subquery5(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_query_with_groupBy_in_subquery1(bool async)
    {
        return base.Complex_query_with_groupBy_in_subquery1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_query_with_groupBy_in_subquery2(bool async)
    {
        return base.Complex_query_with_groupBy_in_subquery2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_query_with_groupBy_in_subquery3(bool async)
    {
        return base.Complex_query_with_groupBy_in_subquery3(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_query_with_groupBy_in_subquery4(bool async)
    {
        return base.Complex_query_with_groupBy_in_subquery4(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task GroupBy_aggregate_projecting_conditional_expression(bool async)
    {
        return base.GroupBy_aggregate_projecting_conditional_expression(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_correlated_collection_after_GroupBy_aggregate_when_identifier_changes_to_complex(bool async)
    {
        return base.Select_correlated_collection_after_GroupBy_aggregate_when_identifier_changes_to_complex(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nested_collection_with_groupby(bool async)
    {
        return base.Select_nested_collection_with_groupby(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_uncorrelated_collection_with_groupby_multiple_collections_work(bool async)
    {
        return base.Select_uncorrelated_collection_with_groupby_multiple_collections_work(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_uncorrelated_collection_with_groupby_when_outer_is_distinct(bool async)
    {
        return base.Select_uncorrelated_collection_with_groupby_when_outer_is_distinct(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_uncorrelated_collection_with_groupby_works(bool async)
    {
        return base.Select_uncorrelated_collection_with_groupby_works(async);
    }
}