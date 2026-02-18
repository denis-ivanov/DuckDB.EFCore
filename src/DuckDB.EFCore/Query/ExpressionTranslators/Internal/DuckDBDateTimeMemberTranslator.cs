using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBDateTimeMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Year = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Year))!;
    private static readonly MemberInfo Month = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Month))!;
    private static readonly MemberInfo Day = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Day))!;
    private static readonly MemberInfo Hour = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Hour))!;
    private static readonly MemberInfo Minute = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Minute))!;
    private static readonly MemberInfo Second = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Second))!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBDateTimeMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (member == Year)
        {
            return _sqlExpressionFactory.Function(
                name: "year",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == Month)
        {
            return _sqlExpressionFactory.Function(
                name: "month",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == Day)
        {
            return _sqlExpressionFactory.Function(
                name: "day",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

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
