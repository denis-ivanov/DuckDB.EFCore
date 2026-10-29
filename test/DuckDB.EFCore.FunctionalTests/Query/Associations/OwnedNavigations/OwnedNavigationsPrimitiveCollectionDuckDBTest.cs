using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsPrimitiveCollectionDuckDBTest : OwnedNavigationsPrimitiveCollectionRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsPrimitiveCollectionDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
