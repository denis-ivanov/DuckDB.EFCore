using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBRegexMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo IsMatch = typeof(Regex).GetMethod(nameof(Regex.IsMatch), [typeof(string), typeof(string)])!;

    private static readonly MethodInfo RegexExtractMatchAndPattern =
        typeof(DuckDBDbFunctionsExtensions).GetMethod(nameof(DuckDBDbFunctionsExtensions.RegexExtract), [typeof(DbFunctions), typeof(string), typeof(string)])!;

    private static readonly MethodInfo RegexExtractWithGroup =
        typeof(DuckDBDbFunctionsExtensions).GetMethod(nameof(DuckDBDbFunctionsExtensions.RegexExtract), [typeof(DbFunctions), typeof(string), typeof(string), typeof(int)])!;

    private static readonly MethodInfo RegexExtractWithGroupAndOptions =
        typeof(DuckDBDbFunctionsExtensions).GetMethod(nameof(DuckDBDbFunctionsExtensions.RegexExtract), [typeof(DbFunctions), typeof(string), typeof(string), typeof(int), typeof(string)])!;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBRegexMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == IsMatch)
        {
            return _sqlExpressionFactory.Function(
                name: "regexp_matches",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(bool));
        }

        if (method == RegexExtractMatchAndPattern)
        {
            return _sqlExpressionFactory.Function(
                name: "regexp_extract",
                arguments: [arguments[1], arguments[2]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == RegexExtractWithGroup)
        {
            return _sqlExpressionFactory.Function(
                name: "regexp_extract",
                arguments: [arguments[1], arguments[2], arguments[3]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                returnType: typeof(string));
        }

        if (method == RegexExtractWithGroupAndOptions)
        {
            return _sqlExpressionFactory.Function(
                name: "regexp_extract",
                arguments: [arguments[1], arguments[2], arguments[3], arguments[4]],
                nullable: true,
                argumentsPropagateNullability: [true, true, true, true],
                returnType: typeof(string));
        }

        return null;
    }
}
