using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBArrayIndexExpression : SqlExpression, IEquatable<DuckDBArrayIndexExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    public DuckDBArrayIndexExpression(
        SqlExpression array,
        SqlExpression index,
        bool nullable,
        Type type,
        RelationalTypeMapping? typeMapping)
        : base(type.UnwrapNullableType(), typeMapping)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentNullException.ThrowIfNull(index);
        
        if (!array.Type.TryGetElementType(out var elementType))
        {
            throw new ArgumentException("Array expression must of an array type", nameof(array));
        }

        if (type.UnwrapNullableType() != elementType.UnwrapNullableType())
        {
            throw new ArgumentException($"Mismatch between array type ({array.Type.Name}) and expression type ({type})");
        }

        if (index.Type != typeof(int))
        {
            throw new ArgumentException("Index expression must of type int", nameof(index));
        }

        Array = array;
        Index = index;
        IsNullable = nullable;
    }
    
    public virtual SqlExpression Array { get; }

    public virtual SqlExpression Index { get; }

    public virtual bool IsNullable { get; set; }

    public virtual DuckDBArrayIndexExpression Update(SqlExpression array, SqlExpression index)
    {
        return array == Array && index == Index
            ? this
            : new DuckDBArrayIndexExpression(array, index, IsNullable, Type, TypeMapping);
    }

    public override Expression Quote()
    {
        return New(
            _quotingConstructor ??= typeof(DuckDBArrayIndexExpression).GetConstructor(
                [typeof(SqlExpression), typeof(SqlExpression), typeof(bool), typeof(Type), typeof(RelationalTypeMapping)])!,
            Array.Quote(),
            Index.Quote(),
            Constant(IsNullable),
            Constant(Type),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));
    }
    
    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => Update((SqlExpression)visitor.Visit(Array), (SqlExpression)visitor.Visit(Index));

    public virtual bool Equals(DuckDBArrayIndexExpression? other)
        => ReferenceEquals(this, other)
           || other is not null
           && base.Equals(other)
           && Array.Equals(other.Array)
           && Index.Equals(other.Index)
           && IsNullable == other.IsNullable;

    public override bool Equals(object? obj)
        => obj is DuckDBArrayIndexExpression e && Equals(e);

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Array, Index, IsNullable);

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Visit(Array);
        expressionPrinter.Append("[");
        expressionPrinter.Visit(Index);
        expressionPrinter.Append("]");
    }

    public override string ToString() => $"{Array}[{Index}]";
}
