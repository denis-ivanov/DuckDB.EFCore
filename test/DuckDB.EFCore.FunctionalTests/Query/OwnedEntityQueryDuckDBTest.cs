using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class OwnedEntityQueryDuckDBTest : OwnedEntityQueryRelationalTestBase
{
    public OwnedEntityQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Accessing_scalar_property_in_derived_type_projection_does_not_load_owned_navigations()
    {
        return base.Accessing_scalar_property_in_derived_type_projection_does_not_load_owned_navigations();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_auto_include_navigation_from_model()
    {
        return base.Can_auto_include_navigation_from_model();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Correlated_subquery_with_owned_navigation_being_compared_to_null_works()
    {
        return base.Correlated_subquery_with_owned_navigation_being_compared_to_null_works();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_collection_for_entity_with_owned_type_works()
    {
        return base.Include_collection_for_entity_with_owned_type_works();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multilevel_owned_entities_determine_correct_nullability()
    {
        return base.Multilevel_owned_entities_determine_correct_nullability();
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;
}
