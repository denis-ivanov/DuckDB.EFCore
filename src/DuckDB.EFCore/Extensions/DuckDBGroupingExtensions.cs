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

    internal static readonly MethodInfo ApproxCountDistinctAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ApproxCountDistinctAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo ApproxQuantileAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ApproxQuantileAggregate) && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType == typeof(double));

    internal static readonly MethodInfo ApproxQuantileArrayAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ApproxQuantileAggregate) && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType == typeof(float[]));

    internal static readonly MethodInfo ApproxTopKAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ApproxTopKAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo ReservoirQuantileAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ReservoirQuantileAggregate) && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType == typeof(double));

    internal static readonly MethodInfo ReservoirQuantileWithSizeAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ReservoirQuantileAggregate) && m.GetParameters().Length == 3 && m.GetParameters()[1].ParameterType == typeof(double));

    internal static readonly MethodInfo ReservoirQuantileArrayAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ReservoirQuantileAggregate) && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType == typeof(float[]));

    internal static readonly MethodInfo ReservoirQuantileArrayWithSizeAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name == nameof(ReservoirQuantileAggregate) && m.GetParameters().Length == 3 && m.GetParameters()[1].ParameterType == typeof(float[]));

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

    internal static readonly MethodInfo MaxAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(MaxAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo MinAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(MinAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo GeometricMeanAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(GeometricMeanAggregate),
            BindingFlags.NonPublic | BindingFlags.Static)!;

    internal static readonly MethodInfo ProductAggregateMethod
        = typeof(DuckDBGroupingExtensions).GetMethod(
            nameof(ProductAggregate),
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
    /// Translates to the DuckDB <c>APPROX_COUNT_DISTINCT</c> aggregate function, returning the approximate number of unique elements.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static long ApproxCountDistinct<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxCountDistinct)));

    /// <summary>
    /// Translates to the DuckDB <c>APPROX_QUANTILE</c> aggregate function, returning the approximate quantile
    /// of all non-null values selected in the group at the specified position using T-Digest.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult ApproxQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        double pos)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxQuantile)));

    /// <summary>
    /// Translates to the DuckDB <c>APPROX_QUANTILE</c> aggregate function, returning the approximate quantiles
    /// of all non-null values selected in the group at the specified positions using T-Digest.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] ApproxQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        float[] pos)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxQuantile)));

    /// <summary>
    /// Translates to the DuckDB <c>APPROX_TOP_K</c> aggregate function, returning the <paramref name="k" /> approximately
    /// most frequent values selected in the group.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] ApproxTopK<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        int k)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxTopK)));

    /// <summary>
    /// Translates to the DuckDB <c>RESERVOIR_QUANTILE</c> aggregate function, returning the approximate quantile
    /// of all non-null values selected in the group using reservoir sampling.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult ReservoirQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        double quantile)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantile)));

    /// <summary>
    /// Translates to the DuckDB <c>RESERVOIR_QUANTILE</c> aggregate function, returning the approximate quantile
    /// of all non-null values selected in the group using reservoir sampling with the specified sample size.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult ReservoirQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        double quantile,
        int sampleSize)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantile)));

    /// <summary>
    /// Translates to the DuckDB <c>RESERVOIR_QUANTILE</c> aggregate function, returning the approximate quantiles
    /// of all non-null values selected in the group at the specified positions using reservoir sampling.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] ReservoirQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        float[] quantile)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantile)));

    /// <summary>
    /// Translates to the DuckDB <c>RESERVOIR_QUANTILE</c> aggregate function, returning the approximate quantiles
    /// of all non-null values selected in the group at the specified positions using reservoir sampling with the specified sample size.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] ReservoirQuantile<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        float[] quantile,
        int sampleSize)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantile)));

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
    /// Translates to the DuckDB <c>MAX</c> aggregate function, returning the <paramref name="n" /> largest
    /// values selected in the group in descending order.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] Max<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Max)));

    /// <summary>
    /// Translates to the DuckDB <c>MIN</c> aggregate function, returning the <paramref name="n" /> smallest
    /// values selected in the group in ascending order.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static TResult[] Min<TKey, TSource, TResult>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TResult> selector,
        int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Min)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM</c> aggregate function, returning a map of distinct values and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> Histogram<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector) where TValue : notnull
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Histogram)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM</c> aggregate function with boundaries, returning a map of buckets and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> Histogram<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector,
        TValue[] boundaries) where TValue : notnull
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Histogram)));

    /// <summary>
    /// Translates to the DuckDB <c>HISTOGRAM_EXACT</c> aggregate function, returning a map of requested elements and their counts.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static Dictionary<TValue, ulong> HistogramExact<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector,
        TValue[] elements) where TValue : notnull
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

    /// <summary>
    /// Translates to the DuckDB <c>PRODUCT</c> aggregate function, returning the product of all
    /// non-null values selected in the group.
    /// Returns <see langword="null" /> when the group contains no non-null values.
    /// Can only be used in LINQ queries; calling it on the client throws.
    /// </summary>
    public static double? Product<TKey, TSource, TValue>(
        this IGrouping<TKey, TSource> source,
        Func<TSource, TValue> selector)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Product)));

    // Marker methods the provider rewrites the public grouping methods into, so that the selectors
    // become regular projections over the grouping which EF can translate into aggregates.
    internal static TSource AnyValueAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AnyValueAggregate)));

    internal static long ApproxCountDistinctAggregate<TSource>(IEnumerable<TSource> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxCountDistinctAggregate)));

    internal static TResult ApproxQuantileAggregate<TResult>(IEnumerable<TResult> source, double pos)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxQuantileAggregate)));

    internal static TResult[] ApproxQuantileAggregate<TResult>(IEnumerable<TResult> source, float[] pos)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxQuantileAggregate)));

    internal static TResult[] ApproxTopKAggregate<TResult>(IEnumerable<TResult> source, int k)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ApproxTopKAggregate)));

    internal static TResult ReservoirQuantileAggregate<TResult>(IEnumerable<TResult> source, double quantile)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantileAggregate)));

    internal static TResult ReservoirQuantileAggregate<TResult>(IEnumerable<TResult> source, double quantile, int sampleSize)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantileAggregate)));

    internal static TResult[] ReservoirQuantileAggregate<TResult>(IEnumerable<TResult> source, float[] quantile)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantileAggregate)));

    internal static TResult[] ReservoirQuantileAggregate<TResult>(IEnumerable<TResult> source, float[] quantile, int sampleSize)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ReservoirQuantileAggregate)));

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

    internal static double? ProductAggregate<TValue>(IEnumerable<TValue> source)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(ProductAggregate)));

    internal static Dictionary<TValue, ulong> HistogramAggregate<TValue>(IEnumerable<TValue> source)
        where TValue : notnull
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramAggregate)));

    internal static Dictionary<TValue, ulong> HistogramAggregate<TValue>(IEnumerable<TValue> source, TValue[] boundaries)
        where TValue : notnull
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramAggregate)));

    internal static Dictionary<TValue, ulong> HistogramExactAggregate<TValue>(IEnumerable<TValue> source, TValue[] elements)
        where TValue : notnull
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(HistogramExactAggregate)));

    internal static TResult[] MaxAggregate<TResult>(IEnumerable<TResult> source, int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(MaxAggregate)));

    internal static TResult[] MinAggregate<TResult>(IEnumerable<TResult> source, int n)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(MinAggregate)));
}
