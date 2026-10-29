using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query.Associations.Navigations;

public class NavigationsProjectionDuckDBTest : NavigationsProjectionRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsProjectionDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
