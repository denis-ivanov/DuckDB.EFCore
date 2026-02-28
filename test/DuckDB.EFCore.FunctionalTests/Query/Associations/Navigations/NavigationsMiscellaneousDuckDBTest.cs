using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsMiscellaneousDuckDBTest: NavigationsMiscellaneousRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsMiscellaneousDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
}