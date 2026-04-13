using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Runtime.CompilerServices;

namespace DuckDB.EFCore.Extensions.DbFunctionsExtensions;

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
    /// <exception cref="InvalidOperationException"></exception>
    public static bool GreaterThan(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GreaterThan)));

    /// <summary>
    ///     Returns whether the row value represented by <paramref name="a" /> is less than the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool LessThan(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(LessThan)));

    /// <summary>
    ///     Returns whether the row value represented by <paramref name="a" /> is greater than or equal to the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool GreaterThanOrEqual(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GreaterThanOrEqual)));

    /// <summary>
    ///    Returns whether the row value represented by <paramref name="a" /> is less than or equal to the row value represented by <paramref name="b" />.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool LessThanOrEqual(this DbFunctions _, ITuple a, ITuple b)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(LessThanOrEqual)));
}
