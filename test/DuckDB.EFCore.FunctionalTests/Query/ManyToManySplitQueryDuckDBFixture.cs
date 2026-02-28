using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class ManyToManySplitQueryDuckDBFixture : ManyToManyQueryDuckDBFixture
{
    protected override string StoreName
        => "ManyToManySplitQuery";

    public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
        => base.AddOptions(builder.UseDuckDB(b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
}
