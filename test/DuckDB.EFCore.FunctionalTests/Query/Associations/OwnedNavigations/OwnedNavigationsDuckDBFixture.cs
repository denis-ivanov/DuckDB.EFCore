using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.OwnedNavigations;

public class OwnedNavigationsDuckDBFixture : OwnedNavigationsRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
}
