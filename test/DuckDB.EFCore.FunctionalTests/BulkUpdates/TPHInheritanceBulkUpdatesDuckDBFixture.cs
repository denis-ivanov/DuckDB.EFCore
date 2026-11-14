using Microsoft.EntityFrameworkCore.BulkUpdates.Inheritance;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class TPHInheritanceBulkUpdatesDuckDBFixture : TPHInheritanceBulkUpdatesFixture
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}
