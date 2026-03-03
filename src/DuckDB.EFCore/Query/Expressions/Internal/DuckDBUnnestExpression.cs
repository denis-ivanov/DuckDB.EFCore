using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Expressions.Internal;

public class DuckDBUnnestExpression : DuckDBTableValuedFunctionExpression
{
    public virtual SqlExpression Array => Arguments[0];

    public virtual string ColumnName => ColumnInfos![0].Name;

    public DuckDBUnnestExpression(string alias, SqlExpression array, string columnName, bool withOrdinality = true)
        : this(alias, array, new ColumnInfo(columnName), withOrdinality)
    {
    }

    private DuckDBUnnestExpression(string alias, SqlExpression array, ColumnInfo? columnInfo,
        bool withOrdinality = true)
        : base(alias, "unnest", [array], columnInfo is null ? null : [columnInfo.Value], withOrdinality)
    {
    }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        return visitor.Visit(Array) is var visitedArray && visitedArray == Array
            ? this
            : new DuckDBUnnestExpression(Alias, (SqlExpression)visitedArray, ColumnName, WithOrdinality);
    }

    public override TableValuedFunctionExpression Update(IReadOnlyList<SqlExpression> arguments)
    {
        return arguments is [var singleArgument]
            ? Update(singleArgument)
            : throw new ArgumentException();
    }

    public virtual DuckDBUnnestExpression Update(SqlExpression array)
    {
        return array == Array
            ? this
            : new DuckDBUnnestExpression(Alias, array, ColumnName, WithOrdinality);
    }

    public override TableExpressionBase Clone(string? alias, ExpressionVisitor cloningExpressionVisitor)
    {
        return new DuckDBUnnestExpression(alias!, (SqlExpression)cloningExpressionVisitor.Visit(Array), ColumnName, WithOrdinality);
    }

    public override TableValuedFunctionExpression WithAlias(string newAlias)
    {
        return new DuckDBUnnestExpression(newAlias, Array, ColumnName, WithOrdinality);
    }

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