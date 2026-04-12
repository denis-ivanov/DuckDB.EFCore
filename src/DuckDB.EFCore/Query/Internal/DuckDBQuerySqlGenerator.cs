using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBQuerySqlGenerator : QuerySqlGenerator
{
    private readonly bool _reverseNullOrderingEnabled;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies, bool reverseNullOrderingEnabled)
        : base(dependencies)
    {
        _reverseNullOrderingEnabled = reverseNullOrderingEnabled;
    }

    /// <inheritdoc />
    protected override void GenerateLimitOffset(SelectExpression selectExpression)
    {
        if (selectExpression.Limit is not null)
        {
            Sql.AppendLine().Append("LIMIT ");
            Visit(selectExpression.Limit);
        }

        if (selectExpression.Offset is not null)
        {
            if (selectExpression.Limit is null)
            {
                Sql.AppendLine();
            }
            else
            {
                Sql.Append(" ");
            }

            Sql.Append("OFFSET ");
            Visit(selectExpression.Offset);
        }
    }

    /// <inheritdoc />
    protected override string GetOperator(SqlBinaryExpression binaryExpression)
    {
        return binaryExpression.OperatorType switch
        {
            ExpressionType.Add when binaryExpression.Type == typeof(string) => " || ",
            ExpressionType.LeftShift => " << ",
            ExpressionType.RightShift => " >> ",
            _ => base.GetOperator(binaryExpression)
        };
    }

    /// <inheritdoc />
    protected override Expression VisitOrdering(OrderingExpression ordering)
    {
        var result = base.VisitOrdering(ordering);

        if (_reverseNullOrderingEnabled)
        {
            Sql.Append(ordering.IsAscending ? " NULLS FIRST" : " NULLS LAST");
        }

        return result;
    }

    /// <inheritdoc />
    protected override Expression VisitExtension(Expression extensionExpression)
    {
        return extensionExpression switch
        {
            DuckDBAnyExpression e => VisitArrayAny(e),
            DuckDBBinaryExpression e => VisitBinary(e),
            DuckDBArrayIndexExpression e => VisitArrayIndex(e),
            DuckDBArraySliceExpression e => VisitArraySlice(e),
            DuckDBJsonEachExpression e => VisitJsonEach(e),
            DuckDBRowValueExpression e => VisitRowValue(e),
            _ => base.VisitExtension(extensionExpression)
        };
    }

    /// <inheritdoc />
    protected override Expression VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression)
    {
        return sqlBinaryExpression.OperatorType switch
        {
            ExpressionType.ArrayIndex => VisitArrayIndex(sqlBinaryExpression),
            _ => base.VisitSqlBinary(sqlBinaryExpression)
        };
    }

    /// <inheritdoc />
    protected override Expression VisitCrossApply(CrossApplyExpression crossApplyExpression)
    {
        Sql.Append("CROSS JOIN LATERAL ");
        Visit(crossApplyExpression.Table);

        return crossApplyExpression;
    }

    /// <inheritdoc />
    protected override Expression VisitOuterApply(OuterApplyExpression outerApplyExpression)
    {
        Sql.Append("LEFT JOIN LATERAL ");
        Visit(outerApplyExpression.Table);
        Sql.Append(" ON true");

        return outerApplyExpression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitArrayAny(DuckDBAnyExpression expression)
    {
        Visit(expression.Item);
        
        Sql.Append(" = ANY(");
        Visit(expression.Array);
        Sql.Append(")");
        return expression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitArrayIndex(SqlBinaryExpression sqlBinaryExpression)
    {
        Visit(sqlBinaryExpression.Left);
        Sql.Append("[");
        Visit(sqlBinaryExpression.Right);
        Sql.Append("]");
        return sqlBinaryExpression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitArrayIndex(DuckDBArrayIndexExpression expression)
    {
        var requiresParentheses = RequiresParentheses(expression, expression.Array);

        if (requiresParentheses)
        {
            Sql.Append("(");
        }

        Visit(expression.Array);

        if (requiresParentheses)
        {
            Sql.Append(")");
        }

        Sql.Append("[");
        Visit(expression.Index);
        Sql.Append("]");
        return expression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitArraySlice(DuckDBArraySliceExpression expression)
    {
        var requiresParentheses = RequiresParentheses(expression, expression.Array);

        if (requiresParentheses)
        {
            Sql.Append("(");
        }

        Visit(expression.Array);

        if (requiresParentheses)
        {
            Sql.Append(")");
        }

        Sql.Append("[");
        Visit(expression.LowerBound);
        Sql.Append(":");
        Visit(expression.UpperBound);
        Sql.Append("]");
        return expression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitBinary(DuckDBBinaryExpression binaryExpression)
    {
        switch (binaryExpression.OperatorType)
        {
            case ExpressionType.LeftShift:
                Sql.Append("CASE WHEN (");
                Visit(binaryExpression.Left);
                Sql.Append(" >= 0) THEN ");
                Visit(binaryExpression.Left);
                Sql.Append(" << ");
                Visit(binaryExpression.Right);
                Sql.Append(" ELSE NULL END");
                break;

            case ExpressionType.RightShift:
                Sql.Append("CASE WHEN (");
                Visit(binaryExpression.Left);
                Sql.Append(" >= 0) THEN ");
                Visit(binaryExpression.Left);
                Sql.Append(" >> ");
                Visit(binaryExpression.Right);
                Sql.Append(" ELSE NULL END");
                break;

            default:
                throw new UnreachableException("Unknown binary operator");
        }

        return binaryExpression;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual Expression VisitRowValue(DuckDBRowValueExpression rowValueExpression)
    {
        Sql.Append("(");

        var values = rowValueExpression.Values;
        var count = values.Count;
        for (var i = 0; i < count; i++)
        {
            Visit(values[i]);

            if (i < count - 1)
            {
                Sql.Append(", ");
            }
        }

        Sql.Append(")");

        return rowValueExpression;
    }

    protected virtual Expression VisitJsonEach(DuckDBJsonEachExpression expression)
    {
        Sql.Append("json_each(");

        Visit(expression.JsonExpression);

        var path = expression.Path;

        if (path is not null)
        {
            Sql.Append(", ");

            GenerateJsonPath(path);
        }

        Sql.Append(")");

        Sql.Append(AliasSeparator).Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(expression.Alias));

        return expression;
    }
    
    private void GenerateJsonPath(IReadOnlyList<PathSegment> path)
    {
        Sql.Append("'$");

        for (var i = 0; i < path.Count; i++)
        {
            switch (path[i])
            {
                case { PropertyName: { } propertyName }:
                    Sql.Append(".").Append(propertyName);
                    break;

                case { ArrayIndex: { } arrayIndex }:
                    Sql.Append("[");

                    if (arrayIndex is SqlConstantExpression)
                    {
                        Visit(arrayIndex);
                    }
                    else
                    {
                        Sql.Append("' || ");
                        Visit(arrayIndex);
                        Sql.Append(" || '");
                    }

                    Sql.Append("]");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        Sql.Append("'");
    }

    protected override Expression VisitJsonScalar(JsonScalarExpression jsonScalarExpression)
    {
        Visit(jsonScalarExpression.Json);

        // TODO: Stop producing empty JsonScalarExpressions, #30768
        var path = jsonScalarExpression.Path;
        if (path.Count == 0)
        {
            return jsonScalarExpression;
        }

        var inJsonpathString = false;

        for (var i = 0; i < path.Count; i++)
        {
            // Note that we don't use GenerateJsonPath() to generate the JSONPATH string here, since we take advantage of SQLite's ->> operator
            // for JsonScalarExpression.
            var pathSegment = path[i];
            var isLast = i == path.Count - 1;

            switch (pathSegment)
            {
                case { PropertyName: { } propertyName }:
                    if (inJsonpathString)
                    {
                        Sql.Append(".").Append(Dependencies.SqlGenerationHelper.DelimitJsonPathElement(propertyName));
                        continue;
                    }

                    Sql.Append(" ->> ");

                    // No need to start a $. JSONPATH string if we're the last segment or the next segment isn't a constant
                    if (isLast || path[i + 1] is { ArrayIndex: not null and not SqlConstantExpression })
                    {
                        Sql.Append("'").Append(Dependencies.SqlGenerationHelper.DelimitJsonPathElement(propertyName)).Append("'");
                        continue;
                    }

                    Sql.Append("'$.").Append(Dependencies.SqlGenerationHelper.DelimitJsonPathElement(propertyName));
                    inJsonpathString = true;
                    continue;

                case { ArrayIndex: SqlConstantExpression arrayIndex }:
                    if (inJsonpathString)
                    {
                        Sql.Append("[");
                        Visit(pathSegment.ArrayIndex);
                        Sql.Append("]");
                        continue;
                    }

                    Sql.Append(" ->> ");

                    // No need to start a $. JSONPATH string if we're the last segment or the next segment isn't a constant
                    if (isLast || path[i + 1] is { ArrayIndex: not null and not SqlConstantExpression })
                    {
                        Visit(arrayIndex);
                        continue;
                    }

                    Sql.Append("'$[");
                    Visit(arrayIndex);
                    Sql.Append("]");
                    inJsonpathString = true;
                    continue;

                default:
                    if (inJsonpathString)
                    {
                        Sql.Append("'");
                        inJsonpathString = false;
                    }

                    Sql.Append(" ->> ");

                    Debug.Assert(pathSegment.ArrayIndex is not null);

                    var requiresParentheses = RequiresParentheses(jsonScalarExpression, pathSegment.ArrayIndex);
                    if (requiresParentheses)
                    {
                        Sql.Append("(");
                    }

                    Visit(pathSegment.ArrayIndex);

                    if (requiresParentheses)
                    {
                        Sql.Append(")");
                    }

                    continue;
            }
        }

        if (inJsonpathString)
        {
            Sql.Append("'");
        }

        return jsonScalarExpression;
    }

    /// <inheritdoc />
    protected override void GenerateValues(ValuesExpression valuesExpression)
    {
        if (valuesExpression.RowValues is null)
        {
            throw new UnreachableException();
        }

        if (valuesExpression.RowValues.Count == 0)
        {
            throw new InvalidOperationException(RelationalStrings.EmptyCollectionNotSupportedAsInlineQueryRoot);
        }

        var rowValues = valuesExpression.RowValues;

        Sql.Append("VALUES ");

        for (var i = 0; i < rowValues.Count; i++)
        {
            if (i > 0)
            {
                Sql.Append(", ");
            }

            Visit(valuesExpression.RowValues[i]);
        }
    }

    /// <inheritdoc />
    protected override Expression VisitValues(ValuesExpression valuesExpression)
    {
        base.VisitValues(valuesExpression);

        Sql.Append("(");

        for (var i = 0; i < valuesExpression.ColumnNames.Count; i++)
        {
            if (i > 0)
            {
                Sql.Append(", ");
            }

            Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(valuesExpression.ColumnNames[i]));
        }

        Sql.Append(")");

        return valuesExpression;
    }
}
