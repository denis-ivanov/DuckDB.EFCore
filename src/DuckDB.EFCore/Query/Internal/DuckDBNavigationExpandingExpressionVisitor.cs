using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBNavigationExpandingExpressionVisitor : NavigationExpandingExpressionVisitor
{
    public DuckDBNavigationExpandingExpressionVisitor(
        QueryTranslationPreprocessor queryTranslationPreprocessor,
        QueryCompilationContext queryCompilationContext,
        IEvaluatableExpressionFilter evaluatableExpressionFilter,
        INavigationExpansionExtensibilityHelper extensibilityHelper)
        : base(queryTranslationPreprocessor, queryCompilationContext, evaluatableExpressionFilter, extensibilityHelper)
    {
    }

    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
    {
        var method = methodCallExpression.Method;

        if (method.DeclaringType == typeof(Queryable))
        {
            if (method.Name == nameof(Queryable.Prepend))
            {
                return methodCallExpression.Update(Visit(methodCallExpression.Object), methodCallExpression.Arguments.Select(e => Visit(e)));
            }
            
            if (method.Name == nameof(Queryable.Append))
            {
                return methodCallExpression.Update(Visit(methodCallExpression.Object), methodCallExpression.Arguments.Select(e => Visit(e)));
            }
        }

        return base.VisitMethodCall(methodCallExpression);
    }
}
