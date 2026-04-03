using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsPrimitiveCollectionDuckDBTest : NavigationsPrimitiveCollectionRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsPrimitiveCollectionDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}
