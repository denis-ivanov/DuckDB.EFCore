using DuckDB.EFCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBILikeTranslator : IMethodCallTranslator
{
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBILikeTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }
    
    /// <inheritdoc />
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        bool sensitive;
        if (method.DeclaringType == typeof(DbFunctionsExtensions)
            && method.Name == nameof(DbFunctionsExtensions.Like))
        {
            sensitive = true;
        }
        else if (method.DeclaringType == typeof(DuckDBDbFunctionsExtensions)
                 && method.Name == nameof(DuckDBDbFunctionsExtensions.ILike))
        {
            sensitive = false;
        }
        else
        {
            return null;
        }

        if (arguments is [_, _, _, var escapeChar])
        {
            return sensitive
                ? _sqlExpressionFactory.Like(arguments[1], arguments[2], escapeChar)
                : _sqlExpressionFactory.ILike(arguments[1], arguments[2], escapeChar);
        }

        var (match, pattern) = (arguments[1], arguments[2]);

        if (pattern is SqlConstantExpression { Value: string patternValue }
            && !patternValue.Contains('\\'))
        {
            return sensitive
                ? _sqlExpressionFactory.Like(match, pattern)
                : _sqlExpressionFactory.ILike(match, pattern);
        }

        return sensitive
            ? _sqlExpressionFactory.Like(match, pattern, _sqlExpressionFactory.Constant(string.Empty))
            : _sqlExpressionFactory.ILike(match, pattern, _sqlExpressionFactory.Constant(string.Empty));
    }
}
