using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQueryTranslationPreprocessor : RelationalQueryTranslationPreprocessor
{
    public DuckDBQueryTranslationPreprocessor(
        QueryTranslationPreprocessorDependencies dependencies,
        RelationalQueryTranslationPreprocessorDependencies relationalDependencies,
        QueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }

    public override Expression Process(Expression query)
    {
        query = new InvocationExpressionRemovingExpressionVisitor().Visit(query);
        query = new DuckDBArrayPreprocessor().Visit(query);
        query = NormalizeQueryableMethod(query);
        query = new CallForwardingExpressionVisitor().Visit(query);
        query = new NullCheckRemovingExpressionVisitor().Visit(query);
        query = new SubqueryMemberPushdownExpressionVisitor(QueryCompilationContext.Model).Visit(query);
        query = new DuckDBNavigationExpandingExpressionVisitor(
                this,
                QueryCompilationContext,
                Dependencies.EvaluatableExpressionFilter,
                Dependencies.NavigationExpansionExtensibilityHelper)
            .Expand(query);
        query = new QueryOptimizingExpressionVisitor().Visit(query);
        query = new NullCheckRemovingExpressionVisitor().Visit(query);

        return query;
    }
}
