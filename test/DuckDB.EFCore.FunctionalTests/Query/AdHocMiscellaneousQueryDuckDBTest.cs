using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocMiscellaneousQueryDuckDBTest : AdHocMiscellaneousQueryRelationalTestBase
{
    public AdHocMiscellaneousQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Correlated_SelectMany_DefaultIfEmpty_whole_object()
    {
        await base.Correlated_SelectMany_DefaultIfEmpty_whole_object();
    }

    protected override DbContextOptionsBuilder SetParameterizedCollectionMode(
        DbContextOptionsBuilder optionsBuilder,
        ParameterTranslationMode parameterizedCollectionMode)
    {
        new DuckDBDbContextOptionsBuilder(optionsBuilder).UseParameterizedCollectionMode(parameterizedCollectionMode);

        return optionsBuilder;
    }

    protected override async Task Seed2951(Context2951 context)
    {
        await context.Database.ExecuteSqlRawAsync(
            """
            CREATE TABLE ZeroKey (Id int);
            INSERT INTO ZeroKey VALUES (NULL)
            """);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Mapping_JsonElement_property_throws_a_meaningful_exception()
    {
        return base.Mapping_JsonElement_property_throws_a_meaningful_exception();
    }

    protected override async Task Seed30915(Context30915 context)
    {
        context.Statuses.AddRange(
            new Context30915.PickupStatus30915 { PickupStatusId = 1, Name = "Active" },
            new Context30915.PickupStatus30915 { PickupStatusId = 2, Name = "NoRequests" },
            new Context30915.PickupStatus30915 { PickupStatusId = 3, Name = "Busy" });

        context.Requests.AddRange(
            new Context30915.PickupRequest30915 { PickupStatusId = 1, Priority = 5 },
            new Context30915.PickupRequest30915 { PickupStatusId = 1, Priority = null },
            new Context30915.PickupRequest30915 { PickupStatusId = 3, Priority = 7 });

        await context.SaveChangesAsync();
    }

    protected override ITestStoreFactory NonSharedTestStoreFactory => DuckDBTestStoreFactory.Instance;
}
