using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Infrastructure;

public class DuckDBDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<DuckDBDbContextOptionsBuilder, DuckDBOptionsExtension>
{
    public DuckDBDbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        : base(optionsBuilder)
    {
    }

    internal virtual DuckDBDbContextOptionsBuilder ReverseNullOrdering(bool reverseNullOrdering = true)
        => WithOption(e => e.WithReverseNullOrdering(reverseNullOrdering));
}
