using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBQuerySqlGenerator : QuerySqlGenerator
{
    public DuckDBQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override void GenerateLimitOffset(SelectExpression selectExpression)
    {
        if (selectExpression.Limit != null)
        {
            Sql.AppendLine().Append("LIMIT ");
            Visit(selectExpression.Limit);
        }

        if (selectExpression.Offset != null)
        {
            Sql.AppendLine().Append("OFFSET ");
            Visit(selectExpression.Offset);
        }
    }

    protected override string GetOperator(SqlBinaryExpression binaryExpression)
    {
        if (binaryExpression.OperatorType == ExpressionType.Add && binaryExpression.Type == typeof(string))
        {
            return " || ";
        }

        if (binaryExpression.OperatorType == ExpressionType.LeftShift)
        {
            return " << ";
        }

        if (binaryExpression.OperatorType == ExpressionType.RightShift)
        {
            return " >> ";
        }

        return base.GetOperator(binaryExpression);
    }
}
