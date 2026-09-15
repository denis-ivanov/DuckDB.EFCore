using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPHInheritanceBulkUpdatesDuckDBTest : TPHInheritanceBulkUpdatesTestBase<TPHInheritanceBulkUpdatesDuckDBFixture>
{
    public TPHInheritanceBulkUpdatesDuckDBTest(TPHInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
