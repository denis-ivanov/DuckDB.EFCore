using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonProjectionDuckDBTest: ComplexJsonProjectionRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonProjectionDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_associate_collection(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_associate_collection(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nested_collection_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nested_collection_on_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nested_collection_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nested_collection_on_required_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nullable_value_type_property_on_null_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nullable_value_type_property_on_null_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_optional_nested_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_nested_on_required_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_optional_nested_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_nested_on_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_property_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_property_on_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_required_associate_via_optional_navigation(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_associate_via_optional_navigation(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_required_nested_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_nested_on_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_required_nested_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_nested_on_required_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_root(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_root(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_root_duplicated(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_root_duplicated(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_scalar_property_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_scalar_property_on_required_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_subquery_optional_related_FirstOrDefault(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_subquery_optional_related_FirstOrDefault(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_subquery_required_related_FirstOrDefault(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_subquery_required_related_FirstOrDefault(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_unmapped_associate_scalar_property(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_unmapped_associate_scalar_property(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_untranslatable_method_on_associate_scalar_property(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_untranslatable_method_on_associate_scalar_property(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_associate_collection(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_associate_collection(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_nested_collection_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_nested_collection_on_optional_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_nested_collection_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_nested_collection_on_required_associate(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_non_nullable_value_type(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_non_nullable_value_type(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nullable_value_type(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nullable_value_type(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_nullable_value_type_with_Value(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nullable_value_type_with_Value(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_root_with_value_types(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_root_with_value_types(queryTrackingBehavior);
    }
}