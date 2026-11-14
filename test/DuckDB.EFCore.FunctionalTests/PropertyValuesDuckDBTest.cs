using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class PropertyValuesDuckDBTest : PropertyValuesRelationalTestBase<PropertyValuesDuckDBTest.PropertyValuesDuckDBFixture>
{
    public PropertyValuesDuckDBTest(PropertyValuesDuckDBFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Complex_collection_store_values_can_be_accessed_as_a_property_dictionary()
    {
        await base.Complex_collection_store_values_can_be_accessed_as_a_property_dictionary();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Complex_collection_store_values_can_be_accessed_asynchronously_as_a_property_dictionary()
    {
        await base.Complex_collection_store_values_can_be_accessed_asynchronously_as_a_property_dictionary();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Store_values_can_be_cloned()
    {
        await base.Store_values_can_be_cloned();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Store_values_can_be_cloned_asynchronously()
    {
        await base.Store_values_can_be_cloned_asynchronously();
    }

    public class PropertyValuesDuckDBFixture : PropertyValuesRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
