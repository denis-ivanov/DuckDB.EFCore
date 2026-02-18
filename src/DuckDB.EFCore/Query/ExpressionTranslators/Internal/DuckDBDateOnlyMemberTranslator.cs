using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBDateOnlyMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Year = typeof(DateOnly).GetProperty(nameof(DateOnly.Year))!;
    private static readonly MemberInfo Month = typeof(DateOnly).GetProperty(nameof(DateOnly.Month))!;
    private static readonly MemberInfo Day = typeof(DateOnly).GetProperty(nameof(DateOnly.Day))!;
    private static readonly MemberInfo DayOfWeek = typeof(DateOnly).GetProperty(nameof(DateOnly.DayOfWeek))!;
    private static readonly MemberInfo DayOfYear = typeof(DateOnly).GetProperty(nameof(DateOnly.DayOfYear))!;
    private static readonly MemberInfo DayNumber = typeof(DateOnly).GetProperty(nameof(DateOnly.DayNumber))!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public DuckDBDateOnlyMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
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

        if (member == DayOfWeek)
        {
            return _sqlExpressionFactory.Function(
                name: "dayofweek",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == DayOfYear)
        {
            return _sqlExpressionFactory.Function(
                name: "dayofyear",
                arguments: [instance],
                argumentsPropagateNullability: [true],
                nullable: true,
                returnType: typeof(int));
        }

        if (member == DayNumber)
        {
            return _sqlExpressionFactory.Function(
                name: "date_diff",
                arguments:
                [
                    _sqlExpressionFactory.Constant("day"),
                    _sqlExpressionFactory.Constant(DateOnly.MinValue),
                    instance
                ],
                argumentsPropagateNullability: [true, true, true],
                nullable: true,
                returnType: typeof(int));
        }

        return null;
    }
}
