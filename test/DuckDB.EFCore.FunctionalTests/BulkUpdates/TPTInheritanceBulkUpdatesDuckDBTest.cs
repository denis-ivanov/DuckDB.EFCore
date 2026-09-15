using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPTInheritanceBulkUpdatesDuckDBTest : TPTInheritanceBulkUpdatesTestBase<TPTInheritanceBulkUpdatesDuckDBFixture>
{
    public TPTInheritanceBulkUpdatesDuckDBTest(TPTInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_base_property_on_derived_type(bool async)
    {
        return base.Update_base_property_on_derived_type(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_base_type_with_OfType(bool async)
    {
        return base.Update_base_type_with_OfType(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Delete_GroupBy_Where_Select_First_3(bool async)
    {
        return base.Delete_GroupBy_Where_Select_First_3(async);
    }
}