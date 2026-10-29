using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsMiscellaneousDuckDBTest: OwnedNavigationsMiscellaneousRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsMiscellaneousDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
