using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class AdHocMiscellaneousQueryDuckDBTest : AdHocMiscellaneousQueryRelationalTestBase
{
    public AdHocMiscellaneousQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

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

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Mapping_JsonElement_property_throws_a_meaningful_exception()
    {
        return base.Mapping_JsonElement_property_throws_a_meaningful_exception();
    }
}
