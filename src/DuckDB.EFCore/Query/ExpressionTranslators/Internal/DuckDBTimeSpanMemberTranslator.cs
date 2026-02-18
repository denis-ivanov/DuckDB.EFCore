using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBTimeSpanMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Hour = typeof(TimeSpan).GetRuntimeProperty(nameof(TimeSpan.Hours))!;
    private static readonly MemberInfo Minute = typeof(TimeSpan).GetRuntimeProperty(nameof(TimeSpan.Minutes))!;
    private static readonly MemberInfo Second = typeof(TimeSpan).GetRuntimeProperty(nameof(TimeSpan.Seconds))!;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBTimeSpanMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (member == Hour)
        {
            return _sqlExpressionFactory.Function(
                name: "hour",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == Minute)
        {
            return _sqlExpressionFactory.Function(
                name: "minute",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == Second)
        {
            return _sqlExpressionFactory.Function(
                name: "second",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        return null;
    }
}