using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.Navigations;

public class NavigationsCollectionDuckDBTest: NavigationsCollectionRelationalTestBase<NavigationsDuckDBFixture>
{
    public NavigationsCollectionDuckDBTest(NavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Distinct_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Distinct_projected(queryTrackingBehavior);
    }
}