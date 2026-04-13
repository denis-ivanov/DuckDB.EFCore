using DuckDB.EFCore.Query.Internal;
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
public class DuckDBDateTimeOffsetMemberTranslator : IMemberTranslator
{
    private static readonly MemberInfo Year = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Year))!;
    private static readonly MemberInfo Month = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Month))!;
    private static readonly MemberInfo Day = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Day))!;
    private static readonly MemberInfo Hour = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Hour))!;
    private static readonly MemberInfo Minute = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Minute))!;
    private static readonly MemberInfo Second = typeof(DateTimeOffset).GetRuntimeProperty(nameof(DateTimeOffset.Second))!;

    private readonly DuckDBSqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBDateTimeOffsetMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (DuckDBSqlExpressionFactory)sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        SqlExpression? instance,
        MemberInfo member,
        Type returnType,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
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

        return null;
    }
}
