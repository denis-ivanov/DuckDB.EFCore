using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace DuckDB.EFCore.FunctionalTests;

public class NotificationEntitiesDuckDBTest : NotificationEntitiesTestBase<NotificationEntitiesDuckDBTest.NotificationEntitiesDuckDBFixture>
{
    public NotificationEntitiesDuckDBTest(NotificationEntitiesDuckDBFixture fixture) : base(fixture)
    {
    }

    public class NotificationEntitiesDuckDBFixture : NotificationEntitiesFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
