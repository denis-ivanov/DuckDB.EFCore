using DuckDB.EFCore.Query.Internal;
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
    
    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    public DuckDBTimeSpanMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
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

        return null;
    }
}