using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class ComplexNavigationsQueryDuckDBTest : ComplexNavigationsQueryRelationalTestBase<ComplexNavigationsQueryDuckDBFixture>
{
    public ComplexNavigationsQueryDuckDBTest(ComplexNavigationsQueryDuckDBFixture fixture)
        : base(fixture)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task GroupJoin_client_method_in_OrderBy(bool async)
    {
        return base.GroupJoin_client_method_in_OrderBy(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability_also_for_arguments(bool async)
    {
        return base.Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability_also_for_arguments(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Optional_navigation_inside_method_call_translated_to_join_keeps_original_nullability(bool async)
    {
        return base.Optional_navigation_inside_method_call_translated_to_join_keeps_original_nullability(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Join_with_result_selector_returning_queryable_throws_validation_error(bool async)
    {
        return base.Join_with_result_selector_returning_queryable_throws_validation_error(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability(bool async)
    {
        return base.Optional_navigation_inside_nested_method_call_translated_to_join_keeps_original_nullability(async);
    }
}
