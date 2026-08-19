using Microsoft.EntityFrameworkCore.Diagnostics;
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

    internal static readonly MethodInfo ArgFirstAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ArgFirstAggregate),
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

    internal static readonly MethodInfo ArgMinAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ArgMinAggregate) && m.GetParameters().Length == 1);

    internal static readonly MethodInfo ArgMinManyAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ArgMinAggregate) && m.GetParameters().Length == 2);

    internal static readonly MethodInfo ArgMinNullAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ArgMinNullAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BitAndAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(BitAndAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BitOrAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(BitOrAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BitXorAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(BitXorAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BoolAndAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(BoolAndAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BoolOrAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(BoolOrAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo CountIfAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(CountIfAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo FAvgAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(FAvgAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo FSumAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(FSumAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo HistogramAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(HistogramAggregate) && m.GetParameters().Length == 1);

    internal static readonly MethodInfo HistogramWithBoundariesAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(HistogramAggregate) && m.GetParameters().Length == 2);

    internal static readonly MethodInfo HistogramExactAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(HistogramExactAggregate) && m.GetParameters().Length == 2);

    internal static readonly MethodInfo GeometricMeanAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(GeometricMeanAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo BitStringAggAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(BitStringAggAggregate) && m.GetParameters().Length == 1);

    internal static readonly MethodInfo BitStringAggWithBoundsAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(BitStringAggAggregate) && m.GetParameters().Length == 3);

    /// <summary>
    /// Translates to the DuckDB <c>ANY_VALUE</c> aggregate function, returning an arbitrary value from the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult AnyValue<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AnyValue)));

    /// <summary>
    /// Translates to the DuckDB <c>FIRST</c> aggregate function, returning the first value selected in the group.
    /// Named <c>ArgFirst</c> to avoid ambiguity with <see cref="Enumerable.First{TSource}(IEnumerable{TSource})" />.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Which row is considered "first" depends on the order in which the database happens to produce the rows of
    /// the group. That order is not guaranteed, so the result is non-deterministic and may change between
    /// executions, across DuckDB versions, or when the query plan changes. This overload provides no way to
    /// specify an ordering, so use it only when any value from the group is acceptable.
    /// </para>
    /// <para>
    /// When a deterministic result is required, use <c>ArgMin</c> or <c>ArgMax</c> instead, which pick the value
    /// associated with the minimum or maximum of an explicit ordering key.
    /// </para>
    /// <para>
    /// Unlike most aggregates, <c>FIRST</c> does not skip nulls: it returns <see langword="null" /> when the first
    /// row of the group has a null value, so select a nullable type when the column is nullable.
    /// </para>
    /// </remarks>
    public static TResult ArgFirst<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgFirst)));

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MAX</c> aggregate function, returning the <paramref name="arg" /> value
    /// from the row with the maximum <paramref name="val" /> value in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg ArgMax<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMax)));

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
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMax)));

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
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMaxNull)));

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MIN</c> aggregate function, returning the <paramref name="arg" /> value
    /// from the row with the minimum <paramref name="val" /> value in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg ArgMin<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMin)));

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MIN</c> aggregate function, returning the <paramref name="arg" /> values
    /// from the <paramref name="n" /> rows with the smallest <paramref name="val" /> values in the group,
    /// ordered from the smallest to the largest.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg[] ArgMin<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val,
        int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMin)));

    /// <summary>
    /// Translates to the DuckDB <c>ARG_MIN_NULL</c> aggregate function, returning the <paramref name="arg" /> value
    /// from the row with the minimum <paramref name="val" /> value in the group. Unlike <see cref="ArgMin{TKey, TSource, TArg, TVal}(IGrouping{TKey, TSource}, Func{TSource, TArg}, Func{TSource, TVal})" />,
    /// rows where <paramref name="arg" /> is <see langword="null" /> are not ignored.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TArg? ArgMinNull<TKey, TSource, TArg, TVal>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TArg> arg,
        Func<TSource, TVal> val)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMinNull)));

    /// <summary>
    /// Translates to the DuckDB <c>BIT_AND</c> aggregate function, returning the bitwise <c>AND</c>
    /// of all values selected in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult BitAnd<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitAnd)));

    /// <summary>
    /// Translates to the DuckDB <c>BIT_OR</c> aggregate function, returning the bitwise <c>OR</c>
    /// of all values selected in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult BitOr<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitOr)));

    /// <summary>
    /// Translates to the DuckDB <c>BIT_XOR</c> aggregate function, returning the bitwise <c>XOR</c>
    /// of all values selected in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult BitXor<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitXor)));

    /// <summary>
    /// Translates to the DuckDB <c>BITSTRING_AGG</c> aggregate function, returning a bit string whose length
    /// corresponds to the range of the non-null values selected in the group, with bits set at the location
    /// of each distinct value.
    /// DuckDB requires column statistics for this overload; use the overload taking explicit bounds when they
    /// are not available.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static string BitStringAgg<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitStringAgg)));

    /// <summary>
    /// Translates to the DuckDB <c>BITSTRING_AGG</c> aggregate function, returning a bit string covering the
    /// <paramref name="min" />..<paramref name="max" /> range, with bits set at the location of each distinct
    /// non-null value selected in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static string BitStringAgg<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector,
        long min,
        long max)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitStringAgg)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM</c> aggregate function, returning a map of distinct values and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> Histogram<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Histogram)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM</c> aggregate function with boundaries, returning a map of buckets and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> Histogram<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector,
        TValue[] boundaries)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Histogram)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM_EXACT</c> aggregate function, returning a map of requested elements and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> HistogramExact<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector,
        TValue[] elements)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramExact)));

    /// <summary>
    /// Translates to the DuckDB <c>BOOL_AND</c> aggregate function, returning <see langword="true" /> if every
    /// non-null value selected in the group is <see langword="true" />.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static bool? BoolAnd<TKey, TSource>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, bool?> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BoolAnd)));

    /// <summary>
    /// Translates to the DuckDB <c>BOOL_OR</c> aggregate function, returning <see langword="true" /> if any
    /// non-null value selected in the group is <see langword="true" />.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static bool? BoolOr<TKey, TSource>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, bool?> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BoolOr)));

    /// <summary>
    /// Translates to the DuckDB <c>COUNTIF</c> aggregate function, returning the number of values selected
    /// in the group that are <see langword="true" />.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static long? CountIf<TKey, TSource>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, bool?> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(CountIf)));

    /// <summary>
    /// Translates to the DuckDB <c>FAVG</c> aggregate function, returning the average of all non-null values
    /// selected in the group using Kahan compensated summation, which is more accurate than <c>AVG</c> when
    /// the values differ widely in magnitude.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static double? FAvg<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FAvg)));

    /// <summary>
    /// Translates to the DuckDB <c>FSUM</c> aggregate function, returning the sum of all non-null values
    /// selected in the group using Kahan compensated summation, which is more accurate than <c>SUM</c> when
    /// the values differ widely in magnitude.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static double? FSum<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FSum)));

    /// <summary>
    /// Translates to the DuckDB <c>GEOMETRIC_MEAN</c> aggregate function, returning the geometric mean of all
    /// non-null values selected in the group.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    /// <remarks>
    /// The geometric mean is computed via logarithms, so DuckDB raises an error when any of the aggregated values
    /// are zero or negative. Filter the query or the selector so that only positive values reach the aggregate.
    /// </remarks>
    public static double? GeometricMean<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GeometricMean)));

    // Marker methods the provider rewrites the public grouping methods into, so that the selectors
    // become regular projections over the grouping which EF can translate into aggregates.
    internal static TSource AnyValueAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AnyValueAggregate)));

    internal static TSource ArgFirstAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgFirstAggregate)));

    internal static TArg ArgMaxAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMaxAggregate)));

    internal static TArg[] ArgMaxAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source, int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMaxAggregate)));

    internal static TArg ArgMaxNullAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMaxNullAggregate)));

    internal static TArg ArgMinAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMinAggregate)));

    internal static TArg[] ArgMinAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source, int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMinAggregate)));

    internal static TArg ArgMinNullAggregate<TArg, TVal>(IEnumerable<ValueTuple<TArg, TVal>> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ArgMinNullAggregate)));

    internal static TSource BitAndAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitAndAggregate)));

    internal static TSource BitOrAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitOrAggregate)));

    internal static TSource BitXorAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitXorAggregate)));

    internal static string BitStringAggAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitStringAggAggregate)));

    internal static string BitStringAggAggregate<TValue>(IEnumerable<TValue> source, long min, long max)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BitStringAggAggregate)));

    internal static bool? BoolAndAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BoolAndAggregate)));

    internal static bool? BoolOrAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(BoolOrAggregate)));

    internal static long? CountIfAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(CountIfAggregate)));

    internal static double? FAvgAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FAvgAggregate)));

    internal static double? FSumAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FSumAggregate)));

    internal static double? GeometricMeanAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(GeometricMeanAggregate)));

    internal static Dictionary<TValue, ulong> HistogramAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramAggregate)));

    internal static Dictionary<TValue, ulong> HistogramAggregate<TValue>(IEnumerable<TValue> source, TValue[] boundaries)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramAggregate)));

    internal static Dictionary<TValue, ulong> HistogramExactAggregate<TValue>(IEnumerable<TValue> source, TValue[] elements)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramExactAggregate)));
}
