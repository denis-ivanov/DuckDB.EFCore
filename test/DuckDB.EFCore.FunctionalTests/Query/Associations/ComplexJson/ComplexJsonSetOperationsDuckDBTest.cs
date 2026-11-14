using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;

public class ComplexJsonSetOperationsDuckDBTest: ComplexJsonSetOperationsRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonSetOperationsDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd), MemberData(nameof(TrackingData))]
    public override async Task Over_assocate_collection_Select_nested_with_aggregates_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_assocate_collection_Select_nested_with_aggregates_projected(queryTrackingBehavior);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Over_associate_collections()
    {
        await base.Over_associate_collections();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Over_nested_associate_collection()
    {
        await base.Over_nested_associate_collection();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [MemberData(nameof(TrackingData))]
    public override Task Over_associate_collection_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Over_associate_collection_projected(queryTrackingBehavior);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Over_different_collection_properties()
    {
        return base.Over_different_collection_properties();
    }
}
