using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryableMethodTranslatingExpressionVisitor : RelationalQueryableMethodTranslatingExpressionVisitor
{
    public DuckDBQueryableMethodTranslatingExpressionVisitor(QueryableMethodTranslatingExpressionVisitorDependencies dependencies, RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies, RelationalQueryCompilationContext queryCompilationContext) : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }

    protected DuckDBQueryableMethodTranslatingExpressionVisitor(RelationalQueryableMethodTranslatingExpressionVisitor parentVisitor) : base(parentVisitor)
    {
    }

    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.DeclaringType == typeof(DateOnly))
        {
            // TODO DateOnly.AddDays();
        }
        
        return base.VisitMethodCall(methodCallExpression);
    }

    protected override Expression VisitMember(MemberExpression memberExpression)
    {
        if (memberExpression.Member.DeclaringType == typeof(DateOnly))
        {
            // TODO DateOnly.AddDays();
        }
        
        return base.VisitMember(memberExpression);
    }
}