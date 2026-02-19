using Microsoft.EntityFrameworkCore.BulkUpdates;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.BulkUpdates;

public class NorthwindBulkUpdatesDuckDBTest : NorthwindBulkUpdatesRelationalTestBase<NorthwindBulkUpdatesDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindBulkUpdatesDuckDBTest(NorthwindBulkUpdatesDuckDBFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_Where_predicate_with_GroupBy_aggregate(bool async)
    {
        return base.Delete_Where_predicate_with_GroupBy_aggregate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_Where_predicate_with_GroupBy_aggregate_2(bool async)
    {
        return base.Delete_Where_predicate_with_GroupBy_aggregate_2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_with_cross_apply(bool async)
    {
        return base.Delete_with_cross_apply(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_with_outer_apply(bool async)
    {
        return base.Delete_with_outer_apply(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_GroupBy_aggregate_set_constant(bool async)
    {
        return base.Update_Where_GroupBy_aggregate_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_GroupBy_First_set_constant(bool async)
    {
        return base.Update_Where_GroupBy_First_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_GroupBy_First_set_constant_2(bool async)
    {
        return base.Update_Where_GroupBy_First_set_constant_2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_GroupBy_First_set_constant_3(bool async)
    {
        return base.Update_Where_GroupBy_First_set_constant_3(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_Join_set_property_from_joined_single_result_scalar(bool async)
    {
        return base.Update_Where_Join_set_property_from_joined_single_result_scalar(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_Where_Join_set_property_from_joined_single_result_table(bool async)
    {
        return base.Update_Where_Join_set_property_from_joined_single_result_table(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_cross_apply_set_constant(bool async)
    {
        return base.Update_with_cross_apply_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_cross_join_cross_apply_set_constant(bool async)
    {
        return base.Update_with_cross_join_cross_apply_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_cross_join_left_join_set_constant(bool async)
    {
        return base.Update_with_cross_join_left_join_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_cross_join_outer_apply_set_constant(bool async)
    {
        return base.Update_with_cross_join_outer_apply_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_cross_join_set_constant(bool async)
    {
        return base.Update_with_cross_join_set_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_with_outer_apply_set_constant(bool async)
    {
        return base.Update_with_outer_apply_set_constant(async);
    }
}
