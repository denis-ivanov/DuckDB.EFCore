using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBArrayPreprocessor : ExpressionVisitor
{
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
            QueryableMethods.AsQueryable.MakeGenericMethod(elementType),
            source);
    }
}
