using DuckDB.EFCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBDateTimeOffsetMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo AddYears = typeof(DateTimeOffset).GetRuntimeMethod(nameof(DateTimeOffset.AddYears), [typeof(int)])!;
    private static readonly MethodInfo AddMonths = typeof(DateTimeOffset).GetRuntimeMethod(nameof(DateTimeOffset.AddMonths), [typeof(int)])!;
    private static readonly MethodInfo AddDays = typeof(DateTimeOffset).GetRuntimeMethod(nameof(DateTimeOffset.AddDays), [typeof(int)])!;

    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    public DuckDBDateTimeOffsetMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == AddYears)
        {
            return _sqlExpressionFactory.AddYears(instance, arguments[0], typeof(DateTimeOffset));
        }

        if (method == AddMonths)
        {
            return _sqlExpressionFactory.AddMonths(instance, arguments[0], typeof(DateTimeOffset));
        }

        if (method == AddDays)
        {
            return _sqlExpressionFactory.AddDays(instance, arguments[0], typeof(DateTimeOffset));
        }

        return null;
    }
}