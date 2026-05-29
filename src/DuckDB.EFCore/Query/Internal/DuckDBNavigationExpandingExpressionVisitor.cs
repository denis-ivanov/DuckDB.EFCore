using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using DuckDB.EFCore.Query.Expressions.Internal;
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
        if (methodCallExpression.Method.DeclaringType == typeof(Queryable)
            && methodCallExpression.Arguments.Count > 0)
        {
            var originalSource = methodCallExpression.Arguments[0];
            if (originalSource is DuckDBArrayAppendExpression or DuckDBArrayPrependExpression)
            {
                var source = Visit(originalSource);
                return methodCallExpression.Update(
                    methodCallExpression.Object,
                    new Expression[] { source }.Concat(methodCallExpression.Arguments.Skip(1).Select(argument => Visit(argument)!)));
            }
        }

        return base.VisitMethodCall(methodCallExpression);
    }

    protected override Expression VisitExtension(Expression extensionExpression)
        => extensionExpression switch
        {
            DuckDBArrayAppendExpression appendExpression
                => new DuckDBArrayAppendExpression(Visit(appendExpression.Source), Visit(appendExpression.Value), appendExpression.Type),
            DuckDBArrayPrependExpression prependExpression
                => new DuckDBArrayPrependExpression(Visit(prependExpression.Source), Visit(prependExpression.Value), prependExpression.Type),
            _ => base.VisitExtension(extensionExpression)
        };
}
