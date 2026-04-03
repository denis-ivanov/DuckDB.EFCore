using DuckDB.EFCore.Query.Internal;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
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
    private static readonly MemberInfo Millisecond = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Millisecond))!;
    private static readonly MemberInfo Date = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Date))!;
    private static readonly MemberInfo Now = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Now))!;
    private static readonly MemberInfo UtcNow = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.UtcNow))!;
    private static readonly MemberInfo Today = typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Today))!;

    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;
    private readonly DuckDBTypeMappingSource _typeMappingSource;

    public DuckDBDateTimeMemberTranslator(ISqlExpressionFactory sqlExpressionFactory, IRelationalTypeMappingSource typeMappingSource)
    {
        _typeMappingSource = (DuckDBTypeMappingSource)typeMappingSource;
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (member == Year)
        {
            return _sqlExpressionFactory.Year(instance);
        }

        if (member == Month)
        {
            return _sqlExpressionFactory.Month(instance);
        }

        if (member == Day)
        {
            return _sqlExpressionFactory.Day(instance);
        }

        if (member == Hour)
        {
            return _sqlExpressionFactory.Hour(instance);
        }

        if (member == Minute)
        {
            return _sqlExpressionFactory.Minute(instance);
        }

        if (member == Second)
        {
            return _sqlExpressionFactory.Second(instance);
        }

        if (member == Millisecond)
        {
            return _sqlExpressionFactory.Millisecond(instance);
        }

        if (member == Date)
        {
            return _sqlExpressionFactory.Convert(
                instance,
                typeof(DateOnly),
                _typeMappingSource.FindMapping(typeof(DateOnly)));
        }

        if (member == Now)
        {
            return _sqlExpressionFactory.Function(
                "current_localtimestamp",
                arguments: [],
                nullable: false,
                argumentsPropagateNullability: [],
                returnType: typeof(DateTime),
                typeMapping: _typeMappingSource.FindMapping("TIMESTAMP"));
        }

        if (member == UtcNow)
        {
            return _sqlExpressionFactory.Convert(
                _sqlExpressionFactory.Function(
                    "now",
                    arguments: [],
                    nullable: false,
                    argumentsPropagateNullability: [],
                    returnType: typeof(DateTimeOffset),
                    typeMapping: _typeMappingSource.FindMapping("TIMESTAMPTZ")),
                typeof(DateTime),
                _typeMappingSource.FindMapping("TIMESTAMP"));
        }

        if (member == Today)
        {
            return _sqlExpressionFactory.Convert(
                _sqlExpressionFactory.Function(
                    name: "today",
                    arguments: [],
                    nullable: false,
                    argumentsPropagateNullability: [],
                    returnType: typeof(DateOnly),
                    typeMapping: _typeMappingSource.FindMapping(typeof(DateOnly))),
                typeof(DateTime),
                _typeMappingSource.FindMapping(typeof(DateTime)));
        }

        return null;
    }
}
