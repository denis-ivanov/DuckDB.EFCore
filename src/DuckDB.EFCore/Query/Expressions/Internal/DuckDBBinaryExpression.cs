using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBBinaryExpression : SqlExpression
{
    private static ConstructorInfo? _quotingConstructor;

    public DuckDBBinaryExpression(
        ExpressionType operatorType,
        SqlExpression left,
        SqlExpression right,
        Type type,
        RelationalTypeMapping? typeMapping = null)
        : base(type, typeMapping)
    {
        if (!IsValidOperator(operatorType))
        {
            throw new InvalidOperationException("Invalid operator type for binary expression: " + operatorType);
        }
        
        OperatorType = operatorType;
        Left = left;
        Right = right;
    }
    
    public virtual ExpressionType OperatorType { get; }
    
    public virtual SqlExpression Left { get; set; }
    
    public virtual SqlExpression Right { get; set; }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        var left = (SqlExpression)visitor.Visit(Left);
        var right = (SqlExpression)visitor.Visit(Right);
        
        return Update(left, right);
    }

    public virtual DuckDBBinaryExpression Update(SqlExpression left, SqlExpression right)
    {
        return left != Left || right != Right
            ? new DuckDBBinaryExpression(OperatorType, left, Right, Type, TypeMapping)
            : this;
    }

    internal static bool IsValidOperator(ExpressionType operatorType)
    {
        switch (operatorType)
        {
            case ExpressionType.LeftShift:
            case ExpressionType.RightShift:
                return true;
            default:
                return false;
        }
    }
    
    public override Expression Quote()
        => New(
            _quotingConstructor ??= typeof(DuckDBBinaryExpression).GetConstructor(
                [typeof(ExpressionType), typeof(SqlExpression), typeof(SqlExpression), typeof(Type), typeof(RelationalTypeMapping)])!,
            Constant(OperatorType),
            Left.Quote(),
            Right.Quote(),
            Constant(Type),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));
    
    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        var requiresBrackets = RequiresBrackets(Left);

        if (requiresBrackets)
        {
            expressionPrinter.Append("(");
        }

        expressionPrinter.Visit(Left);

        if (requiresBrackets)
        {
            expressionPrinter.Append(")");
        }

        expressionPrinter.Append(expressionPrinter.GenerateBinaryOperator(OperatorType));

        requiresBrackets = RequiresBrackets(Right);

        if (requiresBrackets)
        {
            expressionPrinter.Append("(");
        }

        expressionPrinter.Visit(Right);

        if (requiresBrackets)
        {
            expressionPrinter.Append(")");
        }

        static bool RequiresBrackets(SqlExpression expression)
            => expression is DuckDBBinaryExpression or LikeExpression;
    }

    public override bool Equals(object? obj)
        => obj != null
           && (ReferenceEquals(this, obj)
               || obj is DuckDBBinaryExpression sqlBinaryExpression
               && Equals(sqlBinaryExpression));

    private bool Equals(DuckDBBinaryExpression sqlBinaryExpression)
        => base.Equals(sqlBinaryExpression)
           && OperatorType == sqlBinaryExpression.OperatorType
           && Left.Equals(sqlBinaryExpression.Left)
           && Right.Equals(sqlBinaryExpression.Right);

    /// <inheritdoc />
    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), OperatorType, Left, Right);
}
