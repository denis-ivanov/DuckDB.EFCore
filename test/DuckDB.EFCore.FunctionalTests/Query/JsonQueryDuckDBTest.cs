using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class JsonQueryDuckDBTest : JsonQueryRelationalTestBase<JsonQueryDuckDBFixture>
{
    public JsonQueryDuckDBTest(JsonQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Custom_naming_projection_everything(bool async)
    {
        return base.Custom_naming_projection_everything(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Custom_naming_projection_owned_scalar(bool async)
    {
        return base.Custom_naming_projection_owned_scalar(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_all_types_entity_projection(bool async)
    {
        return base.Json_all_types_entity_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_all_types_projection_individual_properties(bool async)
    {
        return base.Json_all_types_projection_individual_properties(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_boolean_predicate(bool async)
    {
        return base.Json_boolean_predicate(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_boolean_predicate_negated(bool async)
    {
        return base.Json_boolean_predicate_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_filter_in_projection(bool async)
    {
        return base.Json_collection_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_in_projection_with_anonymous_projection_of_scalars(bool async)
    {
        return base.Json_collection_in_projection_with_anonymous_projection_of_scalars(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_index_in_projection_using_untranslatable_client_method(bool async)
    {
        return base.Json_collection_index_in_projection_using_untranslatable_client_method(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_index_in_projection_using_untranslatable_client_method2(bool async)
    {
        return base.Json_collection_index_in_projection_using_untranslatable_client_method2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_leaf_filter_in_projection(bool async)
    {
        return base.Json_collection_leaf_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_skip_take_in_projection(bool async)
    {
        return base.Json_collection_skip_take_in_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_skip_take_in_projection_project_into_anonymous_type(bool async)
    {
        return base.Json_collection_skip_take_in_projection_project_into_anonymous_type(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(bool async)
    {
        return base.Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_multiple_collection_projections(bool async)
    {
        return base.Json_multiple_collection_projections(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_nested_collection_anonymous_projection_in_projection(bool async)
    {
        return base.Json_nested_collection_anonymous_projection_in_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(bool async)
    {
        return base.Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_nested_collection_filter_in_projection(bool async)
    {
        return base.Json_nested_collection_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_bool_converted_to_string_True_False(bool async)
    {
        return base.Json_predicate_on_bool_converted_to_string_True_False(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_byte(bool async)
    {
        return base.Json_predicate_on_byte(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_byte_array(bool async)
    {
        return base.Json_predicate_on_byte_array(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_character(bool async)
    {
        return base.Json_predicate_on_character(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_dateonly(bool async)
    {
        return base.Json_predicate_on_dateonly(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_datetime(bool async)
    {
        return base.Json_predicate_on_datetime(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_datetimeoffset(bool async)
    {
        return base.Json_predicate_on_datetimeoffset(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_decimal(bool async)
    {
        return base.Json_predicate_on_decimal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_default_string(bool async)
    {
        return base.Json_predicate_on_default_string(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_double(bool async)
    {
        return base.Json_predicate_on_double(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_enum(bool async)
    {
        return base.Json_predicate_on_enum(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_enumwithintconverter(bool async)
    {
        return base.Json_predicate_on_enumwithintconverter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_guid(bool async)
    {
        return base.Json_predicate_on_guid(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_int16(bool async)
    {
        return base.Json_predicate_on_int16(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_int32(bool async)
    {
        return base.Json_predicate_on_int32(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_int64(bool async)
    {
        return base.Json_predicate_on_int64(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_max_length_string(bool async)
    {
        return base.Json_predicate_on_max_length_string(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableenum1(bool async)
    {
        return base.Json_predicate_on_nullableenum1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableenum2(bool async)
    {
        return base.Json_predicate_on_nullableenum2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableenumwithconverter1(bool async)
    {
        return base.Json_predicate_on_nullableenumwithconverter1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableenumwithconverter2(bool async)
    {
        return base.Json_predicate_on_nullableenumwithconverter2(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableenumwithconverterthathandlesnulls1(bool async)
    {
        return base.Json_predicate_on_nullableenumwithconverterthathandlesnulls1(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableint321(bool async)
    {
        return base.Json_predicate_on_nullableint321(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_nullableint322(bool async)
    {
        return base.Json_predicate_on_nullableint322(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_signedbyte(bool async)
    {
        return base.Json_predicate_on_signedbyte(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_single(bool async)
    {
        return base.Json_predicate_on_single(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_string_condition(bool async)
    {
        return base.Json_predicate_on_string_condition(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_timeonly(bool async)
    {
        return base.Json_predicate_on_timeonly(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_timespan(bool async)
    {
        return base.Json_predicate_on_timespan(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_unisgnedint16(bool async)
    {
        return base.Json_predicate_on_unisgnedint16(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_unsignedint32(bool async)
    {
        return base.Json_predicate_on_unsignedint32(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_predicate_on_unsignedint64(bool async)
    {
        return base.Json_predicate_on_unsignedint64(async);
    }

    public override async Task Json_scalar_length(bool async)
    {
        await base.Json_scalar_length(async);

        AssertSql(
            """
            SELECT j."Name"
            FROM "JsonEntitiesBasic" AS j
            WHERE length(j."OwnedReferenceRoot" ->> 'Name') > 2
            """);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(bool async)
    {
        return base.Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(async);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
