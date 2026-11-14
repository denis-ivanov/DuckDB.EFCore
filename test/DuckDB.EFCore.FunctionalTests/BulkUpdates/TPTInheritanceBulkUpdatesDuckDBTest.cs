using Microsoft.EntityFrameworkCore.BulkUpdates.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPTInheritanceBulkUpdatesDuckDBTest : TPTInheritanceBulkUpdatesTestBase<TPTInheritanceBulkUpdatesDuckDBFixture>
{
    public TPTInheritanceBulkUpdatesDuckDBTest(TPTInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override async Task Update_base_property_on_derived_type(bool async)
    {
        await base.Update_base_property_on_derived_type(async);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(IsAsyncData))]
    public override Task Update_base_type_with_OfType(bool async)
    {
        return base.Update_base_type_with_OfType(async);
    }
}
