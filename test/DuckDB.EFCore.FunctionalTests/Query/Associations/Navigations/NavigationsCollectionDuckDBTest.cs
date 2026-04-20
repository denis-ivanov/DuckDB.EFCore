using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsCollectionDuckDBTest: NavigationsCollectionRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsCollectionDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
