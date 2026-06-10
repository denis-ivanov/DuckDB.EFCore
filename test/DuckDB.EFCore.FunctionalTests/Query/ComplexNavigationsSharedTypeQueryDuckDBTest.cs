using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class ComplexNavigationsSharedTypeQueryDuckDBTest : ComplexNavigationsSharedTypeQueryRelationalTestBase<ComplexNavigationsSharedTypeQueryDuckDBFixture>
{
    public ComplexNavigationsSharedTypeQueryDuckDBTest(ComplexNavigationsSharedTypeQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task GroupJoin_client_method_in_OrderBy(bool async)
    {
        await base.GroupJoin_client_method_in_OrderBy(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Join_with_result_selector_returning_queryable_throws_validation_error(bool async)
    {
        await base.Join_with_result_selector_returning_queryable_throws_validation_error(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_navigation_take_optional_navigation(bool async)
    {
        await base.Optional_navigation_take_optional_navigation(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_navigation_inside_method_call_translated_to_join_keeps_original_nullability(bool async)
    {
        await base.Optional_navigation_inside_method_call_translated_to_join_keeps_original_nullability(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability_also_for_arguments(bool async)
    {
        await base.Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability_also_for_arguments(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability(bool async)
    {
        await base.Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_subquery_with_custom_projection(bool async)
    {
        return base.SelectMany_subquery_with_custom_projection(async);
    }
}
