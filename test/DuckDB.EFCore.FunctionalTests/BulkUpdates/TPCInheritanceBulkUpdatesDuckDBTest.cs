using Microsoft.EntityFrameworkCore.BulkUpdates.Inheritance;
using Xunit;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPCInheritanceBulkUpdatesDuckDBTest : TPCInheritanceBulkUpdatesTestBase<TPCInheritanceBulkUpdatesDuckDBFixture>
{
    public TPCInheritanceBulkUpdatesDuckDBTest(TPCInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
