using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBGroupingAggregatePreprocessor : ExpressionVisitor
{
    private static readonly MethodInfo EnumerableSelectMethod
        = typeof(Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(
                m => m.Name == nameof(Enumerable.Select)
                    && m.GetParameters().Length == 2
                    && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);

    private static readonly MethodInfo ValueTupleCreateMethod
        = typeof(ValueTuple).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(m => m.Name == nameof(ValueTuple.Create) && m.GetGenericArguments().Length == 2);

    /// <inheritdoc />
    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.DeclaringType == typeof(DuckDBGroupingExtensions))
        {
            switch (methodCallExpression.Method.Name)
            {
                case nameof(DuckDBGroupingExtensions.AnyValue)
                    or nameof(DuckDBGroupingExtensions.ApproxCountDistinct)
                    or nameof(DuckDBGroupingExtensions.ArgFirst)
                    or nameof(DuckDBGroupingExtensions.BitAnd)
                    or nameof(DuckDBGroupingExtensions.BitOr)
                    or nameof(DuckDBGroupingExtensions.BitXor)
                    or nameof(DuckDBGroupingExtensions.BoolAnd)
                    or nameof(DuckDBGroupingExtensions.BoolOr)
                    or nameof(DuckDBGroupingExtensions.CountIf)
                    or nameof(DuckDBGroupingExtensions.FAvg)
                    or nameof(DuckDBGroupingExtensions.FSum)
                    or nameof(DuckDBGroupingExtensions.Histogram)
                    or nameof(DuckDBGroupingExtensions.GeometricMean)
                    or nameof(DuckDBGroupingExtensions.Product)
                    when methodCallExpression.Arguments is [var singleSelectorSource, var singleSelectorArgument]
                        && UnwrapLambda(singleSelectorArgument) is { } singleSelector:
                    return RewriteSingleSelector(
                        Visit(singleSelectorSource),
                        singleSelector,
                        GetSingleSelectorAggregateMethod(methodCallExpression.Method.Name));

                case nameof(DuckDBGroupingExtensions.Corr)
                or nameof(DuckDBGroupingExtensions.CovarPop)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } ySelector
                        && UnwrapLambda(methodCallExpression.Arguments[2]) is { } xSelector:
                    return RewritePairAggregate(
                        Visit(methodCallExpression.Arguments[0]),
                        ySelector,
                        xSelector,
                        methodCallExpression.Method.Name == nameof(DuckDBGroupingExtensions.Corr)
                            ? DuckDBGroupingExtensions.CorrAggregateMethod
                            : DuckDBGroupingExtensions.CovarPopAggregateMethod);

                case nameof(DuckDBGroupingExtensions.ApproxQuantile)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } approxQuantileSelector:
                    return RewriteApproxQuantile(
                        Visit(methodCallExpression.Arguments[0]),
                        approxQuantileSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.BitStringAgg)
                    when methodCallExpression.Arguments.Count is 2 or 4
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } bitStringSelector:
                    return RewriteBitStringAgg(
                        Visit(methodCallExpression.Arguments[0]),
                        bitStringSelector,
                        methodCallExpression.Arguments.Count == 4
                            ? (Visit(methodCallExpression.Arguments[2]), Visit(methodCallExpression.Arguments[3]))
                            : null);

                case nameof(DuckDBGroupingExtensions.Histogram)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } histogramSelector:
                    return RewriteHistogram(
                        Visit(methodCallExpression.Arguments[0]),
                        histogramSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.HistogramExact)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } histogramExactSelector:
                    return RewriteHistogramExact(
                        Visit(methodCallExpression.Arguments[0]),
                        histogramExactSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.ApproxTopK)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } approxTopKSelector:
                    return RewriteApproxTopK(
                        Visit(methodCallExpression.Arguments[0]),
                        approxTopKSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.ReservoirQuantile)
                    when methodCallExpression.Arguments.Count is 3 or 4
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } reservoirQuantileSelector:
                    return RewriteReservoirQuantile(
                        Visit(methodCallExpression.Arguments[0]),
                        reservoirQuantileSelector,
                        Visit(methodCallExpression.Arguments[2]),
                        methodCallExpression.Arguments.Count == 4 ? Visit(methodCallExpression.Arguments[3]) : null);

                case nameof(DuckDBGroupingExtensions.Max)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } maxSelector:
                    return RewriteMax(
                        Visit(methodCallExpression.Arguments[0]),
                        maxSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.Min)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } minSelector:
                    return RewriteMin(
                        Visit(methodCallExpression.Arguments[0]),
                        minSelector,
                        Visit(methodCallExpression.Arguments[2]));

                case nameof(DuckDBGroupingExtensions.ArgMax)
                    when methodCallExpression.Arguments.Count is 3 or 4
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } argSelector
                        && UnwrapLambda(methodCallExpression.Arguments[2]) is { } valSelector:
                    return RewriteArgMinMax(
                        Visit(methodCallExpression.Arguments[0]),
                        argSelector,
                        valSelector,
                        methodCallExpression.Arguments.Count == 4 ? Visit(methodCallExpression.Arguments[3]) : null,
                        nullable: false,
                        min: false);

                case nameof(DuckDBGroupingExtensions.ArgMaxNull)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } nullableArgSelector
                        && UnwrapLambda(methodCallExpression.Arguments[2]) is { } nullableValSelector:
                    return RewriteArgMinMax(
                        Visit(methodCallExpression.Arguments[0]),
                        nullableArgSelector,
                        nullableValSelector,
                        count: null,
                        nullable: true,
                        min: false);

                case nameof(DuckDBGroupingExtensions.ArgMin)
                    when methodCallExpression.Arguments.Count is 3 or 4
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } minArgSelector
                        && UnwrapLambda(methodCallExpression.Arguments[2]) is { } minValSelector:
                    return RewriteArgMinMax(
                        Visit(methodCallExpression.Arguments[0]),
                        minArgSelector,
                        minValSelector,
                        methodCallExpression.Arguments.Count == 4 ? Visit(methodCallExpression.Arguments[3]) : null,
                        nullable: false,
                        min: true);

                case nameof(DuckDBGroupingExtensions.ArgMinNull)
                    when methodCallExpression.Arguments.Count == 3
                        && UnwrapLambda(methodCallExpression.Arguments[1]) is { } nullableMinArgSelector
                        && UnwrapLambda(methodCallExpression.Arguments[2]) is { } nullableMinValSelector:
                    return RewriteArgMinMax(
                        Visit(methodCallExpression.Arguments[0]),
                        nullableMinArgSelector,
                        nullableMinValSelector,
                        count: null,
                        nullable: true,
                        min: true);
            }
        }

        return base.VisitMethodCall(methodCallExpression);
    }

    private static MethodInfo GetSingleSelectorAggregateMethod(string methodName)
        => methodName switch
        {
            nameof(DuckDBGroupingExtensions.AnyValue) => DuckDBGroupingExtensions.AnyValueAggregateMethod,
            nameof(DuckDBGroupingExtensions.ApproxCountDistinct) => DuckDBGroupingExtensions.ApproxCountDistinctAggregateMethod,
            nameof(DuckDBGroupingExtensions.ArgFirst) => DuckDBGroupingExtensions.ArgFirstAggregateMethod,
            nameof(DuckDBGroupingExtensions.BitAnd) => DuckDBGroupingExtensions.BitAndAggregateMethod,
            nameof(DuckDBGroupingExtensions.BitOr) => DuckDBGroupingExtensions.BitOrAggregateMethod,
            nameof(DuckDBGroupingExtensions.BitXor) => DuckDBGroupingExtensions.BitXorAggregateMethod,
            nameof(DuckDBGroupingExtensions.BoolAnd) => DuckDBGroupingExtensions.BoolAndAggregateMethod,
            nameof(DuckDBGroupingExtensions.BoolOr) => DuckDBGroupingExtensions.BoolOrAggregateMethod,
            nameof(DuckDBGroupingExtensions.CountIf) => DuckDBGroupingExtensions.CountIfAggregateMethod,
            nameof(DuckDBGroupingExtensions.FAvg) => DuckDBGroupingExtensions.FAvgAggregateMethod,
            nameof(DuckDBGroupingExtensions.FSum) => DuckDBGroupingExtensions.FSumAggregateMethod,
            nameof(DuckDBGroupingExtensions.Histogram) => DuckDBGroupingExtensions.HistogramAggregateMethod,
            nameof(DuckDBGroupingExtensions.GeometricMean) => DuckDBGroupingExtensions.GeometricMeanAggregateMethod,
            nameof(DuckDBGroupingExtensions.Product) => DuckDBGroupingExtensions.ProductAggregateMethod,
            _ => throw new ArgumentOutOfRangeException(nameof(methodName), methodName, null)
        };

    private static Expression RewriteSingleSelector(Expression source, LambdaExpression selector, MethodInfo aggregateMethod)
    {
        var projection = Project(source, selector);

        return Expression.Call(aggregateMethod.MakeGenericMethod(selector.ReturnType), projection);
    }

    private static Expression RewriteApproxQuantile(
        Expression source,
        LambdaExpression selector,
        Expression pos)
    {
        var projection = Project(source, selector);

        var aggregateMethod = pos.Type == typeof(float[])
            ? DuckDBGroupingExtensions.ApproxQuantileArrayAggregateMethod
            : DuckDBGroupingExtensions.ApproxQuantileAggregateMethod;

        return Expression.Call(
            aggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            pos);
    }

    private static Expression RewriteBitStringAgg(
        Expression source,
        LambdaExpression selector,
        (Expression Min, Expression Max)? bounds)
    {
        var projection = Project(source, selector);

        return bounds is null
            ? Expression.Call(
                DuckDBGroupingExtensions.BitStringAggAggregateMethod.MakeGenericMethod(selector.ReturnType),
                projection)
            : Expression.Call(
                DuckDBGroupingExtensions.BitStringAggWithBoundsAggregateMethod.MakeGenericMethod(selector.ReturnType),
                projection,
                bounds.Value.Min,
                bounds.Value.Max);
    }

    private static Expression RewriteHistogram(
        Expression source,
        LambdaExpression selector,
        Expression boundaries)
    {
        var projection = Project(source, selector);

        return Expression.Call(
            DuckDBGroupingExtensions.HistogramWithBoundariesAggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            boundaries);
    }

    private static Expression RewriteHistogramExact(
        Expression source,
        LambdaExpression selector,
        Expression elements)
    {
        var projection = Project(source, selector);

        return Expression.Call(
            DuckDBGroupingExtensions.HistogramExactAggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            elements);
    }

    private static Expression RewriteApproxTopK(
        Expression source,
        LambdaExpression selector,
        Expression k)
    {
        var projection = Project(source, selector);

        return Expression.Call(
            DuckDBGroupingExtensions.ApproxTopKAggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            k);
    }

    private static Expression RewriteReservoirQuantile(
        Expression source,
        LambdaExpression selector,
        Expression quantile,
        Expression? sampleSize)
    {
        var projection = Project(source, selector);

        var aggregateMethod = (quantile.Type == typeof(float[]), sampleSize is not null) switch
        {
            (false, false) => DuckDBGroupingExtensions.ReservoirQuantileAggregateMethod,
            (false, true) => DuckDBGroupingExtensions.ReservoirQuantileWithSizeAggregateMethod,
            (true, false) => DuckDBGroupingExtensions.ReservoirQuantileArrayAggregateMethod,
            (true, true) => DuckDBGroupingExtensions.ReservoirQuantileArrayWithSizeAggregateMethod,
        };

        return sampleSize is null
            ? Expression.Call(
                aggregateMethod.MakeGenericMethod(selector.ReturnType),
                projection,
                quantile)
            : Expression.Call(
                aggregateMethod.MakeGenericMethod(selector.ReturnType),
                projection,
                quantile,
                sampleSize);
    }

    private static Expression RewriteMax(
        Expression source,
        LambdaExpression selector,
        Expression count)
    {
        var projection = Project(source, selector);

        return Expression.Call(
            DuckDBGroupingExtensions.MaxAggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            count);
    }

    private static Expression RewriteMin(
        Expression source,
        LambdaExpression selector,
        Expression count)
    {
        var projection = Project(source, selector);

        return Expression.Call(
            DuckDBGroupingExtensions.MinAggregateMethod.MakeGenericMethod(selector.ReturnType),
            projection,
            count);
    }

    private static Expression RewritePairAggregate(
        Expression source,
        LambdaExpression ySelector,
        LambdaExpression xSelector,
        MethodInfo aggregateMethod)
    {
        var parameter = ySelector.Parameters[0];
        var xBody = ReplacingExpressionVisitor.Replace(xSelector.Parameters[0], parameter, xSelector.Body);

        var yType = ySelector.ReturnType;
        var xType = xSelector.ReturnType;

        var tupleSelector = Expression.Lambda(
            Expression.Call(ValueTupleCreateMethod.MakeGenericMethod(yType, xType), ySelector.Body, xBody),
            parameter);

        var projection = Project(source, tupleSelector);

        return Expression.Call(
            aggregateMethod.MakeGenericMethod(yType, xType),
            projection);
    }

    private static Expression RewriteArgMinMax(
        Expression source,
        LambdaExpression argSelector,
        LambdaExpression valSelector,
        Expression? count,
        bool nullable,
        bool min)
    {
        var parameter = argSelector.Parameters[0];
        var valBody = ReplacingExpressionVisitor.Replace(valSelector.Parameters[0], parameter, valSelector.Body);

        var argType = argSelector.ReturnType;
        var valType = valSelector.ReturnType;

        var tupleSelector = Expression.Lambda(
            Expression.Call(ValueTupleCreateMethod.MakeGenericMethod(argType, valType), argSelector.Body, valBody),
            parameter);

        var projection = Project(source, tupleSelector);

        if (nullable)
        {
            return Expression.Call(
                (min
                    ? DuckDBGroupingExtensions.ArgMinNullAggregateMethod
                    : DuckDBGroupingExtensions.ArgMaxNullAggregateMethod).MakeGenericMethod(argType, valType),
                projection);
        }

        return count is null
            ? Expression.Call(
                (min
                    ? DuckDBGroupingExtensions.ArgMinAggregateMethod
                    : DuckDBGroupingExtensions.ArgMaxAggregateMethod).MakeGenericMethod(argType, valType),
                projection)
            : Expression.Call(
                (min
                    ? DuckDBGroupingExtensions.ArgMinManyAggregateMethod
                    : DuckDBGroupingExtensions.ArgMaxManyAggregateMethod).MakeGenericMethod(argType, valType),
                projection,
                count);
    }

    private static MethodCallExpression Project(Expression source, LambdaExpression selector)
        => Expression.Call(
            EnumerableSelectMethod.MakeGenericMethod(selector.Parameters[0].Type, selector.ReturnType),
            source,
            selector);

    private static LambdaExpression? UnwrapLambda(Expression expression)
        => expression switch
        {
            LambdaExpression lambda => lambda,
            UnaryExpression { NodeType: ExpressionType.Quote, Operand: LambdaExpression lambda } => lambda,
            _ => null
        };
}
