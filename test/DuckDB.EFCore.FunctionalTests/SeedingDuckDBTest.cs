using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class SeedingDuckDBTest : SeedingTestBase
{
    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Seeding_does_not_leave_context_contaminated(bool async)
    {
        await base.Seeding_does_not_leave_context_contaminated(async);
    }

    protected override TestStore TestStore
        => DuckDBTestStore.Create("SeedingTest");

    protected override SeedingContext CreateContextWithEmptyDatabase(string testId)
        => new SeedingDuckDBContext(testId);

    protected class SeedingDuckDBContext(string testId) : SeedingContext(testId)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseDuckDB(($"Data Source = Seeds{TestId}.db"));
    }
}
