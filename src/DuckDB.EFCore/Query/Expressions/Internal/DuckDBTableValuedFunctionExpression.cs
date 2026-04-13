using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

/// <summary>
///     An expression that represents a DuckDB <c>unnest</c> function call in a SQL tree.
/// </summary>
public class DuckDBTableValuedFunctionExpression : TableValuedFunctionExpression, IEquatable<DuckDBTableValuedFunctionExpression>
{
    /// <summary>
    ///     The name of the column to be projected out from the <c>unnest</c> call.
    /// </summary>
    /// <remarks>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </remarks>
    public virtual IReadOnlyList<ColumnInfo>? ColumnInfos { get; }

    /// <summary>
    ///     Whether to project an additional ordinality column containing the index of each element in the array.
    /// </summary>
    /// <remarks>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </remarks>
    public virtual bool WithOrdinality { get; }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
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

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => visitor.VisitAndConvert(Arguments) is var visitedArguments && visitedArguments == Arguments
            ? this
            : new DuckDBTableValuedFunctionExpression(
                Alias,
                Name,
                visitedArguments,
                ColumnInfos,
                WithOrdinality);

    /// <inheritdoc />
    public override TableValuedFunctionExpression Update(IReadOnlyList<SqlExpression> arguments)
    {
        return arguments.SequenceEqual(Arguments, ReferenceEqualityComparer.Instance)
            ? this
            : new DuckDBTableValuedFunctionExpression(Alias, Name, arguments, ColumnInfos, WithOrdinality);
    }

    /// <inheritdoc />
    public override TableExpressionBase Clone(string? alias, ExpressionVisitor cloningExpressionVisitor)
    {
        var arguments = new SqlExpression[Arguments.Count];

        for (var i = 0; i < Arguments.Count; i++)
        {
            arguments[i] = (SqlExpression)cloningExpressionVisitor.Visit(Arguments[i]);
        }

        return new DuckDBTableValuedFunctionExpression(alias ?? Alias, Name, arguments, ColumnInfos, WithOrdinality);
    }

    /// <inheritdoc />
    public override TableValuedFunctionExpression WithAlias(string newAlias)
    {
        return new DuckDBTableValuedFunctionExpression(newAlias, Name, Arguments, ColumnInfos, WithOrdinality);
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual DuckDBTableValuedFunctionExpression WithColumnInfos(IReadOnlyList<ColumnInfo>? columnInfos)
    {
        return new DuckDBTableValuedFunctionExpression(Alias, Name, Arguments, columnInfos, WithOrdinality);
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return ReferenceEquals(obj, this) || obj is DuckDBTableValuedFunctionExpression e && Equals(e);
    }

    /// <inheritdoc />
    public bool Equals(DuckDBTableValuedFunctionExpression? expression)
        => base.Equals(expression)
           && (
               expression.ColumnInfos is null && ColumnInfos is null
               || expression.ColumnInfos is not null && ColumnInfos is not null && expression.ColumnInfos.SequenceEqual(ColumnInfos))
           && WithOrdinality == expression.WithOrdinality;

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public readonly record struct ColumnInfo(string Name, RelationalTypeMapping? TypeMapping = null);
}