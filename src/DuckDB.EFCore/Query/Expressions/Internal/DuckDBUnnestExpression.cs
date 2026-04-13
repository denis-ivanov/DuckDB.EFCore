using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

/// <summary>
///     An expression that represents a DuckDB <c>unnest</c> function call in a SQL tree.
/// </summary>
public class DuckDBUnnestExpression : DuckDBTableValuedFunctionExpression
{
    /// <summary>
    ///     The array to be un-nested into a table.
    /// </summary>
    /// <remarks>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </remarks>
    public virtual SqlExpression Array => Arguments[0];

    /// <summary>
    ///     The name of the column to be projected out from the <c>unnest</c> call.
    /// </summary>
    /// <remarks>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </remarks>
    public virtual string ColumnName => ColumnInfos![0].Name;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBUnnestExpression(string alias, SqlExpression array, string columnName, bool withOrdinality = true)
        : this(alias, array, new ColumnInfo(columnName), withOrdinality)
    {
    }

    private DuckDBUnnestExpression(string alias, SqlExpression array, ColumnInfo? columnInfo,
        bool withOrdinality = true)
        : base(alias, "unnest", [array], columnInfo is null ? null : [columnInfo.Value], withOrdinality)
    {
    }

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        return visitor.Visit(Array) is var visitedArray && visitedArray == Array
            ? this
            : new DuckDBUnnestExpression(Alias, (SqlExpression)visitedArray, ColumnName, WithOrdinality);
    }

    /// <inheritdoc />
    public override TableValuedFunctionExpression Update(IReadOnlyList<SqlExpression> arguments)
    {
        return arguments is [var singleArgument]
            ? Update(singleArgument)
            : throw new ArgumentException();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual DuckDBUnnestExpression Update(SqlExpression array)
    {
        return array == Array
            ? this
            : new DuckDBUnnestExpression(Alias, array, ColumnName, WithOrdinality);
    }

    /// <inheritdoc />
    public override TableExpressionBase Clone(string? alias, ExpressionVisitor cloningExpressionVisitor)
    {
        return new DuckDBUnnestExpression(alias!, (SqlExpression)cloningExpressionVisitor.Visit(Array), ColumnName, WithOrdinality);
    }

    /// <inheritdoc />
    public override TableValuedFunctionExpression WithAlias(string newAlias)
    {
        return new DuckDBUnnestExpression(newAlias, Array, ColumnName, WithOrdinality);
    }

    /// <inheritdoc />
    public override DuckDBTableValuedFunctionExpression WithColumnInfos(IReadOnlyList<ColumnInfo>? columnInfos)
    {
        return new DuckDBUnnestExpression(Alias,
            Array,
            columnInfos switch
            {
                [] => null,
                [var columnInfo] => columnInfo,
                _ => throw new ArgumentException()
            },
            WithOrdinality);
    }
}
