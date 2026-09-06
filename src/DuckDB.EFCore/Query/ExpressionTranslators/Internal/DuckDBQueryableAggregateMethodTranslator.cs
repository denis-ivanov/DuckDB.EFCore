using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQueryableAggregateMethodTranslator : IAggregateMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBQueryableAggregateMethodTranslator(ISqlExpressionFactory sqlExpressionFactory) 
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        MethodInfo method,
        EnumerableExpression source,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType == typeof(Queryable))
        {
            var methodInfo = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : method;
            switch (methodInfo.Name)
            {
                case nameof(Queryable.Average)
                    when (QueryableMethods.IsAverageWithoutSelector(methodInfo)
                          || QueryableMethods.IsAverageWithSelector(methodInfo))
                         && source.Selector is SqlExpression averageSqlExpression:
                    var averageInputType = averageSqlExpression.Type;

                    if (averageInputType == typeof(int) || averageInputType == typeof(long))
                    {
                        averageSqlExpression = _sqlExpressionFactory.ApplyDefaultTypeMapping(
                            _sqlExpressionFactory.Convert(averageSqlExpression, typeof(double)));
                    }

                    averageSqlExpression = CombineTerms(source, averageSqlExpression);

                    if (averageInputType == typeof(decimal))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "AVG",
                                [averageSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(decimal)),
                            averageSqlExpression.Type,
                            averageSqlExpression.TypeMapping);
                    }

                    if (averageInputType == typeof(float))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "AVG",
                                [averageSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(float)),
                            averageSqlExpression.Type,
                            averageSqlExpression.TypeMapping);
                    }

                    return _sqlExpressionFactory.Function(
                        "AVG",
                        [averageSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        averageSqlExpression.Type,
                        averageSqlExpression.TypeMapping);

                case nameof(Queryable.Count)
                    when methodInfo == QueryableMethods.CountWithoutPredicate
                         || methodInfo == QueryableMethods.CountWithPredicate:
                    var countSqlExpression = (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    countSqlExpression = CombineTerms(source, countSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "COUNT",
                        [countSqlExpression],
                        nullable: false,
                        argumentsPropagateNullability: [false],
                        typeof(int));

                case nameof(Queryable.LongCount)
                    when methodInfo == QueryableMethods.LongCountWithoutPredicate
                         || methodInfo == QueryableMethods.LongCountWithPredicate:
                    var longCountSqlExpression =
                        (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    longCountSqlExpression = CombineTerms(source, longCountSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "COUNT",
                        [longCountSqlExpression],
                        nullable: false,
                        argumentsPropagateNullability: [false],
                        typeof(long));

                case nameof(Queryable.Max)
                    when (methodInfo == QueryableMethods.MaxWithoutSelector
                          || methodInfo == QueryableMethods.MaxWithSelector)
                         && source.Selector is SqlExpression maxSqlExpression:
                    maxSqlExpression = CombineTerms(source, maxSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "MAX",
                        [maxSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        maxSqlExpression.Type,
                        maxSqlExpression.TypeMapping);

                case nameof(Queryable.Min)
                    when (methodInfo == QueryableMethods.MinWithoutSelector
                          || methodInfo == QueryableMethods.MinWithSelector)
                         && source.Selector is SqlExpression minSqlExpression:
                    minSqlExpression = CombineTerms(source, minSqlExpression);
                    return _sqlExpressionFactory.Function(
                        "MIN",
                        [minSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        minSqlExpression.Type,
                        minSqlExpression.TypeMapping);

                case nameof(Queryable.Sum)
                    when (QueryableMethods.IsSumWithoutSelector(methodInfo)
                          || QueryableMethods.IsSumWithSelector(methodInfo))
                         && source.Selector is SqlExpression sumSqlExpression:
                    sumSqlExpression = CombineTerms(source, sumSqlExpression);
                    var sumInputType = sumSqlExpression.Type;

                    if (sumInputType == typeof(float))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "SUM",
                                [sumSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(double)),
                            sumInputType,
                            sumSqlExpression.TypeMapping);
                    }

                    if (sumInputType == typeof(decimal))
                    {
                        return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "SUM",
                                [sumSqlExpression],
                                nullable: true,
                                argumentsPropagateNullability: [false],
                                typeof(decimal)),
                            sumInputType,
                            sumSqlExpression.TypeMapping);
                    }

                    return _sqlExpressionFactory.Function(
                        "SUM",
                        [sumSqlExpression],
                        nullable: true,
                        argumentsPropagateNullability: [false],
                        sumInputType,
                        sumSqlExpression.TypeMapping);
            }
        }

        // Support single-argument DuckDB aggregate functions whose result type differs from the selector type
        // (e.g., g.CountIf(e => e.IsActive), g.FAvg(e => e.Amount), g.FSum(e => e.Amount))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions))
        {
            var fixedResultFunctionName = method.Name switch
            {
                nameof(DuckDBGroupingExtensions.ApproxCountDistinctAggregate) => "APPROX_COUNT_DISTINCT",
                nameof(DuckDBGroupingExtensions.CountIfAggregate) => "COUNTIF",
                nameof(DuckDBGroupingExtensions.EntropyAggregate) => "ENTROPY",
                nameof(DuckDBGroupingExtensions.KurtosisPopAggregate) => "KURTOSIS_POP",
                nameof(DuckDBGroupingExtensions.FAvgAggregate) => "FAVG",
                nameof(DuckDBGroupingExtensions.FSumAggregate) => "FSUM",
                nameof(DuckDBGroupingExtensions.GeometricMeanAggregate) => "GEOMETRIC_MEAN",
                nameof(DuckDBGroupingExtensions.ProductAggregate) => "PRODUCT",
                nameof(DuckDBGroupingExtensions.HistogramAggregate) when arguments.Count == 0 => "HISTOGRAM",
                _ => null
            };

            if (fixedResultFunctionName != null && source.Selector is SqlExpression fixedResultSqlExpression)
            {
                fixedResultSqlExpression = CombineTerms(source, fixedResultSqlExpression);
                return _sqlExpressionFactory.Function(
                    fixedResultFunctionName,
                    [fixedResultSqlExpression],
                    nullable: true,
                    argumentsPropagateNullability: [false],
                    method.ReturnType);
            }
        }

        // Support APPROX_QUANTILE(arg, pos) aggregate function
        // (e.g., g.ApproxQuantile(e => e.Prop, 0.5), g.ApproxQuantile(e => e.Prop, new[] { 0.25f, 0.75f }))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.ApproxQuantileAggregate)
            && arguments.Count == 1
            && source.Selector is SqlExpression approxQuantileSelector)
        {
            approxQuantileSelector = CombineTerms(source, approxQuantileSelector);

            return _sqlExpressionFactory.Function(
                "APPROX_QUANTILE",
                [approxQuantileSelector, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType,
                method.ReturnType == approxQuantileSelector.Type ? approxQuantileSelector.TypeMapping : null);
        }

        // Support HISTOGRAM(arg, boundaries) aggregate function
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.HistogramAggregate)
            && arguments.Count == 1
            && source.Selector is SqlExpression histogramSelector)
        {
            histogramSelector = CombineTerms(source, histogramSelector);

            return _sqlExpressionFactory.Function(
                "HISTOGRAM",
                [histogramSelector, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType);
        }

        // Support HISTOGRAM_EXACT(arg, elements) aggregate function
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.HistogramExactAggregate)
            && arguments.Count == 1
            && source.Selector is SqlExpression histogramExactSelector)
        {
            histogramExactSelector = CombineTerms(source, histogramExactSelector);

            return _sqlExpressionFactory.Function(
                "HISTOGRAM_EXACT",
                [histogramExactSelector, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType);
        }

        // Support APPROX_TOP_K(arg, k) aggregate function
        // (e.g., g.ApproxTopK(e => e.Prop, k))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.ApproxTopKAggregate)
            && arguments.Count == 1
            && source.Selector is SqlExpression approxTopKSelector)
        {
            approxTopKSelector = CombineTerms(source, approxTopKSelector);

            return _sqlExpressionFactory.Function(
                "APPROX_TOP_K",
                [approxTopKSelector, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType);
        }

        // Support RESERVOIR_QUANTILE(x, quantile, sample_size = 8192) aggregate function
        // (e.g., g.ReservoirQuantile(e => e.Prop, 0.5), g.ReservoirQuantile(e => e.Prop, 0.5, 1024), g.ReservoirQuantile(e => e.Prop, new[] { 0.25f, 0.75f }))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.ReservoirQuantileAggregate)
            && arguments.Count is 1 or 2
            && source.Selector is SqlExpression reservoirQuantileSelector)
        {
            reservoirQuantileSelector = CombineTerms(source, reservoirQuantileSelector);

            var functionArguments = arguments.Count == 1
                ? new[] { reservoirQuantileSelector, arguments[0] }
                : new[] { reservoirQuantileSelector, arguments[0], arguments[1] };

            return _sqlExpressionFactory.Function(
                "RESERVOIR_QUANTILE",
                functionArguments,
                nullable: true,
                argumentsPropagateNullability: arguments.Count == 1 ? [false, false] : [false, false, false],
                method.ReturnType,
                method.ReturnType == reservoirQuantileSelector.Type ? reservoirQuantileSelector.TypeMapping : null);
        }

        // Support MIN(arg, n) and MAX(arg, n) aggregate functions
        // (e.g., g.Min(e => e.Prop, n), g.Max(e => e.Prop, n))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && (method.Name == nameof(DuckDBGroupingExtensions.MinAggregate)
                || method.Name == nameof(DuckDBGroupingExtensions.MaxAggregate))
            && arguments.Count == 1
            && source.Selector is SqlExpression minMaxSelector)
        {
            var functionName = method.Name == nameof(DuckDBGroupingExtensions.MinAggregate) ? "MIN" : "MAX";
            minMaxSelector = CombineTerms(source, minMaxSelector);

            return _sqlExpressionFactory.Function(
                functionName,
                [minMaxSelector, arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType);
        }

        // Support single-argument DuckDB aggregate functions
        // (e.g., g.AnyValue(e => e.Prop), g.BitAnd(e => e.Flags))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions))
        {
            var singleArgumentFunctionName = method.Name switch
            {
                nameof(DuckDBGroupingExtensions.AnyValueAggregate) => "ANY_VALUE",
                nameof(DuckDBGroupingExtensions.ArgFirstAggregate) => "FIRST",
                nameof(DuckDBGroupingExtensions.BitAndAggregate) => "BIT_AND",
                nameof(DuckDBGroupingExtensions.BitOrAggregate) => "BIT_OR",
                nameof(DuckDBGroupingExtensions.BitXorAggregate) => "BIT_XOR",
                nameof(DuckDBGroupingExtensions.BoolAndAggregate) => "BOOL_AND",
                nameof(DuckDBGroupingExtensions.BoolOrAggregate) => "BOOL_OR",
                _ => null
            };

            if (singleArgumentFunctionName != null && source.Selector is SqlExpression singleArgumentSqlExpression)
            {
                singleArgumentSqlExpression = CombineTerms(source, singleArgumentSqlExpression);
                return _sqlExpressionFactory.Function(
                    singleArgumentFunctionName,
                    [singleArgumentSqlExpression],
                    nullable: true,
                    argumentsPropagateNullability: [false],
                    method.ReturnType,
                    singleArgumentSqlExpression.TypeMapping);
            }
        }

        // Support BITSTRING_AGG aggregate function
        // (e.g., g.BitStringAgg(e => e.Value), g.BitStringAgg(e => e.Value, min, max))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && method.Name == nameof(DuckDBGroupingExtensions.BitStringAggAggregate)
            && source.Selector is SqlExpression bitStringSelector)
        {
            bitStringSelector = CombineTerms(source, bitStringSelector);

            return arguments.Count == 2
                ? _sqlExpressionFactory.Function(
                    "BITSTRING_AGG",
                    [bitStringSelector, arguments[0], arguments[1]],
                    nullable: true,
                    argumentsPropagateNullability: [false, false, false],
                    typeof(string),
                    DuckDBBitStringTypeMapping.Default)
                : _sqlExpressionFactory.Function(
                    "BITSTRING_AGG",
                    [bitStringSelector],
                    nullable: true,
                    argumentsPropagateNullability: [false],
                    typeof(string),
                    DuckDBBitStringTypeMapping.Default);
        }

        // Support CORR(y, x), COVAR_POP(y, x) and COVAR_SAMP(y, x) aggregate functions
        // (e.g., g.Corr(e => e.Y, e => e.X), g.CovarPop(e => e.Y, e => e.X), g.CovarSamp(e => e.Y, e => e.X))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && (method.Name == nameof(DuckDBGroupingExtensions.CorrAggregate)
                || method.Name == nameof(DuckDBGroupingExtensions.CovarPopAggregate)
                || method.Name == nameof(DuckDBGroupingExtensions.CovarSampAggregate))
            && source.Selector is DuckDBRowValueExpression { Values.Count: 2 } pairRowValue
            && !source.IsDistinct)
        {
            var y = pairRowValue.Values[0];
            var x = pairRowValue.Values[1];

            if (source.Predicate != null)
            {
                y = CombineTerms(source, y);
                x = CombineTerms(source, x);
            }

            var functionName = method.Name switch
            {
                nameof(DuckDBGroupingExtensions.CorrAggregate) => "CORR",
                nameof(DuckDBGroupingExtensions.CovarPopAggregate) => "COVAR_POP",
                _ => "COVAR_SAMP"
            };

            return _sqlExpressionFactory.Function(
                functionName,
                [y, x],
                nullable: true,
                argumentsPropagateNullability: [false, false],
                method.ReturnType);
        }

        // Support ARG_MAX / ARG_MAX_NULL / ARG_MIN / ARG_MIN_NULL aggregate functions
        // (e.g., g.ArgMax(e => e.Prop, e => e.Value[, n]), g.ArgMinNull(e => e.Prop, e => e.Value))
        if (method.DeclaringType == typeof(DuckDBGroupingExtensions))
        {
            var functionName = method.Name switch
            {
                nameof(DuckDBGroupingExtensions.ArgMaxAggregate) => "ARG_MAX",
                nameof(DuckDBGroupingExtensions.ArgMaxNullAggregate) => "ARG_MAX_NULL",
                nameof(DuckDBGroupingExtensions.ArgMinAggregate) => "ARG_MIN",
                nameof(DuckDBGroupingExtensions.ArgMinNullAggregate) => "ARG_MIN_NULL",
                _ => null
            };

            if (functionName != null
                && source.Selector is DuckDBRowValueExpression { Values.Count: 2 } rowValue
                && !source.IsDistinct)
            {
                var arg = rowValue.Values[0];
                var val = rowValue.Values[1];

                if (source.Predicate != null)
                {
                    arg = CombineTerms(source, arg);
                    val = CombineTerms(source, val);
                }

                return arguments.Count == 1
                    ? _sqlExpressionFactory.Function(
                        functionName,
                        [arg, val, arguments[0]],
                        nullable: true,
                        argumentsPropagateNullability: [false, false, false],
                        method.ReturnType)
                    : _sqlExpressionFactory.Function(
                        functionName,
                        [arg, val],
                        nullable: true,
                        argumentsPropagateNullability: [false, false],
                        method.ReturnType,
                        arg.TypeMapping);
            }
        }

        return null;
    }

    private SqlExpression CombineTerms(EnumerableExpression enumerableExpression, SqlExpression sqlExpression)
    {
        if (enumerableExpression.Predicate != null)
        {
            if (sqlExpression is SqlFragmentExpression)
            {
                sqlExpression = _sqlExpressionFactory.Constant(1);
            }

            sqlExpression = _sqlExpressionFactory.Case(
                new List<CaseWhenClause> { new(enumerableExpression.Predicate, sqlExpression) },
                elseResult: null);
        }

        if (enumerableExpression.IsDistinct)
        {
            sqlExpression = new DistinctExpression(sqlExpression);
        }

        return sqlExpression;
    }
}
