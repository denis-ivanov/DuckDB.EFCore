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

    /// <summary>
    /// Returns <c>true</c> if the date is finite, <c>false</c> otherwise.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns><c>true</c> if the date is finite, <c>false</c> otherwise.</returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#isfinitedate"/>
    public static bool? IsFinite(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(IsFinite)));

    /// <summary>
    /// Returns <c>true</c> if the date is infinite, <c>false</c> otherwise.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns><c>true</c> if the date is infinite, <c>false</c> otherwise.</returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#isinfdate"/>
    public static bool? IsInfinite(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(IsInfinite)));

    /// <summary>
    /// Extract the Julian Day number from a date.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#juliandate"/>
    public static double? Julian(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Julian)));

    /// <summary>
    /// The last day of the corresponding month in the date.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#last_daydate"/>
    public static DateOnly? LastDay(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(LastDay)));

    /// <summary>
    /// The (English) name of the month.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/date#monthnamedate"/>
    public static string? MonthName(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(MonthName)));

    /// <summary>
    /// Extract the century from a date.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/datepart#centurydate"/>
    public static int? Century(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Century)));
    
    /// <summary>
    /// Decade (year / 10).
    /// </summary>
    /// <param name="_"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/datepart#decadedate"/>
    public static int? Decade(this DbFunctions _, DateOnly? date)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Decade)));
    
    /// <summary>
    /// Extension of Levenshtein distance to also include transposition of adjacent characters as an allowed edit
    /// operation. In other words, the minimum number of edit operations (insertions, deletions, substitutions or
    /// transpositions) required to change one string to another. Characters of different cases (e.g., a and A) are
    /// considered different.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#damerau_levenshteins1-s2"/>
    public static int? DamerauLevenshtein(this DbFunctions _, string? s1, string? s2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DamerauLevenshtein)));

    /// <summary>
    /// The Hamming distance between two strings, i.e., the number of positions with different characters for two
    /// strings of equal length. Strings must be of equal length. Characters of different cases (e.g., a and A)
    /// are considered different.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#hammings1-s2"/>
    public static int? Hamming(this DbFunctions _, string? s1, string? s2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Hamming)));

    /// <summary>
    /// The Jaccard similarity between two strings. Characters of different cases (e.g., a and A) are considered
    /// different. Returns a number between 0 and 1.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#jaccards1-s2"/>
    public static double? Jaccard(this DbFunctions _, string? s1, string? s2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Jaccard)));

    /// <summary>
    /// The minimum number of single-character edits (insertions, deletions or substitutions) required to change
    /// one string to the other. Characters of different cases (e.g., a and A) are considered different.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static int? Levenshtein(this DbFunctions _, string? s1, string? s2)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Levenshtein)));

    /// <summary>
    /// Returns the MD5 hash of the string as a HUGEINT
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#md5_numberstring"/>
    public static long? Md5Number(this DbFunctions _, string? s)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Md5Number)));

    /// <summary>
    /// Returns the lower 64-bit segment of the MD5 hash of the string as a UBIGINT.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#md5_number_lowerstring"/>
    public static ulong? Md5NumberLower(this DbFunctions _, string? s)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Md5NumberLower)));

    /// <summary>
    /// Returns the upper 64-bit segment of the MD5 hash of the string as a UBIGINT
    /// </summary>
    /// <param name="_"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#md5_number_upperstring"/>
    public static ulong? Md5NumberUpper(this DbFunctions _, string? s)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Md5NumberUpper)));

    /// <summary>
    /// Returns false if the string matches the like_specifier (see Pattern Matching) using case-insensitive matching.
    /// escape_character is used to search for wildcard characters in the string.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="str"></param>
    /// <param name="likeSpecifier"></param>
    /// <param name="escapeCharacter"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#not_ilike_escapestring-like_specifier-escape_character"/>
    public static bool? NotILikeEscape(this DbFunctions _, string? str, string? likeSpecifier, string? escapeCharacter)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(NotILikeEscape)));

    /// <summary>
    /// Returns false if the string matches the like_specifier (see Pattern Matching) using case-sensitive matching.
    /// escape_character is used to search for wildcard characters in the string.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="str"></param>
    /// <param name="likeSpecifier"></param>
    /// <param name="escapeCharacter"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#not_like_escapestring-like_specifier-escape_character"/>
    public static bool? NotLikeEscape(this DbFunctions _, string? str, string? likeSpecifier, string? escapeCharacter)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(NotLikeEscape)));

    /// <summary>
    /// Extracts the left-most count characters.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="str"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    /// <see cref="https://duckdb.org/docs/current/sql/functions/text#leftstring-count"/>
    public static string? Left(this DbFunctions _, string? str, int? length)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Left)));
}
