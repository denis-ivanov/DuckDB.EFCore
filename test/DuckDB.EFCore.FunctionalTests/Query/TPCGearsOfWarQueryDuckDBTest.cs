using Microsoft.EntityFrameworkCore.Query.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class TPCGearsOfWarQueryDuckDBTest : TPCGearsOfWarQueryRelationalTestBase<TPCGearsOfWarQueryDuckDBFixture>
{
    public TPCGearsOfWarQueryDuckDBTest(TPCGearsOfWarQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task DateTimeOffset_Contains_Less_than_Greater_than(bool async)
    {
        return base.DateTimeOffset_Contains_Less_than_Greater_than(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task DateTimeOffset_Date_returns_datetime(bool async)
    {
        return base.DateTimeOffset_Date_returns_datetime(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task DateTimeOffsetNow_minus_timespan(bool async)
    {
        return base.DateTimeOffsetNow_minus_timespan(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Non_string_concat_uses_appropriate_type_mapping(bool async)
    {
        return base.Non_string_concat_uses_appropriate_type_mapping(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Outer_parameter_in_group_join_with_DefaultIfEmpty(bool async)
    {
        return base.Outer_parameter_in_group_join_with_DefaultIfEmpty(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Select_null_propagation_negative4(bool async)
    {
        return base.Select_null_propagation_negative4(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Where_equals_method_on_nullable_with_object_overload(bool async)
    {
        return base.Where_equals_method_on_nullable_with_object_overload(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_with_ElementAt_using_column_as_index(bool async)
    {
        return base.Where_subquery_with_ElementAt_using_column_as_index(async);
    }
}
