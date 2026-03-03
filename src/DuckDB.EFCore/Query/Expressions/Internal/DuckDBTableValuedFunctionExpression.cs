using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBTableValuedFunctionExpression : TableValuedFunctionExpression, IEquatable<DuckDBTableValuedFunctionExpression>
{
    public virtual IReadOnlyList<ColumnInfo>? ColumnInfos { get; }

    public virtual bool WithOrdinality { get; }

    public DuckDBTableValuedFunctionExpression(
        string alias,
        string name,
        IReadOnlyList<SqlExpression> arguments,
        IReadOnlyList<ColumnInfo>? columnInfos = null,
        bool withOrdinality = true)
        : base(alias, name, schema: null, builtIn: true, arguments)
    {
        ColumnInfos = columnInfos;
        WithOrdinality = withOrdinality;
    }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => visitor.VisitAndConvert(Arguments) is var visitedArguments && visitedArguments == Arguments
            ? this
            : new DuckDBTableValuedFunctionExpression(
                Alias,
                Name,
                visitedArguments,
                ColumnInfos,
                WithOrdinality);


    public override TableValuedFunctionExpression Update(IReadOnlyList<SqlExpression> arguments)
    {
        return arguments.SequenceEqual(Arguments, ReferenceEqualityComparer.Instance)
            ? this
            : new DuckDBTableValuedFunctionExpression(Alias, Name, arguments, ColumnInfos, WithOrdinality);
    }

    public override TableExpressionBase Clone(string? alias, ExpressionVisitor cloningExpressionVisitor)
    {
        var arguments = new SqlExpression[Arguments.Count];

        for (var i = 0; i < Arguments.Count; i++)
        {
            arguments[i] = (SqlExpression)cloningExpressionVisitor.Visit(Arguments[i]);
        }

        return new DuckDBTableValuedFunctionExpression(Alias, Name, arguments, ColumnInfos, WithOrdinality);
    }

    public override TableValuedFunctionExpression WithAlias(string newAlias)
    {
        return new DuckDBTableValuedFunctionExpression(newAlias, Name, Arguments, ColumnInfos, WithOrdinality);
    }

    public virtual DuckDBTableValuedFunctionExpression WithColumnInfos(IReadOnlyList<ColumnInfo>? columnInfos)
    {
        return new DuckDBTableValuedFunctionExpression(Alias, Name, Arguments, columnInfos, WithOrdinality);
    }

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Append(Name);
        expressionPrinter.Append("(");
        expressionPrinter.VisitCollection(Arguments);
        expressionPrinter.Append(")");

        if (WithOrdinality)
        {
            expressionPrinter.Append(" WITH ORDINALITY");
        }

        PrintAnnotations(expressionPrinter);

        expressionPrinter.Append(" AS ").Append(Alias);

        if (ColumnInfos is not null)
        {
            expressionPrinter.Append("(");

            var isFirst = true;

            foreach (var column in ColumnInfos)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    expressionPrinter.Append(", ");
                }

                expressionPrinter.Append(column.Name);

                if (column.TypeMapping is not null)
                {
                    expressionPrinter.Append(" ").Append(column.TypeMapping.StoreType);
                }
            }

            expressionPrinter.Append(")");
        }
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(obj, this) || obj is DuckDBTableValuedFunctionExpression e && Equals(e);
    }

    public bool Equals(DuckDBTableValuedFunctionExpression? expression)
        => base.Equals(expression)
           && (
               expression.ColumnInfos is null && ColumnInfos is null
               || expression.ColumnInfos is not null && ColumnInfos is not null && expression.ColumnInfos.SequenceEqual(ColumnInfos))
           && WithOrdinality == expression.WithOrdinality;

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public readonly record struct ColumnInfo(string Name, RelationalTypeMapping? TypeMapping = null);
}