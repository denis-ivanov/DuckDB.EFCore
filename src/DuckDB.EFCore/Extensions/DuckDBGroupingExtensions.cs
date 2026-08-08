using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Extension methods for grouping aggregations supported by the DuckDB provider.
/// These are marker methods for LINQ translation and are not intended to be executed on the client.
/// </summary>
public static class DuckDBGroupingExtensions
{
    internal static readonly MethodInfo AnyValueAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(AnyValueAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    /// <summary>
    /// Translates to the DuckDB <c>ANY_VALUE</c> aggregate function.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult AnyValue<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(
            "AnyValue is for use in LINQ queries only and cannot be evaluated on the client.");

    // Marker method the provider rewrites 'grouping.AnyValue(selector)' into, so that the selector
    // becomes a regular projection over the grouping which EF can translate into an aggregate.
    internal static TSource AnyValueAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(
            "AnyValue is for use in LINQ queries only and cannot be evaluated on the client.");
}
