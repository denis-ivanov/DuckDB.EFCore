using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBSqlNullabilityProcessor : SqlNullabilityProcessor
{
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    public DuckDBSqlNullabilityProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)dependencies.SqlExpressionFactory;
    }

    protected override SqlExpression VisitCustomSqlExpression(SqlExpression sqlExpression, bool allowOptimizedExpansion, out bool nullable)
    {
        return sqlExpression switch
        {
            DuckDBAnyExpression e => VisitAny(e, allowOptimizedExpansion, out nullable),
            DuckDBBinaryExpression e => VisitBinary(e, allowOptimizedExpansion, out nullable),
            DuckDBArrayIndexExpression e => VisitArrayIndex(e, allowOptimizedExpansion, out nullable),
            DuckDBArraySliceExpression e => VisitArraySlice(e, allowOptimizedExpansion, out nullable),
            _ => base.VisitCustomSqlExpression(sqlExpression, allowOptimizedExpansion, out nullable)
        };
    }

    protected virtual SqlExpression VisitAny(DuckDBAnyExpression anyExpression, bool allowOptimizedExpansion, out bool nullable)
    {
        ArgumentNullException.ThrowIfNull(anyExpression);

        var item = Visit(anyExpression.Item, out var itemNullable);
        var array = Visit(anyExpression.Array, out var entireArrayNullable);

        SqlExpression updated = anyExpression.Update(item, array);

        if (UseRelationalNulls)
        {
            nullable = false;
            return updated;
        }

        nullable = false;

        if (!allowOptimizedExpansion)
        {
            updated = _sqlExpressionFactory.And(updated, _sqlExpressionFactory.IsNotNull(updated));
        }

        if (!itemNullable)
        {
            return updated;
        }

        return _sqlExpressionFactory.OrElse(
            updated,
            _sqlExpressionFactory.AndAlso(
                _sqlExpressionFactory.IsNull(item),
                _sqlExpressionFactory.IsNotNull(
                    _sqlExpressionFactory.Function(
                        "array_position",
                        [array, _sqlExpressionFactory.Constant(null, item.Type, item.TypeMapping)],
                        nullable: true,
                        argumentsPropagateNullability: [false, false],
                        typeof(int)))));
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

    protected virtual SqlExpression VisitArraySlice(
        DuckDBArraySliceExpression arraySliceExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
    {
        ArgumentNullException.ThrowIfNull(arraySliceExpression);

        var array = Visit(arraySliceExpression.Array, allowOptimizedExpansion, out var arrayNullable);
        var lowerBound = Visit(arraySliceExpression.LowerBound, allowOptimizedExpansion, out var lowerBoundNullable);
        var upperBound = Visit(arraySliceExpression.UpperBound, allowOptimizedExpansion, out var upperBoundNullable);

        nullable = arrayNullable || lowerBoundNullable || upperBoundNullable || arraySliceExpression.IsNullable;

        return arraySliceExpression.Update(array, lowerBound, upperBound);
    }
}
