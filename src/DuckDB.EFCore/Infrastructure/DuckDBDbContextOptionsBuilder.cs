using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Infrastructure;

/// <summary>
///     Allows DuckDB specific configuration to be performed on <see cref="DbContextOptions" />.
/// </summary>
/// <remarks>
///     <para>
///         Instances of this class are returned from a call to
///         <see cref="DuckDBDbContextOptionsBuilderExtensions.UseDuckDB(DbContextOptionsBuilder, string, System.Action{DuckDBDbContextOptionsBuilder})" />
///         and it is not designed to be directly constructed in your application code.
///     </para>
///     <para>
///         See <see href="https://aka.ms/efcore-docs-dbcontext-options">Using DbContextOptions</see>.
///     </para>
/// </remarks>
public class DuckDBDbContextOptionsBuilder : RelationalDbContextOptionsBuilder<DuckDBDbContextOptionsBuilder, DuckDBOptionsExtension>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DuckDBDbContextOptionsBuilder" /> class.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    public DuckDBDbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        : base(optionsBuilder)
    {
    }

    /// <summary>
    ///     Appends NULLS FIRST to all ORDER BY clauses. This is important for the tests which were written
    ///     for SQL Server. Note that to fully implement null-first ordering indexes also need to be generated
    ///     accordingly, and since this isn't done this feature isn't publicly exposed.
    /// </summary>
    /// <param name="reverseNullOrdering">True to enable reverse null ordering; otherwise, false.</param>
    internal virtual DuckDBDbContextOptionsBuilder ReverseNullOrdering(bool reverseNullOrdering = true)
        => WithOption(e => e.WithReverseNullOrdering(reverseNullOrdering));
}
