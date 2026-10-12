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
public class DuckDBPathMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo GetFileName = typeof(Path).GetRuntimeMethod(nameof(Path.GetFileName), [typeof(string)])!;
    private static readonly MethodInfo GetFileNameWithoutExtension = typeof(Path).GetRuntimeMethod(nameof(Path.GetFileNameWithoutExtension), [typeof(string)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBPathMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
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
        if (method == GetFileName)
        {
            return _sqlExpressionFactory.Function(
                name: "parse_filename",
                arguments: [arguments[0], _sqlExpressionFactory.Constant(false)],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        if (method == GetFileNameWithoutExtension)
        {
            return _sqlExpressionFactory.Function(
                name: "parse_filename",
                arguments: [arguments[0], _sqlExpressionFactory.Constant(true)],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string));
        }

        return null;
    }
}
