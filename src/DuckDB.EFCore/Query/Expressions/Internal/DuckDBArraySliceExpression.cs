using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBArraySliceExpression : SqlExpression, IEquatable<DuckDBArraySliceExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    public DuckDBArraySliceExpression(
        SqlExpression array,
        SqlExpression? lowerBound,
        SqlExpression? upperBound,
        bool nullable,
        Type type,
        RelationalTypeMapping? typeMapping)
        : base(type.UnwrapNullableType(), typeMapping)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (lowerBound is null && upperBound is null)
        {
            throw new ArgumentException("At least one of lowerBound or upperBound must be provided");
        }

        Array = array;
        LowerBound = lowerBound;
        UpperBound = upperBound;
        IsNullable = nullable;
    }

    public virtual SqlExpression Array { get; }

    public virtual SqlExpression? LowerBound { get; }

    public virtual SqlExpression? UpperBound { get; }

    public virtual bool IsNullable { get; }

    public virtual DuckDBArraySliceExpression Update(SqlExpression array, SqlExpression? lowerBound, SqlExpression? upperBound)
        => array == Array && lowerBound == LowerBound && upperBound == UpperBound
            ? this
            : new DuckDBArraySliceExpression(array, lowerBound, upperBound, IsNullable, Type, TypeMapping);

    public override Expression Quote()
        => New(
            _quotingConstructor ??= typeof(DuckDBArraySliceExpression).GetConstructor(
                [typeof(SqlExpression), typeof(SqlExpression), typeof(SqlExpression), typeof(bool), typeof(Type), typeof(RelationalTypeMapping)])!,
            Array.Quote(),
            RelationalExpressionQuotingUtilities.QuoteOrNull(LowerBound),
            RelationalExpressionQuotingUtilities.QuoteOrNull(UpperBound),
            Constant(IsNullable),
            Constant(Type),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));

    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => Update(
            (SqlExpression)visitor.Visit(Array),
            (SqlExpression?)visitor.Visit(LowerBound),
            (SqlExpression?)visitor.Visit(UpperBound));

    public virtual bool Equals(DuckDBArraySliceExpression? other)
        => ReferenceEquals(this, other)
            || other is not null
            && base.Equals(other)
            && Array.Equals(other.Array)
            && (LowerBound is null ? other.LowerBound is null : LowerBound.Equals(other.LowerBound))
            && (UpperBound is null ? other.UpperBound is null : UpperBound.Equals(other.UpperBound))
            && IsNullable == other.IsNullable;

    public override bool Equals(object? obj)
        => obj is DuckDBArraySliceExpression e && Equals(e);

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Array, LowerBound, UpperBound);

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Visit(Array);
        expressionPrinter.Append("[");
        expressionPrinter.Visit(LowerBound);
        expressionPrinter.Append(":");
        expressionPrinter.Visit(UpperBound);
        expressionPrinter.Append("]");
    }

    public override string ToString()
        => $"{Array}[{LowerBound}:{UpperBound}]";
}