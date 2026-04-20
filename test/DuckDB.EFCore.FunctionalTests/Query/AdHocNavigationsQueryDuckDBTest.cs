using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocNavigationsQueryDuckDBTest: AdHocNavigationsQueryRelationalTestBase
{
    public AdHocNavigationsQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_enumerable_navigation_backed_by_collection(bool async, bool split)
    {
        return base.Select_enumerable_navigation_backed_by_collection(async, split);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Collection_without_setter_materialized_correctly()
    {
        return base.Collection_without_setter_materialized_correctly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Correlated_collection_correctly_associates_entities_with_byte_array_keys()
    {
        return base.Correlated_collection_correctly_associates_entities_with_byte_array_keys();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Count_member_over_IReadOnlyCollection_works(bool async)
    {
        return base.Count_member_over_IReadOnlyCollection_works(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Customer_collections_materialize_properly()
    {
        return base.Customer_collections_materialize_properly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Cycles_in_auto_include()
    {
        return base.Cycles_in_auto_include();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_collection_optional_reference_collection()
    {
        return base.Include_collection_optional_reference_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_collection_with_OfType_base()
    {
        return base.Include_collection_with_OfType_base();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_collection_works_when_defined_on_intermediate_type()
    {
        return base.Include_collection_works_when_defined_on_intermediate_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_with_order_by_on_interface_key()
    {
        return base.Include_with_order_by_on_interface_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Let_multiple_references_with_reference_to_outer()
    {
        return base.Let_multiple_references_with_reference_to_outer();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projection_with_multiple_includes_and_subquery_with_set_operation()
    {
        return base.Projection_with_multiple_includes_and_subquery_with_set_operation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Reference_include_on_derived_type_with_sibling_works()
    {
        return base.Reference_include_on_derived_type_with_sibling_works();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_and_collection_in_projection_in_FirstOrDefault()
    {
        return base.SelectMany_and_collection_in_projection_in_FirstOrDefault();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task ThenInclude_with_interface_navigations()
    {
        return base.ThenInclude_with_interface_navigations();
    }
}
