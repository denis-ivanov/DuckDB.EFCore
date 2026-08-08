using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Extension methods for grouping aggregations supported by the DuckDB provider.
/// These are marker methods for LINQ translation and are not intended to be executed on the client.
/// </summary>
public static class DuckDBGroupingExtensions
{
    private const string ClientEvaluationMessage
        = "This method is for use in LINQ queries only and cannot be evaluated on the client.";

    internal static readonly MethodInfo AnyValueAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(AnyValueAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo ArgMaxAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ArgMaxAggregate) && m.GetParameters().Length == 1);

    internal static readonly MethodInfo ArgMaxManyAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ArgMaxAggregate) && m.GetParameters().Length == 2);

    internal static readonly MethodInfo ArgMaxNullAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ArgMaxNullAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    /// <summary>
    /// Translates to the DuckDB <c>ANY_VALUE</c> aggregate function, returning an arbitrary value from the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult AnyValue<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MAX</c> aggregate function, returning the <paramref name="arg" /> value
    /// from the row with the maximum <paramref name="val" /> value in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg ArgMax<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MAX</c> aggregate function, returning the <paramref name="arg" /> values
    /// from the <paramref name="n" /> rows with the largest <paramref name="val" /> values in the group,
    /// ordered from the largest to the smallest.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg[] ArgMax<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val,
        int n)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MAX_NULL</c> aggregate function, returning the <paramref name="arg" /> value
    /// from the row with the maximum <paramref name="val" /> value in the group. Unlike <see cref="ArgMax{TKey, TSource, TArg, TVal}(IGrouping{TKey, TSource}, Func{TSource, TArg}, Func{TSource, TVal})" />,
    /// rows where <paramref name="arg" /> is <see langword="null" /> are not ignored.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg? ArgMaxNull<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    // Marker methods the provider rewrites the public grouping methods into, so that the selectors
    // become regular projections over the grouping which EF can translate into aggregates.
    internal static TSource AnyValueAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    internal static TArg ArgMaxAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    internal static TArg[] ArgMaxAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source, int n)
        => throw new InvalidOperationException(ClientEvaluationMessage);

    internal static TArg ArgMaxNullAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(ClientEvaluationMessage);
}
