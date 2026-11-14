using Microsoft.EntityFrameworkCore.BulkUpdates.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPCFiltersInheritanceBulkUpdatesDuckDBTest : TPCFiltersInheritanceBulkUpdatesTestBase<TPCFiltersInheritanceBulkUpdatesDuckDBFixture>
{
    public TPCFiltersInheritanceBulkUpdatesDuckDBTest(TPCFiltersInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    protected override void ClearLog()
    {
        Fixture.TestSqlLoggerFactory.Clear();
    }
}
