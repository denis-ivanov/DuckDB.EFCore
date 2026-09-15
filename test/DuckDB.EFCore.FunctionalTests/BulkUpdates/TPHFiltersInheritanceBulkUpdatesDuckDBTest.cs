using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPHFiltersInheritanceBulkUpdatesDuckDBTest : FiltersInheritanceBulkUpdatesRelationalTestBase<TPHFiltersInheritanceBulkUpdatesDuckDBFixture>
{
    public TPHFiltersInheritanceBulkUpdatesDuckDBTest(TPHFiltersInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    protected override void ClearLog()
    {
        Fixture.TestSqlLoggerFactory.Clear();
    }
}
