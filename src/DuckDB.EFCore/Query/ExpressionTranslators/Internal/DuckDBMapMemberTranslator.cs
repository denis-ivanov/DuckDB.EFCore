using DuckDB.EFCore.Storage.Internal;
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
public class DuckDBMapMemberTranslator : IMemberTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBMapMemberTranslator(
        ISqlExpressionFactory sqlExpressionFactory,
        IRelationalTypeMappingSource typeMappingSource)
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
    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (instance is not null &&
            member.DeclaringType is not null &&
            member.DeclaringType.IsGenericType &&
            member.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            if (member.Name == nameof(Dictionary<,>.Count))
            {
                return _sqlExpressionFactory.Function(
                    name: "cardinality",
                    arguments: [instance],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    returnType: returnType);
            }

            if (member.Name == nameof(Dictionary<,>.Keys))
            {
                var keyTypeMapping = (instance.TypeMapping as DuckDBMapTypeMapping)?.KeyTypeMapping;
                var typeMapping = (_typeMappingSource as DuckDBTypeMappingSource)?.FindCollectionMapping(null, returnType, null, keyTypeMapping)
                    ?? _typeMappingSource.FindMapping(returnType);

                return _sqlExpressionFactory.Function(
                    name: "map_keys",
                    arguments: [instance],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    returnType: returnType,
                    typeMapping: typeMapping);
            }

            if (member.Name == nameof(Dictionary<,>.Values))
            {
                var valueTypeMapping = (instance.TypeMapping as DuckDBMapTypeMapping)?.ValueTypeMapping;
                var typeMapping = (_typeMappingSource as DuckDBTypeMappingSource)?.FindCollectionMapping(null, returnType, null, valueTypeMapping)
                    ?? _typeMappingSource.FindMapping(returnType);

                return _sqlExpressionFactory.Function(
                    name: "map_values",
                    arguments: [instance],
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    returnType: returnType,
                    typeMapping: typeMapping);
            }
        }

        return null;
    }
}
