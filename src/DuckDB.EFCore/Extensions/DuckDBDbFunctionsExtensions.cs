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

    /// <summary>
    ///     Converts strings to timestamps according to the specified pattern.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="text"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/dateformat#strptime-examples"/>
    public static DateTime? Strptime(this DbFunctions _, string? text, string? format)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Strptime)));

    /// <summary>
    /// 	The (English) name of the weekday.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#daynamedate"/>
    public static string? DayName(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DayName)));

    /// <summary>
    /// The number of days in the month of the given date.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#days_in_monthdate"/>
    public static int? DaysInMonth(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DaysInMonth)));

    /// <summary>
    /// The later of two dates.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#greatestdate-date"/>
    public static DateOnly? Greatest(this DbFunctions _, DateOnly? date1, DateOnly? date2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Greatest)));
}
