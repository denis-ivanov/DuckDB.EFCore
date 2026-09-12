using DuckDB.EFCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace DuckDB.EFCore.Query.ExpressionTranslators.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBBitStringMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo And = typeof(BitArray).GetMethod(nameof(BitArray.And), [typeof(BitArray)])!;
    private static readonly MethodInfo Or = typeof(BitArray).GetMethod(nameof(BitArray.Or), [typeof(BitArray)])!;
    private static readonly MethodInfo Xor = typeof(BitArray).GetMethod(nameof(BitArray.Xor), [typeof(BitArray)])!;
    private static readonly MethodInfo Not = typeof(BitArray).GetMethod(nameof(BitArray.Not), Type.EmptyTypes)!;
    private static readonly MethodInfo LeftShift = typeof(BitArray).GetMethod(nameof(BitArray.LeftShift), [typeof(int)])!;

    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly ITypeMappingSource _typeMappingSource;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBBitStringMethodTranslator(ISqlExpressionFactory sqlExpressionFactory, ITypeMappingSource typeMappingSource)
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
        if (instance is not null)
        {
            if (method == And)
            {
                return _sqlExpressionFactory.MakeBinary(
                    ExpressionType.And,
                    instance,
                    arguments[0], 
                    typeMapping: (RelationalTypeMapping?)_typeMappingSource.FindMapping(typeof(BitArray)));
            }

            if (method == Or)
            {
                return _sqlExpressionFactory.MakeBinary(
                    ExpressionType.Or,
                    instance,
                    arguments[0],
                    typeMapping: (RelationalTypeMapping?)_typeMappingSource.FindMapping(typeof(BitArray)));
            }

            if (method == Xor)
            {
                return _sqlExpressionFactory.Function(
                    "xor",
                    arguments: [instance, arguments[0]],
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    method.ReturnType);
            }

            if (method == Not)
            {
                return _sqlExpressionFactory.MakeUnary(
                    ExpressionType.Not,
                    instance,
                    instance.Type,
                    (RelationalTypeMapping?)_typeMappingSource.FindMapping(typeof(BitArray)));
            }

            if (method == LeftShift)
            {
                return new DuckDBBinaryExpression(
                    ExpressionType.LeftShift,
                    instance,
                    _sqlExpressionFactory.ApplyDefaultTypeMapping(arguments[0]),
                    instance.Type,
                    (RelationalTypeMapping?)_typeMappingSource.FindMapping(typeof(BitArray)));
            }
        }

        return null;
    }
}
