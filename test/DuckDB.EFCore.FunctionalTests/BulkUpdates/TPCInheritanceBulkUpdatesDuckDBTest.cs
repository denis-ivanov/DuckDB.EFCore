using Microsoft.EntityFrameworkCore.BulkUpdates;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.BulkUpdates;

public class TPCInheritanceBulkUpdatesDuckDBTest : TPCInheritanceBulkUpdatesTestBase<TPCInheritanceBulkUpdatesDuckDBFixture>
{
    public TPCInheritanceBulkUpdatesDuckDBTest(TPCInheritanceBulkUpdatesDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
