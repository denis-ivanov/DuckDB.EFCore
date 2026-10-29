using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsProjectionDuckDBTest : OwnedNavigationsProjectionRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsProjectionDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
