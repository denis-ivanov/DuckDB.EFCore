using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBDateTimeOffsetMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Year = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Year))!;
    private static readonly MemberInfo Month = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Month))!;
    private static readonly MemberInfo Day = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Day))!;
    private static readonly MemberInfo Hour = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Hour))!;
    private static readonly MemberInfo Minute = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Minute))!;
    private static readonly MemberInfo Second = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Second))!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBDateTimeOffsetMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MemberInfo member,
        Type returnType,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
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
