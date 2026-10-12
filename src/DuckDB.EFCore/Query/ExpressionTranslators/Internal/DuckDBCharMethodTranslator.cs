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
public class DuckDBCharMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo ToChar = typeof(Convert).GetRuntimeMethod(nameof(Convert.ToChar), [typeof(int)])!;
    private static readonly MethodInfo ToInt32 = typeof(Convert).GetRuntimeMethod(nameof(Convert.ToInt32), [typeof(char)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="DuckDBCharMethodTranslator"/> class.
    /// </summary>
    /// <param name="sqlExpressionFactory"></param>
    public DuckDBCharMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
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
        if (method == ToChar)
        {
            return _sqlExpressionFactory.Function(
                name: "chr",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(char));
        }

        if (method == ToInt32)
        {
            return _sqlExpressionFactory.Function(
                name: "unicode",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: typeof(int));
        }

        return null;
    }
}
