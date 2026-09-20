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
public class DuckDBMapMethodTranslator : IMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBMapMethodTranslator(
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
    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (instance is not null &&
            method.DeclaringType is not null &&
            method.DeclaringType.IsGenericType &&
            method.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            if (method.Name == nameof(Dictionary<,>.ContainsKey))
            {
                return _sqlExpressionFactory.Function(
                    name: "map_contains",
                    arguments: [instance, arguments[0]],
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    returnType: method.ReturnType);
            }

            if (method.Name == nameof(Dictionary<,>.ContainsValue))
            {
                return _sqlExpressionFactory.Function(
                    name: "map_contains_value",
                    arguments: [instance, arguments[0]],
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    returnType: method.ReturnType);
            }

            if (method.Name == "get_Item")
            {
                var typeMapping = (instance.TypeMapping as DuckDBMapTypeMapping)?.ValueTypeMapping;

                return _sqlExpressionFactory.Function(
                    name: "map_extract_value",
                    arguments: [instance, arguments[0]],
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    returnType: method.ReturnType,
                    typeMapping: typeMapping);
            }
        }

        if (instance is null &&
            method.DeclaringType == typeof(Enumerable) &&
            method.Name is nameof(Enumerable.ToArray) or nameof(Enumerable.ToList) &&
            arguments.Count == 1 &&
            arguments[0] is SqlFunctionExpression { Name: "map_keys" or "map_values" } mapFunction)
        {
            var mapInstance = mapFunction.Arguments[0];
            var elementTypeMapping = mapFunction.Name == "map_keys"
                ? (mapInstance.TypeMapping as DuckDBMapTypeMapping)?.KeyTypeMapping
                : (mapInstance.TypeMapping as DuckDBMapTypeMapping)?.ValueTypeMapping;

            var typeMapping = (_typeMappingSource as DuckDBTypeMappingSource)?.FindCollectionMapping(null, method.ReturnType, null, elementTypeMapping)
                ?? _typeMappingSource.FindMapping(method.ReturnType);

            return _sqlExpressionFactory.Function(
                name: mapFunction.Name,
                arguments: mapFunction.Arguments,
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: method.ReturnType,
                typeMapping: typeMapping);
        }

        return null;
    }
}
