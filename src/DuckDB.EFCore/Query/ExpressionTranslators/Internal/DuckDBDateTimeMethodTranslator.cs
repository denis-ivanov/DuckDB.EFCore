using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBDateTimeMethodTranslator : IMethodCallTranslator
{
    private static readonly MemberInfo Hour = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Hour))!;
    private static readonly MemberInfo Minute = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Minute))!;
    private static readonly MemberInfo Second = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Second))!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBDateTimeMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        return null;
    }
}