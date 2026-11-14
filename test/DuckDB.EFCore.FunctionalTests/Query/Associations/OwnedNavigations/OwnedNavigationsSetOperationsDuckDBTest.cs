using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;

public class OwnedNavigationsSetOperationsDuckDBTest : OwnedNavigationsSetOperationsRelationalTestBase<OwnedNavigationsDuckDBFixture>
{
    public OwnedNavigationsSetOperationsDuckDBTest(OwnedNavigationsDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [MemberData(nameof(TrackingData))]
    public override async Task Over_associate_collection_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_associate_collection_projected(queryTrackingBehavior);
    }
}
