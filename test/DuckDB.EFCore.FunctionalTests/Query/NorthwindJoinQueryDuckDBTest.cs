using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindJoinQueryDuckDBTest : NorthwindJoinQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindJoinQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_client_eval(bool async)
    {
        return base.SelectMany_with_client_eval(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_client_eval_with_collection_shaper(bool async)
    {
        return base.SelectMany_with_client_eval_with_collection_shaper(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_client_eval_with_collection_shaper_ignored(bool async)
    {
        return base.SelectMany_with_client_eval_with_collection_shaper_ignored(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_selecting_outer_element(bool async)
    {
        return base.SelectMany_with_selecting_outer_element(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_selecting_outer_entity(bool async)
    {
        return base.SelectMany_with_selecting_outer_entity(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_selecting_outer_entity_column_and_inner_column(bool async)
    {
        return base.SelectMany_with_selecting_outer_entity_column_and_inner_column(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Take_in_collection_projection_with_FirstOrDefault_on_top_level(bool async)
    {
        return base.Take_in_collection_projection_with_FirstOrDefault_on_top_level(async);
    }
}