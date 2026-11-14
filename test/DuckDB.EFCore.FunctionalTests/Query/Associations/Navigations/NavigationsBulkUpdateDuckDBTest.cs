using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Associations.Navigations;

public class NavigationsBulkUpdateDuckDBTest : NavigationsBulkUpdateRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsBulkUpdateDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Delete_optional_associate()
    {
        await base.Delete_optional_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Delete_required_associate()
    {
        await base.Delete_required_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_another_associate()
    {
        await base.Update_associate_to_another_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline()
    {
        await base.Update_associate_to_inline();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline_with_lambda()
    {
        await base.Update_associate_to_inline_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_null()
    {
        await base.Update_associate_to_null();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_parameter()
    {
        await base.Update_associate_to_null_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_with_lambda()
    {
        await base.Update_associate_to_null_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_associate_to_parameter()
    {
        await base.Update_associate_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_collection_referencing_the_original_collection()
    {
        await base.Update_collection_referencing_the_original_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_collection_to_parameter()
    {
        await base.Update_collection_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_inside_primitive_collection()
    {
        await base.Update_inside_primitive_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_inside_structural_collection()
    {
        await base.Update_inside_structural_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_multiple_projected_associates_via_anonymous_type()
    {
        await base.Update_multiple_projected_associates_via_anonymous_type();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_multiple_properties_inside_associates_and_on_entity_type()
    {
        await base.Update_multiple_properties_inside_associates_and_on_entity_type();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_another_nested_associate()
    {
        await base.Update_nested_associate_to_another_nested_associate();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_inline_with_lambda()
    {
        await base.Update_nested_associate_to_inline_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_parameter()
    {
        await base.Update_nested_associate_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_another_nested_collection()
    {
        await base.Update_nested_collection_to_another_nested_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_parameter()
    {
        await base.Update_nested_collection_to_parameter();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_inline_with_lambda()
    {
        await base.Update_nested_collection_to_inline_with_lambda();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_primitive_collection_to_another_collection()
    {
        await base.Update_primitive_collection_to_another_collection();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Update_property_on_projected_associate_with_OrderBy_Skip()
    {
        await base.Update_property_on_projected_associate_with_OrderBy_Skip();
    }
}
