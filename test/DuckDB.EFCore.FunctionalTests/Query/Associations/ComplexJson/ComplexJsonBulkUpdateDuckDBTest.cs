using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;

public class ComplexJsonBulkUpdateDuckDBTest : ComplexJsonBulkUpdateRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonBulkUpdateDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_inside_primitive_collection()
    {
        return base.Update_inside_primitive_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_multiple_projected_associates_via_anonymous_type()
    {
        return base.Update_multiple_projected_associates_via_anonymous_type();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_multiple_properties_inside_associates_and_on_entity_type()
    {
        return base.Update_multiple_properties_inside_associates_and_on_entity_type();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_multiple_properties_inside_same_associate()
    {
        return base.Update_multiple_properties_inside_same_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_another_nested_associate()
    {
        return base.Update_nested_associate_to_another_nested_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_inline_with_lambda()
    {
        return base.Update_nested_associate_to_inline_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_parameter()
    {
        return base.Update_nested_associate_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_another_nested_collection()
    {
        return base.Update_nested_collection_to_another_nested_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_inline_with_lambda()
    {
        return base.Update_nested_collection_to_inline_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_parameter()
    {
        return base.Update_nested_collection_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_another_collection()
    {
        return base.Update_primitive_collection_to_another_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_constant()
    {
        return base.Update_primitive_collection_to_constant();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_parameter()
    {
        return base.Update_primitive_collection_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_property_inside_associate()
    {
        return base.Update_property_inside_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_property_inside_associate_with_special_chars()
    {
        return base.Update_property_inside_associate_with_special_chars();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_property_inside_nested_associate()
    {
        return base.Update_property_inside_nested_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_property_on_projected_associate()
    {
        return base.Update_property_on_projected_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_required_nested_associate_to_null()
    {
        return base.Update_required_nested_associate_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_property_on_projected_associate_with_OrderBy_Skip()
    {
        return base.Update_property_on_projected_associate_with_OrderBy_Skip();
    }
}
