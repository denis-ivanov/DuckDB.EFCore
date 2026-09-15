using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPTFiltersInheritanceBulkUpdatesDuckDBTest : TPTFiltersInheritanceBulkUpdatesTestBase<TPTFiltersInheritanceBulkUpdatesDuckDBFixture>
{
    public TPTFiltersInheritanceBulkUpdatesDuckDBTest(TPTFiltersInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    protected override void ClearLog()
    {
        Fixture.TestSqlLoggerFactory.Clear();
    }

    [ConditionalTheory(Skip = "TBD")]
    public override Task Update_base_property_on_derived_type(bool async)
    {
        return base.Update_base_property_on_derived_type(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    public override Task Update_base_type_with_OfType(bool async)
    {
        return base.Update_base_type_with_OfType(async);
    }
}
