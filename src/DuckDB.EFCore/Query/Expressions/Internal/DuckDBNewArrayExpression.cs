using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBNewArrayExpression : SqlExpression
{
    private static ConstructorInfo? _quotingConstructor;
    
    public DuckDBNewArrayExpression(IReadOnlyList<SqlExpression> expressions, Type type, RelationalTypeMapping? typeMapping)
        : base(type, typeMapping)
    {
        ArgumentNullException.ThrowIfNull(expressions);
        
        if (type.TryGetElementType(typeof(IEnumerable<>)) is null)
        {
            throw new ArgumentException($"{nameof(DuckDBNewArrayExpression)} must have an IEnumerable<T> type");
        }

        Expressions = expressions;
    }

    public virtual IReadOnlyList<SqlExpression> Expressions { get; }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        List<SqlExpression>? newExpressions = null;

        for (var i = 0; i < Expressions.Count; i++)
        {
            var expression = Expressions[i];
            var visitedExpression = (SqlExpression)visitor.Visit(expression);

            if (visitedExpression != expression && newExpressions is null)
            {
                newExpressions = [];

                for (var j = 0; j < i; j++)
                {
                    newExpressions.Add(Expressions[j]);
                }
            }

            newExpressions?.Add(visitedExpression);
        }

        return newExpressions is null
            ? this
            : new DuckDBNewArrayExpression(newExpressions, Type, TypeMapping);
    }

    public virtual DuckDBNewArrayExpression Update(IReadOnlyList<SqlExpression> expressions)
    {
        ArgumentNullException.ThrowIfNull(expressions);

        return expressions == Expressions
            ? this
            : new DuckDBNewArrayExpression(expressions, Type, TypeMapping);
    }

    public override Expression Quote()
    {
        return New(
            _quotingConstructor ??= typeof(DuckDBNewArrayExpression).GetConstructor(
                [typeof(IReadOnlyList<SqlExpression>), typeof(Type), typeof(RelationalTypeMapping)])!,
            NewArrayInit(typeof(SqlExpression), initializers: Expressions.Select(a => a.Quote())),
            Constant(Type),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));
    }

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        ArgumentNullException.ThrowIfNull(expressionPrinter);

        expressionPrinter.Append("[");

        var first = true;

        foreach (SqlExpression expression in Expressions)
        {
            if (!first)
            {
                expressionPrinter.Append(", ");
            }

            first = false;
            expressionPrinter.Visit(expression);
        }

        expressionPrinter.Append("]");

        if (TypeMapping != null)
        {
            expressionPrinter.Append("::").Append(TypeMapping.StoreType).Append("[]");
        }
    }

    public override bool Equals(object? obj)
        => obj is not null
           && (ReferenceEquals(this, obj)
               || obj is DuckDBNewArrayExpression sqlBinaryExpression
               && Equals(sqlBinaryExpression));

    private bool Equals(DuckDBNewArrayExpression newArrayExpression)
        => base.Equals(newArrayExpression)
           && Expressions.SequenceEqual(newArrayExpression.Expressions);

    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(base.GetHashCode());

        for (var i = 0; i < Expressions.Count; i++)
        {
            hash.Add(Expressions[i]);
        }

        return hash.ToHashCode();
    }
}
