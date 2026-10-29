using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsStructuralEqualityDuckDBTest: OwnedNavigationsStructuralEqualityRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsStructuralEqualityDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
