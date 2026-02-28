using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class AdHocAdvancedMappingsQueryDuckDBTest : AdHocAdvancedMappingsQueryRelationalTestBase
{
    public AdHocAdvancedMappingsQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_query_hierarchy_with_non_nullable_property_on_derived()
    {
        return base.Can_query_hierarchy_with_non_nullable_property_on_derived();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Casts_are_removed_from_expression_tree_when_redundant()
    {
        return base.Casts_are_removed_from_expression_tree_when_redundant();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Double_convert_interface_created_expression_tree()
    {
        return base.Double_convert_interface_created_expression_tree();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projecting_correlated_collection_along_with_non_mapped_property()
    {
        return base.Projecting_correlated_collection_along_with_non_mapped_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Projection_failing_with_EnumToStringConverter()
    {
        return base.Projection_failing_with_EnumToStringConverter();
    }
}
