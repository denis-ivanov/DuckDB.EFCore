using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBSingletonOptions : IDuckDBSingletonOptions
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual bool ReverseNullOrderingEnabled { get; private set; }

    /// <inheritdoc />
    public void Initialize(IDbContextOptions options)
    {
        var duckDbOptions = options.FindExtension<DuckDBOptionsExtension>() ?? new DuckDBOptionsExtension();

        ReverseNullOrderingEnabled = duckDbOptions.ReverseNullOrdering;
    }

    /// <inheritdoc />
    public void Validate(IDbContextOptions options)
    {
        var duckDbOptions = options.FindExtension<DuckDBOptionsExtension>() ?? new DuckDBOptionsExtension();

        if (duckDbOptions.ReverseNullOrdering != ReverseNullOrderingEnabled)
        {
            throw new InvalidOperationException();
        }
    }
}
