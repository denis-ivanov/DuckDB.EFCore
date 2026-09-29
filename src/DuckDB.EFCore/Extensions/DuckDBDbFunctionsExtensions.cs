using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

/// <summary>
///     Provides DuckDB-specific extension methods for <see cref="DbFunctions" />.
/// </summary>
public static class DuckDBDbFunctionsExtensions
{
    /// <summary>
    ///     Returns whether the row value represented by <paramref name="a" /> is greater than the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool GreaterThan(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GreaterThan)));

    /// <summary>
    ///     Returns whether the row value represented by <paramref name="a" /> is less than the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool LessThan(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(LessThan)));

    /// <summary>
    ///     Returns whether the row value represented by <paramref name="a" /> is greater than or equal to the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool GreaterThanOrEqual(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GreaterThanOrEqual)));

    /// <summary>
    ///    Returns whether the row value represented by <paramref name="a" /> is less than or equal to the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool LessThanOrEqual(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(LessThanOrEqual)));

    /// <summary>
    ///    Converts timestamps or dates to strings according to the specified pattern.
    /// </summary>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="timestamp">The timestamp or date to format.</param>
    /// <param name="format">The format specifier string.</param>
    /// <returns>A string formatted according to the format specifier.</returns>
    /// <see href="https://duckdb.org/docs/current/sql/functions/dateformat#strftime-examples"/>
    public static string? Strftime(this DbFunctions _, DateOnly? timestamp, string? format)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Strftime)));

    /// <summary>
    ///    Converts timestamps or dates to strings according to the specified pattern.
    /// </summary>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="timestamp">The timestamp or date to format.</param>
    /// <param name="format">The format specifier string.</param>
    /// <returns>A string formatted according to the format specifier.</returns>
    /// <see href="https://duckdb.org/docs/current/sql/functions/dateformat#strftime-examples"/>
    public static string? Strftime(this DbFunctions _, DateTime? timestamp, string? format)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Strftime)));

    /// <summary>
    ///    Converts timestamps or dates to strings according to the specified pattern.
    /// </summary>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="timestamp">The timestamp or date to format.</param>
    /// <param name="format">The format specifier string.</param>
    /// <returns>A string formatted according to the format specifier.</returns>
    /// <see href="https://duckdb.org/docs/current/sql/functions/dateformat#strftime-examples"/>
    public static string? Strftime(this DbFunctions _, DateTimeOffset? timestamp, string? format)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Strftime)));
}
