using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBDbFunctionsExtensionsMethodTranslator : IMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly ITypeMappingSource _typeMappingSource;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBDbFunctionsExtensionsMethodTranslator(ISqlExpressionFactory sqlExpressionFactory, ITypeMappingSource typeMappingSource)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
        _typeMappingSource = typeMappingSource;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType == typeof(DuckDBDbFunctionsExtensions))
        {
            switch (method.Name)
            {
                case nameof(DuckDBDbFunctionsExtensions.Strftime):
                    return _sqlExpressionFactory.Function(
                        name: "strftime",
                        arguments: [arguments[1], arguments[2]],
                        nullable: true,
                        argumentsPropagateNullability: [true, true],
                        returnType: typeof(string),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(string))!);
                case nameof(DuckDBDbFunctionsExtensions.Strptime):
                    return _sqlExpressionFactory.Function(
                        name: "strptime",
                        arguments: [arguments[1], arguments[2]],
                        nullable: true,
                        argumentsPropagateNullability: [true, true],
                        returnType: typeof(DateTime),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(DateTime))!);
                case nameof(DuckDBDbFunctionsExtensions.DayName):
                    return _sqlExpressionFactory.Function(
                        name: "dayname",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(string),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(string))!);
                case nameof(DuckDBDbFunctionsExtensions.DaysInMonth):
                    return _sqlExpressionFactory.Function(
                        name: "days_in_month",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(int),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(int))!);
                case nameof(DuckDBDbFunctionsExtensions.Greatest):
                    return _sqlExpressionFactory.Function(
                        name: "greatest",
                        arguments: [arguments[1], arguments[2]],
                        nullable: true,
                        argumentsPropagateNullability: [true, true],
                        returnType: typeof(DateOnly),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(DateOnly))!);
                case nameof(DuckDBDbFunctionsExtensions.IsFinite):
                    return _sqlExpressionFactory.Function(
                        name: "isfinite",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(bool),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(bool))!);
                case nameof(DuckDBDbFunctionsExtensions.IsInfinite):
                    return _sqlExpressionFactory.Function(
                        name: "isinf",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(bool),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(bool))!);
                case nameof(DuckDBDbFunctionsExtensions.Julian):
                    return _sqlExpressionFactory.Function(
                        name: "julian",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(double),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(double))!);
                case nameof(DuckDBDbFunctionsExtensions.LastDay):
                    return _sqlExpressionFactory.Function(
                        name: "last_day",
                        arguments: [arguments[1]],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        returnType: typeof(DateOnly),
                        typeMapping: (RelationalTypeMapping)_typeMappingSource.FindMapping(typeof(DateOnly))!);
            }
        }

        return null;
    }
}
