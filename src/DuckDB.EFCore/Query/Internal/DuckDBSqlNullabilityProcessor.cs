using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlNullabilityProcessor : SqlNullabilityProcessor
{
    public DuckDBSqlNullabilityProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
    }

    protected override SqlExpression VisitCustomSqlExpression(SqlExpression sqlExpression, bool allowOptimizedExpansion, out bool nullable)
    {
        return sqlExpression switch
        {
            DuckDBBinaryExpression e => VisitBinary(e, allowOptimizedExpansion, out nullable),
            DuckDBArrayIndexExpression e => VisitArrayIndex(e, allowOptimizedExpansion, out nullable),
            _ => base.VisitCustomSqlExpression(sqlExpression, allowOptimizedExpansion, out nullable)
        };
    }

    protected virtual SqlExpression VisitBinary(DuckDBBinaryExpression binaryExpression, bool allowOptimizedExpansion, out bool nullable)
    {
        var leftExpression = Visit(binaryExpression.Left, allowOptimizedExpansion, out var leftNullable);
        var rightExpression = Visit(binaryExpression.Right, allowOptimizedExpansion, out var rightNullable);

        var updated = binaryExpression.Update(leftExpression, rightExpression);

        if (UseRelationalNulls)
        {
            nullable = false;
            return updated;
        }

        nullable = leftNullable || rightNullable;
        return updated;
    }

    protected virtual SqlExpression VisitArrayIndex(
        DuckDBArrayIndexExpression arrayIndexExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
    {
        var array = Visit(arrayIndexExpression.Array, allowOptimizedExpansion, out var arrayNullable);
        var index = Visit(arrayIndexExpression.Index, allowOptimizedExpansion, out var indexNullable);

        nullable = arrayNullable || indexNullable || arrayIndexExpression.IsNullable;

        return arrayIndexExpression.Update(array, index);
    }
}
