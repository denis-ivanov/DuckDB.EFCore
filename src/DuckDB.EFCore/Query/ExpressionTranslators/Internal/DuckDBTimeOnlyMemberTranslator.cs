using DuckDB.EFCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

public class DuckDBTimeOnlyMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Hour = typeof(TimeOnly).GetRuntimeProperty(nameof(TimeOnly.Hour))!;
    private static readonly MemberInfo Minute = typeof(TimeOnly).GetRuntimeProperty(nameof(TimeOnly.Minute))!;
    private static readonly MemberInfo Second = typeof(TimeOnly).GetRuntimeProperty(nameof(TimeOnly.Second))!;

    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    public DuckDBTimeOnlyMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
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
