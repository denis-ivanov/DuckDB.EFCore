using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBAnyValuePreprocessor : ExpressionVisitor
{
    private static readonly MethodInfo EnumerableSelectMethod
        = typeof(Enumerable).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(
                m => m.Name == nameof(Enumerable.Select)
                    && m.GetParameters().Length == 2
                    && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);

    /// <inheritdoc />
    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.DeclaringType == typeof(DuckDBGroupingExtensions)
            && methodCallExpression.Method.Name == nameof(DuckDBGroupingExtensions.AnyValue)
            && methodCallExpression.Arguments.Count == 2)
        {
            var source = Visit(methodCallExpression.Arguments[0]);
            var selector = methodCallExpression.Arguments[1].UnwrapLambda();

            if (selector != null)
            {
                var sourceElementType = selector.Parameters[0].Type;
                var resultType = selector.ReturnType;

                var projection = Expression.Call(
                    EnumerableSelectMethod.MakeGenericMethod(sourceElementType, resultType),
                    source,
                    selector);

                return Expression.Call(
                    DuckDBGroupingExtensions.AnyValueAggregateMethod.MakeGenericMethod(resultType),
                    projection);
            }
        }

        return base.VisitMethodCall(methodCallExpression);
    }
}

file static class LambdaUnwrapExtensions
{
    public static LambdaExpression? UnwrapLambda(this Expression expression)
        => expression switch
        {
            LambdaExpression lambda => lambda,
            UnaryExpression { NodeType: ExpressionType.Quote, Operand: LambdaExpression lambda } => lambda,
            _ => null
        };
}
