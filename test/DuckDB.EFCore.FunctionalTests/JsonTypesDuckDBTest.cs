using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class JsonTypesDuckDBTest : JsonTypesRelationalTestBase
{
    public JsonTypesDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_array_of_array_of_int_JSON_values()
    {
        await base.Can_read_write_array_of_array_of_array_of_int_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_array_of_IPAddress_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_array_of_IPAddress_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_array_of_string_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_array_of_string_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_binary_JSON_values(string expected)
    {
        await base.Can_read_write_array_of_list_of_binary_JSON_values(expected);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_GUID_JSON_values(string expected)
    {
        await base.Can_read_write_array_of_list_of_GUID_JSON_values(expected);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_int_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_int_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_IPAddress_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_IPAddress_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_string_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_string_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_array_of_list_of_ulong_JSON_values()
    {
        await base.Can_read_write_array_of_list_of_ulong_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_nullable_ulong_enum_JSON_values()
    {
        await base.Can_read_write_collection_of_nullable_ulong_enum_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_ulong_enum_JSON_values()
    {
        await base.Can_read_write_collection_of_ulong_enum_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_binary_JSON_values(string expected)
    {
        await base.Can_read_write_list_of_array_of_binary_JSON_values(expected);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_GUID_JSON_values(string expected)
    {
        await base.Can_read_write_list_of_array_of_GUID_JSON_values(expected);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_int_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_int_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_list_of_IPAddress_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_list_of_IPAddress_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_IPAddress_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_IPAddress_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_list_of_array_of_binary_JSON_values(string expected)
    {
        await base.Can_read_write_list_of_array_of_list_of_array_of_binary_JSON_values(expected);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_list_of_string_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_list_of_string_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_list_of_ulong_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_list_of_ulong_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_nullable_GUID_JSON_values(string expected)
    {
        await base.Can_read_write_list_of_array_of_nullable_GUID_JSON_values(expected);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_nullable_int_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_nullable_int_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_nullable_ulong_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_nullable_ulong_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_string_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_string_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_array_of_ulong_JSON_values()
    {
        await base.Can_read_write_list_of_array_of_ulong_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_list_of_list_of_list_of_int_JSON_values()
    {
        await base.Can_read_write_list_of_list_of_list_of_int_JSON_values();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_ulong_enum_JSON_values(object? value, string json)
    {
        await base.Can_read_write_nullable_ulong_enum_JSON_values(value, json);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_ulong_enum_JSON_values(EnumU64 value, string json)
    {
        await base.Can_read_write_ulong_enum_JSON_values(value, json);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_binary_JSON_values(string value, string json)
    {
        await base.Can_read_write_binary_JSON_values(value, json);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_char_JSON_values(char value, string json)
    {
        await base.Can_read_write_char_JSON_values(value, json);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_binary_JSON_values(string expected)
    {
        await base.Can_read_write_collection_of_binary_JSON_values(expected);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_char_JSON_values()
    {
        await base.Can_read_write_collection_of_char_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_DateOnly_JSON_values()
    {
        await base.Can_read_write_collection_of_DateOnly_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_char_values_with_converter_as_JSON_string()
    {
        await base.Can_read_write_collection_of_char_values_with_converter_as_JSON_string();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_Guid_converted_to_bytes_JSON_values(string expected)
    {
        await base.Can_read_write_collection_of_Guid_converted_to_bytes_JSON_values(expected);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_nullable_binary_JSON_values(string expected)
    {
        await base.Can_read_write_collection_of_nullable_binary_JSON_values(expected);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_nullable_char_JSON_values()
    {
        await base.Can_read_write_collection_of_nullable_char_JSON_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_collection_of_nullable_char_values_with_converter_as_JSON_string()
    {
        await base.Can_read_write_collection_of_nullable_char_values_with_converter_as_JSON_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_line_string()
    {
        await base.Can_read_write_line_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_line_string_as_GeoJson()
    {
        await base.Can_read_write_line_string_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_multi_line_string()
    {
        await base.Can_read_write_multi_line_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_multi_line_string_as_GeoJson()
    {
        await base.Can_read_write_multi_line_string_as_GeoJson();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_binary_JSON_values(string? value, string json)
    {
        await base.Can_read_write_nullable_binary_JSON_values(value, json);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_char_JSON_values(char? value, string json)
    {
        await base.Can_read_write_nullable_char_JSON_values(value, json);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_line_string()
    {
        await base.Can_read_write_nullable_line_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_line_string_as_GeoJson()
    {
        await base.Can_read_write_nullable_line_string_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_multi_line_string()
    {
        await base.Can_read_write_nullable_multi_line_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_read_write_nullable_multi_line_string_as_GeoJson()
    {
        return base.Can_read_write_nullable_multi_line_string_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_point()
    {
        await base.Can_read_write_nullable_point();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_read_write_nullable_point_as_GeoJson()
    {
        return base.Can_read_write_nullable_point_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_read_write_nullable_polygon()
    {
        return base.Can_read_write_nullable_polygon();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_nullable_polygon_as_GeoJson()
    {
        await base.Can_read_write_nullable_polygon_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point()
    {
        await base.Can_read_write_point();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_as_GeoJson()
    {
        await base.Can_read_write_point_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_M()
    {
        await base.Can_read_write_point_with_M();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_M_as_GeoJson()
    {
        await base.Can_read_write_point_with_M_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_Z()
    {
        await base.Can_read_write_point_with_Z();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_Z_and_M()
    {
        await base.Can_read_write_point_with_Z_and_M();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_Z_and_M_as_GeoJson()
    {
        await base.Can_read_write_point_with_Z_and_M_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_point_with_Z_as_GeoJson()
    {
        await base.Can_read_write_point_with_Z_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon()
    {
        await base.Can_read_write_polygon();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon_as_GeoJson()
    {
        await base.Can_read_write_polygon_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon_typed_as_geometry()
    {
        await base.Can_read_write_polygon_typed_as_geometry();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon_typed_as_nullable_geometry()
    {
        await base.Can_read_write_polygon_typed_as_nullable_geometry();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon_typed_as_geometry_as_GeoJson()
    {
        await base.Can_read_write_polygon_typed_as_geometry_as_GeoJson();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_read_write_polygon_typed_as_nullable_geometry_as_GeoJson()
    {
        await base.Can_read_write_polygon_typed_as_nullable_geometry_as_GeoJson();
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
