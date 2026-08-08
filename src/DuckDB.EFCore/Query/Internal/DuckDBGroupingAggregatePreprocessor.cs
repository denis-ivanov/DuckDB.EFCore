using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
                    when methodCallExpression.Arguments is [var anyValueSource, var anyValueSelector]
                        && UnwrapLambda(anyValueSelector) is { } selector:
                    return RewriteSingleSelector(
                        Visit(anyValueSource), selector, DuckDBGroupingExtensions.AnyValueAggregateMethod);

                case nameof(DuckDBGroupingExtensions.BitAnd)
                    when methodCallExpression.Arguments is [var bitAndSource, var bitAndSelector]
                        && UnwrapLambda(bitAndSelector) is { } selector:
                    return RewriteSingleSelector(
                        Visit(bitAndSource), selector, DuckDBGroupingExtensions.BitAndAggregateMethod);

                case nameof(DuckDBGroupingExtensions.BitOr)
                    when methodCallExpression.Arguments is [var bitOrSource, var bitOrSelector]
                        && UnwrapLambda(bitOrSelector) is { } selector:
                    return RewriteSingleSelector(
                        Visit(bitOrSource), selector, DuckDBGroupingExtensions.BitOrAggregateMethod);

                case nameof(DuckDBGroupingExtensions.BitXor)
                    when methodCallExpression.Arguments is [var bitXorSource, var bitXorSelector]
                        && UnwrapLambda(bitXorSelector) is { } selector:
                    return RewriteSingleSelector(
                        Visit(bitXorSource), selector, DuckDBGroupingExtensions.BitXorAggregateMethod);

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

    private static Expression RewriteSingleSelector(Expression source, LambdaExpression selector, MethodInfo aggregateMethod)
    {
        var projection = Project(source, selector);

        return Expression.Call(aggregateMethod.MakeGenericMethod(selector.ReturnType), projection);
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
