using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsCollectionDuckDBTest : OwnedNavigationsCollectionRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsCollectionDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
