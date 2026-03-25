using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBUnnestPostprocessor : ExpressionVisitor
{
    [return: NotNullIfNotNull("expression")]
    public override Expression? Visit(Expression? expression)
    {
        switch (expression)
        {
            case ShapedQueryExpression shapedQueryExpression:
                return shapedQueryExpression
                    .UpdateQueryExpression(Visit(shapedQueryExpression.QueryExpression))
                    .UpdateShaperExpression(Visit(shapedQueryExpression.ShaperExpression));

            case SelectExpression selectExpression:
            {
                TableExpressionBase[]? newTables = null;

                var orderings = selectExpression.Orderings;

                for (var i = 0; i < selectExpression.Tables.Count; i++)
                {
                    var table = selectExpression.Tables[i];
                    var unwrappedTable = table.UnwrapJoin();

                    // Find any unnest table which does not have any references to its ordinality column in the projection or orderings
                    // (this is where they may appear); if found, remove the ordinality column from the unnest call.
                    // Note that if the ordinality column is the first ordering, we can still remove it, since unnest already returns
                    // ordered results.
                    if (unwrappedTable is DuckDBUnnestExpression unnest
                        && !selectExpression.Orderings.Skip(1).Select(o => o.Expression)
                            .Concat(selectExpression.Projection.Select(p => p.Expression))
                            .Any(IsOrdinalityColumn))
                    {
                        if (newTables is null)
                        {
                            newTables = new TableExpressionBase[selectExpression.Tables.Count];

                            for (var j = 0; j < i; j++)
                            {
                                newTables[j] = selectExpression.Tables[j];
                            }
                        }

                        var newUnnest = new DuckDBUnnestExpression(unnest.Alias, unnest.Array, unnest.ColumnName, withOrdinality: false);

                        newTables[i] = table switch
                        {
                            JoinExpressionBase j => j.Update(newUnnest),
                            DuckDBUnnestExpression => newUnnest,
                            _ => throw new UnreachableException()
                        };

                        if (orderings.Count > 0 && IsOrdinalityColumn(orderings[0].Expression))
                        {
                            orderings = orderings.Skip(1).ToList();
                        }
                    }

                    bool IsOrdinalityColumn(SqlExpression expression)
                        => expression is ColumnExpression { Name: "ordinality" } ordinalityColumn
                            && ordinalityColumn.TableAlias == unwrappedTable.Alias;
                }

                return base.Visit(
                    newTables is null
                        ? selectExpression
                        : selectExpression.Update(
                            newTables,
                            selectExpression.Predicate,
                            selectExpression.GroupBy,
                            selectExpression.Having,
                            selectExpression.Projection,
                            orderings,
                            selectExpression.Offset,
                            selectExpression.Limit));
            }

            default:
                return base.Visit(expression);
        }
    }
}