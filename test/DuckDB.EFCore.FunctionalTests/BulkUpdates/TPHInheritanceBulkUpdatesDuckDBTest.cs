using Microsoft.EntityFrameworkCore.BulkUpdates.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPHInheritanceBulkUpdatesDuckDBTest : TPHInheritanceBulkUpdatesTestBase<TPHInheritanceBulkUpdatesDuckDBFixture>
{
    public TPHInheritanceBulkUpdatesDuckDBTest(TPHInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
