using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBAnyExpression : SqlExpression, IEquatable<DuckDBAnyExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    public override Type Type
        => typeof(bool);

    public virtual SqlExpression Item { get; }

    public virtual SqlExpression Array { get; }

    public DuckDBAnyExpression(
        SqlExpression item,
        SqlExpression array,
        RelationalTypeMapping? typeMapping)
        : base(typeof(bool), typeMapping)
    {
        if (array is not SqlConstantExpression { Value: null })
        {
            if (array.Type.TryGetElementType(typeof(IEnumerable<>)) is null)
            {
                throw new ArgumentException("Array expression must be an IEnumerable", nameof(array));
            }
        }

        Item = item;
        Array = array;
    }

    public virtual DuckDBAnyExpression Update(SqlExpression item, SqlExpression array)
        => item != Item || array != Array
            ? new DuckDBAnyExpression(item, array, TypeMapping)
            : this;

    public override Expression Quote()
        => New(
            _quotingConstructor ??= typeof(DuckDBAnyExpression).GetConstructor(
                [typeof(SqlExpression), typeof(SqlExpression), typeof(RelationalTypeMapping)])!,
            Item.Quote(),
            Array.Quote(),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));

    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => Update((SqlExpression)visitor.Visit(Item), (SqlExpression)visitor.Visit(Array));

    public override bool Equals(object? obj)
        => obj is DuckDBAnyExpression e && Equals(e);

    public virtual bool Equals(DuckDBAnyExpression? other)
        => ReferenceEquals(this, other)
            || other is not null
            && base.Equals(other)
            && Item.Equals(other.Item)
            && Array.Equals(other.Array);

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Item, Array);

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Visit(Item);
        expressionPrinter.Append(" = ANY(");
        expressionPrinter.Visit(Array);
        expressionPrinter.Append(")");
    }

    public override string ToString()
        => $"{Item} = ANY({Array})";
}