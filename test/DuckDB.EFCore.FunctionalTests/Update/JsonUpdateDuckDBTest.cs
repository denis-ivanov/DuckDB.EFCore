using Xunit;

namespace Microsoft.EntityFrameworkCore.Update;

public class JsonUpdateDuckDBTest : JsonUpdateTestBase<JsonUpdateDuckDBFixture>
{
    public JsonUpdateDuckDBTest(JsonUpdateDuckDBFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Edit_single_property_nullable_dateonly_set_to_null()
    {
        await base.Edit_single_property_nullable_dateonly_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Edit_single_property_nullable_datetime_set_to_null()
    {
        await base.Edit_single_property_nullable_datetime_set_to_null();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(false)]
    [InlineData(true)]
    [InlineData(null)]
    public override Task Add_and_update_nested_optional_owned_collection_to_JSON(bool? value)
    {
        return base.Add_and_update_nested_optional_owned_collection_to_JSON(value);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(false)]
    [InlineData(true)]
    [InlineData(null)]
    public override Task Add_and_update_nested_optional_primitive_collection(bool? value)
    {
        return base.Add_and_update_nested_optional_primitive_collection(value);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(false)]
    [InlineData(true)]
    [InlineData(null)]
    public override Task Add_and_update_top_level_optional_owned_collection_to_JSON(bool? value)
    {
        return base.Add_and_update_top_level_optional_owned_collection_to_JSON(value);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_element_to_json_collection_branch()
    {
        return base.Add_element_to_json_collection_branch();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_element_to_json_collection_leaf()
    {
        return base.Add_element_to_json_collection_leaf();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_element_to_json_collection_on_derived()
    {
        return base.Add_element_to_json_collection_on_derived();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_element_to_json_collection_root()
    {
        return base.Add_element_to_json_collection_root();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_element_to_json_collection_root_null_navigations()
    {
        return base.Add_element_to_json_collection_root_null_navigations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_entity_with_json()
    {
        return base.Add_entity_with_json();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_entity_with_json_null_navigations()
    {
        return base.Add_entity_with_json_null_navigations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_json_reference_leaf()
    {
        return base.Add_json_reference_leaf();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Add_json_reference_root()
    {
        return base.Add_json_reference_root();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_entity_with_json()
    {
        return base.Delete_entity_with_json();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_json_collection_branch()
    {
        return base.Delete_json_collection_branch();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_json_collection_root()
    {
        return base.Delete_json_collection_root();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_json_reference_leaf()
    {
        return base.Delete_json_reference_leaf();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_json_reference_root()
    {
        return base.Delete_json_reference_root();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_a_scalar_property_and_another_property_behind_reference_navigation_on_the_same_entity()
    {
        return base.Edit_a_scalar_property_and_another_property_behind_reference_navigation_on_the_same_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_a_scalar_property_and_collection_navigation_on_the_same_entity()
    {
        return base.Edit_a_scalar_property_and_collection_navigation_on_the_same_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_element_in_json_collection_root1()
    {
        return base.Edit_element_in_json_collection_root1();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_element_in_json_collection_root2()
    {
        return base.Edit_element_in_json_collection_root2();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_element_in_json_collection_branch()
    {
        return base.Edit_element_in_json_collection_branch();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_element_in_json_multiple_levels_partial_update()
    {
        return base.Edit_element_in_json_multiple_levels_partial_update();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_element_in_json_branch_collection_and_add_element_to_the_same_collection()
    {
        return base.Edit_element_in_json_branch_collection_and_add_element_to_the_same_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_two_elements_in_the_same_json_collection()
    {
        return base.Edit_two_elements_in_the_same_json_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_two_elements_in_the_same_json_collection_at_the_root()
    {
        return base.Edit_two_elements_in_the_same_json_collection_at_the_root();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_collection_element_and_reference_at_once()
    {
        return base.Edit_collection_element_and_reference_at_once();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_enum_property()
    {
        return base.Edit_single_enum_property();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_numeric_property()
    {
        return base.Edit_single_numeric_property();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_bool()
    {
        return base.Edit_single_property_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_byte()
    {
        return base.Edit_single_property_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_char()
    {
        return base.Edit_single_property_char();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_datetime()
    {
        return base.Edit_single_property_datetime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_datetimeoffset()
    {
        return base.Edit_single_property_datetimeoffset();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_decimal()
    {
        return base.Edit_single_property_decimal();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_double()
    {
        return base.Edit_single_property_double();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_guid()
    {
        return base.Edit_single_property_guid();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_int16()
    {
        return base.Edit_single_property_int16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_int32()
    {
        return base.Edit_single_property_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_int64()
    {
        return base.Edit_single_property_int64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_signed_byte()
    {
        return base.Edit_single_property_signed_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_single()
    {
        return base.Edit_single_property_single();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_timespan()
    {
        return base.Edit_single_property_timespan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_dateonly()
    {
        return base.Edit_single_property_dateonly();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_timeonly()
    {
        return base.Edit_single_property_timeonly();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_uint16()
    {
        return base.Edit_single_property_uint16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_uint32()
    {
        return base.Edit_single_property_uint32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_uint64()
    {
        return base.Edit_single_property_uint64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_int32()
    {
        return base.Edit_single_property_nullable_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_int32_set_to_null()
    {
        return base.Edit_single_property_nullable_int32_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_enum()
    {
        return base.Edit_single_property_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_enum_with_int_converter()
    {
        return base.Edit_single_property_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum()
    {
        return base.Edit_single_property_nullable_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum_set_to_null()
    {
        return base.Edit_single_property_nullable_enum_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum_with_int_converter()
    {
        return base.Edit_single_property_nullable_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum_with_int_converter_set_to_null()
    {
        return base.Edit_single_property_nullable_enum_with_int_converter_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum_with_converter_that_handles_nulls()
    {
        return base.Edit_single_property_nullable_enum_with_converter_that_handles_nulls();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_nullable_enum_with_converter_that_handles_nulls_set_to_null()
    {
        return base.Edit_single_property_nullable_enum_with_converter_that_handles_nulls_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_two_properties_on_same_entity_updates_the_entire_entity()
    {
        return base.Edit_two_properties_on_same_entity_updates_the_entire_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_a_scalar_property_and_reference_navigation_on_the_same_entity()
    {
        return base.Edit_a_scalar_property_and_reference_navigation_on_the_same_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_bool_to_int_zero_one()
    {
        return base.Edit_single_property_with_converter_bool_to_int_zero_one();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_bool_to_string_True_False()
    {
        return base.Edit_single_property_with_converter_bool_to_string_True_False();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_bool_to_string_Y_N()
    {
        return base.Edit_single_property_with_converter_bool_to_string_Y_N();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_int_zero_one_to_bool()
    {
        return base.Edit_single_property_with_converter_int_zero_one_to_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_string_True_False_to_bool()
    {
        return base.Edit_single_property_with_converter_string_True_False_to_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_converter_string_Y_N_to_bool()
    {
        return base.Edit_single_property_with_converter_string_Y_N_to_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_numeric()
    {
        return base.Edit_single_property_collection_of_numeric();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_string()
    {
        return base.Edit_single_property_collection_of_string();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_bool()
    {
        return base.Edit_single_property_collection_of_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_byte()
    {
        return base.Edit_single_property_collection_of_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_char()
    {
        return base.Edit_single_property_collection_of_char();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_datetime()
    {
        return base.Edit_single_property_collection_of_datetime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_datetimeoffset()
    {
        return base.Edit_single_property_collection_of_datetimeoffset();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_decimal()
    {
        return base.Edit_single_property_collection_of_decimal();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_double()
    {
        return base.Edit_single_property_collection_of_double();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_guid()
    {
        return base.Edit_single_property_collection_of_guid();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_int16()
    {
        return base.Edit_single_property_collection_of_int16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_int32()
    {
        return base.Edit_single_property_collection_of_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_int64()
    {
        return base.Edit_single_property_collection_of_int64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_signed_byte()
    {
        return base.Edit_single_property_collection_of_signed_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_single()
    {
        return base.Edit_single_property_collection_of_single();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_timespan()
    {
        return base.Edit_single_property_collection_of_timespan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_dateonly()
    {
        return base.Edit_single_property_collection_of_dateonly();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_timeonly()
    {
        return base.Edit_single_property_collection_of_timeonly();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_uint16()
    {
        return base.Edit_single_property_collection_of_uint16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_uint32()
    {
        return base.Edit_single_property_collection_of_uint32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_uint64()
    {
        return base.Edit_single_property_collection_of_uint64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_int32()
    {
        return base.Edit_single_property_collection_of_nullable_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_int32_set_to_null()
    {
        return base.Edit_single_property_collection_of_nullable_int32_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_enum()
    {
        return base.Edit_single_property_collection_of_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_enum_with_int_converter()
    {
        return base.Edit_single_property_collection_of_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum()
    {
        return base.Edit_single_property_collection_of_nullable_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum_set_to_null()
    {
        return base.Edit_single_property_collection_of_nullable_enum_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum_with_int_converter()
    {
        return base.Edit_single_property_collection_of_nullable_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum_with_int_converter_set_to_null()
    {
        return base.Edit_single_property_collection_of_nullable_enum_with_int_converter_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum_with_converter_that_handles_nulls()
    {
        return base.Edit_single_property_collection_of_nullable_enum_with_converter_that_handles_nulls();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_nullable_enum_with_converter_that_handles_nulls_set_to_null()
    {
        return base.Edit_single_property_collection_of_nullable_enum_with_converter_that_handles_nulls_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_bool()
    {
        return base.Edit_single_property_relational_collection_of_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_byte()
    {
        return base.Edit_single_property_relational_collection_of_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_char()
    {
        return base.Edit_single_property_relational_collection_of_char();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_datetime()
    {
        return base.Edit_single_property_relational_collection_of_datetime();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_datetimeoffset()
    {
        return base.Edit_single_property_relational_collection_of_datetimeoffset();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_decimal()
    {
        return base.Edit_single_property_relational_collection_of_decimal();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_double()
    {
        return base.Edit_single_property_relational_collection_of_double();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_guid()
    {
        return base.Edit_single_property_relational_collection_of_guid();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_int16()
    {
        return base.Edit_single_property_relational_collection_of_int16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_int32()
    {
        return base.Edit_single_property_relational_collection_of_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_int64()
    {
        return base.Edit_single_property_relational_collection_of_int64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_signed_byte()
    {
        return base.Edit_single_property_relational_collection_of_signed_byte();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_single()
    {
        return base.Edit_single_property_relational_collection_of_single();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_timespan()
    {
        return base.Edit_single_property_relational_collection_of_timespan();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_uint16()
    {
        return base.Edit_single_property_relational_collection_of_uint16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_uint32()
    {
        return base.Edit_single_property_relational_collection_of_uint32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_uint64()
    {
        return base.Edit_single_property_relational_collection_of_uint64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_int32()
    {
        return base.Edit_single_property_relational_collection_of_nullable_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_int32_set_to_null()
    {
        return base.Edit_single_property_relational_collection_of_nullable_int32_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_enum()
    {
        return base.Edit_single_property_relational_collection_of_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_enum_with_int_converter()
    {
        return base.Edit_single_property_relational_collection_of_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum_set_to_null()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum_with_int_converter()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum_with_int_converter_set_to_null()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum_with_int_converter_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum_with_converter_that_handles_nulls()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum_with_converter_that_handles_nulls();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_relational_collection_of_nullable_enum_with_converter_that_handles_nulls_set_to_null()
    {
        return base.Edit_single_property_relational_collection_of_nullable_enum_with_converter_that_handles_nulls_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_bool()
    {
        return base.Edit_single_property_collection_of_collection_of_bool();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_char()
    {
        return base.Edit_single_property_collection_of_collection_of_char();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_double()
    {
        return base.Edit_single_property_collection_of_collection_of_double();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_int16()
    {
        return base.Edit_single_property_collection_of_collection_of_int16();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_int32()
    {
        return base.Edit_single_property_collection_of_collection_of_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_int64()
    {
        return base.Edit_single_property_collection_of_collection_of_int64();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_single()
    {
        return base.Edit_single_property_collection_of_collection_of_single();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_nullable_int32()
    {
        return base.Edit_single_property_collection_of_collection_of_nullable_int32();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_nullable_int32_set_to_null()
    {
        return base.Edit_single_property_collection_of_collection_of_nullable_int32_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_nullable_enum_set_to_null()
    {
        return base.Edit_single_property_collection_of_collection_of_nullable_enum_set_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_collection_of_collection_of_nullable_enum_with_int_converter()
    {
        return base.Edit_single_property_collection_of_collection_of_nullable_enum_with_int_converter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Edit_single_property_with_non_ascii_characters()
    {
        return base.Edit_single_property_with_non_ascii_characters();
    }

    protected override void ClearLog()
    {
        Fixture.TestSqlLoggerFactory.Clear();
    }
}
