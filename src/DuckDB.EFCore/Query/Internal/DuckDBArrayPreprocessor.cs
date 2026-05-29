using DuckDB.EFCore.Query.Expressions.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBArrayPreprocessor : ExpressionVisitor
{
    private static readonly MethodInfo QueryableAsQueryableMethod =
        typeof(Queryable).GetMethods()
            .Single(m => m is { Name: nameof(Queryable.AsQueryable), IsGenericMethod: true }
                         && m.GetParameters().Length == 1);

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        var method = node.Method;

        if (method.DeclaringType == typeof(Enumerable))
        {
            if (method.Name == nameof(Enumerable.Prepend))
            {
                var source = Visit(node.Arguments[0]);
                var element = Visit(node.Arguments[1]);
                var queryableSource = EnsureQueryable(source, method.GetGenericArguments()[0]);

                return new DuckDBArrayPrependExpression(
                    queryableSource,
                    element,
                    queryableSource.Type);
            }

            if (method.Name == nameof(Enumerable.Append))
            {
                var source = Visit(node.Arguments[0]);
                var element = Visit(node.Arguments[1]);
                var queryableSource = EnsureQueryable(source, method.GetGenericArguments()[0]);

                return new DuckDBArrayAppendExpression(
                    queryableSource,
                    element,
                    queryableSource.Type);
            }
        }

        return base.VisitMethodCall(node);
    }

    protected override Expression VisitExtension(Expression node)
    {
        return node switch
        {
            DuckDBArrayPrependExpression or DuckDBArrayAppendExpression => node,
            _ => base.VisitExtension(node)
        };
    }
    
    private Expression EnsureQueryable(Expression source, Type elementType)
    {
        if (typeof(IQueryable<>).MakeGenericType(elementType).IsAssignableFrom(source.Type))
        {
            return source;
        }

        return Expression.Call(
            QueryableAsQueryableMethod.MakeGenericMethod(elementType),
            source);
    }
}
