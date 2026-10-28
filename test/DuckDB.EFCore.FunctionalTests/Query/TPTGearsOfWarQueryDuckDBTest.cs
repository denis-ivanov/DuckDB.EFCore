using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPTGearsOfWarQueryDuckDBTest : TPTGearsOfWarQueryRelationalTestBase<TPTGearsOfWarQueryDuckDBFixture>
{
    public TPTGearsOfWarQueryDuckDBTest(TPTGearsOfWarQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DateTimeOffset_Contains_Less_than_Greater_than(bool async)
    {
        return base.DateTimeOffset_Contains_Less_than_Greater_than(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DateTimeOffset_Date_returns_datetime(bool async)
    {
        return base.DateTimeOffset_Date_returns_datetime(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task DateTimeOffsetNow_minus_timespan(bool async)
    {
        return base.DateTimeOffsetNow_minus_timespan(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Non_string_concat_uses_appropriate_type_mapping(bool async)
    {
        return base.Non_string_concat_uses_appropriate_type_mapping(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Outer_parameter_in_group_join_with_DefaultIfEmpty(bool async)
    {
        return base.Outer_parameter_in_group_join_with_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Outer_parameter_in_join_key(bool async)
    {
        return base.Outer_parameter_in_join_key(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Outer_parameter_in_join_key_inner_and_outer(bool async)
    {
        return base.Outer_parameter_in_join_key_inner_and_outer(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_property_converted_to_nullable_into_member_access(bool async)
    {
        return base.Projecting_property_converted_to_nullable_into_member_access(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_null_propagation_negative3(bool async)
    {
        return base.Select_null_propagation_negative3(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_null_propagation_negative4(bool async)
    {
        return base.Select_null_propagation_negative4(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_null_propagation_negative5(bool async)
    {
        return base.Select_null_propagation_negative5(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_StartsWith_with_null_parameter_as_argument(bool async)
    {
        return base.Select_StartsWith_with_null_parameter_as_argument(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_predicate_after_navigation_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(bool async)
    {
        return base.SelectMany_predicate_after_navigation_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_predicate_with_non_equality_comparison_with_Take_doesnt_convert_to_join(bool async)
    {
        return base.SelectMany_predicate_with_non_equality_comparison_with_Take_doesnt_convert_to_join(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion(bool async)
    {
        return base.Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion_negated(bool async)
    {
        return base.Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion(bool async)
    {
        return base.Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion_negated(bool async)
    {
        return base.Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_equals_method_on_nullable_with_object_overload(bool async)
    {
        return base.Where_equals_method_on_nullable_with_object_overload(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_subquery_with_ElementAt_using_column_as_index(bool async)
    {
        return base.Where_subquery_with_ElementAt_using_column_as_index(async);
    }
}
