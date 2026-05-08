using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Query.Expressions.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
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
    private readonly ServiceProvider? _serviceProvider;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBQuerySqlGenerator(
        QuerySqlGeneratorDependencies dependencies,
        bool reverseNullOrderingEnabled,
        ServiceProvider? serviceProvider)
        : base(dependencies)
    {
        _reverseNullOrderingEnabled = reverseNullOrderingEnabled;
        _serviceProvider = serviceProvider;
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
    protected override Expression VisitTableValuedFunction(TableValuedFunctionExpression tableValuedFunctionExpression)
    {
        if (tableValuedFunctionExpression is DuckDBUnnestExpression unnestExpression)
        {
            return VisitUnnest(unnestExpression);
        }

        return base.VisitTableValuedFunction(tableValuedFunctionExpression);
    }

    /// <inheritdoc />
    protected override Expression VisitTable(TableExpression tableExpression)
    {
        var parquetPath = tableExpression.Table.EntityTypeMappings
            .Select(m => m.TypeBase)
            .OfType<IEntityType>()
            .Select(GetParquetPath)
            .FirstOrDefault(p => !string.IsNullOrEmpty(p));

        if (string.IsNullOrEmpty(parquetPath))
        {
            return base.VisitTable(tableExpression);
        }

        var quotedParquetPath = $"'{parquetPath.Replace("'", "''")}'";

        Sql.Append("read_parquet(")
            .Append(quotedParquetPath)
            .Append(")")
            .Append(AliasSeparator)
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableExpression.Alias));

        return tableExpression;
    }

    private string? GetParquetPath(IEntityType entityType)
    {
        var parquetPath = entityType.GetParquetPath();
        if (!string.IsNullOrEmpty(parquetPath))
        {
            return parquetPath;
        }

        var parquetPathFactoryValue = entityType.GetParquetPathFactoryValue();
        if (!string.IsNullOrEmpty(parquetPathFactoryValue))
        {
            return parquetPathFactoryValue;
        }

        var parquetPathFactory = entityType.GetParquetPathFactory();
        if (parquetPathFactory is null)
        {
            return null;
        }

        if (_serviceProvider is null)
        {
            throw new InvalidOperationException($"A service provider is required to resolve the parquet path for entity '{entityType.DisplayName()}'.");
        }

        var resolvedPath = parquetPathFactory(_serviceProvider);
        if (string.IsNullOrWhiteSpace(resolvedPath))
        {
            throw new InvalidOperationException($"The parquet path factory for entity '{entityType.DisplayName()}' returned an empty path.");
        }

        return resolvedPath;
    }

    /// <summary>
    ///     Generates SQL for a DuckDB <c>unnest</c> expression.
    ///     <para>
    ///         Without ordinality: <c>unnest(array) AS "alias"("colname")</c>
    ///     </para>
    ///     <para>
    ///         With ordinality: <c>(SELECT unnest(array) AS "colname", generate_subscripts(array, 1) AS "ordinality") AS "alias"</c>
    ///     </para>
    /// </summary>
    protected virtual Expression VisitUnnest(DuckDBUnnestExpression expression)
    {
        if (expression.WithOrdinality)
        {
            // DuckDB does not support WITH ORDINALITY; use generate_subscripts instead.
            // Wrap in a subquery so that the ordinality column can be referenced by the outer query.
            Sql.Append("(SELECT unnest(");
            Visit(expression.Array);
            Sql.Append(")");

            if (expression.ColumnInfos is { Count: > 0 } colInfosOrd)
            {
                Sql.Append(" AS ")
                    .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(colInfosOrd[0].Name));
            }

            Sql.Append(", generate_subscripts(");
            Visit(expression.Array);
            Sql.Append(", 1) AS ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier("ordinality"))
                .Append(")");
        }
        else
        {
            Sql.Append("unnest(");
            Visit(expression.Array);
            Sql.Append(")");
        }

        Sql.Append(AliasSeparator)
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(expression.Alias));

        if (!expression.WithOrdinality && expression.ColumnInfos is { Count: > 0 } colInfos)
        {
            Sql.Append("(");
            for (var i = 0; i < colInfos.Count; i++)
            {
                if (i > 0)
                {
                    Sql.Append(", ");
                }

                Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(colInfos[i].Name));
            }

            Sql.Append(")");
        }

        return expression;
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
        var path = jsonScalarExpression.Path;
        if (path.Count == 0)
        {
            Visit(jsonScalarExpression.Json);
            return jsonScalarExpression;
        }

        var needsCast = jsonScalarExpression.TypeMapping is not (null or StringTypeMapping or DuckDBJsonTypeMapping);

        if (needsCast)
        {
            Sql.Append("CAST(");
        }

        Visit(jsonScalarExpression.Json);

        var inJsonpathString = false;

        for (var i = 0; i < path.Count; i++)
        {
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

        if (needsCast)
        {
            Sql.Append(" AS ");
            Sql.Append(jsonScalarExpression.TypeMapping!.StoreType);
            Sql.Append(")");
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
