using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Internal;

public class DuckDBSingletonOptions : IDuckDBSingletonOptions
{
    public virtual bool ReverseNullOrderingEnabled { get; private set; }

    public void Initialize(IDbContextOptions options)
    {
        var duckDbOptions = options.FindExtension<DuckDBOptionsExtension>() ?? new DuckDBOptionsExtension();

        ReverseNullOrderingEnabled = duckDbOptions.ReverseNullOrdering;
    }

    public void Validate(IDbContextOptions options)
    {
        var duckDbOptions = options.FindExtension<DuckDBOptionsExtension>() ?? new DuckDBOptionsExtension();

        if (duckDbOptions.ReverseNullOrdering != ReverseNullOrderingEnabled)
        {
            throw new InvalidOperationException();
        }
    }
}
