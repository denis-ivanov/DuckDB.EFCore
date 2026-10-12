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
public class DuckDBUriMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo Escape = typeof(Uri).GetRuntimeMethod(nameof(Uri.EscapeDataString), [typeof(string)])!;
    private static readonly MethodInfo Unescape = typeof(Uri).GetRuntimeMethod(nameof(Uri.UnescapeDataString), [typeof(string)])!;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBUriMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
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
        if (method == Escape)
        {
            return _sqlExpressionFactory.Function(
                name: "url_encode",
                arguments: [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        if (method == Unescape)
        {
            return _sqlExpressionFactory.Function(
                name: "url_decode",
                arguments: [arguments[0]],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(string));
        }

        return null;
    }
}
