using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DuckDB.EFCore.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBTypeMappingSource : RelationalTypeMappingSource
{
    internal const string VarCharTypeName = "VARCHAR";
    internal const string BlobTypeName = "BLOB";
    internal const string BitTypeName = "BIT";
    internal const string MapTypeNamePrefix = "MAP(";

    // JSON
    private static readonly DuckDBJsonTypeMapping JsonString = new(typeof(string));
    private static readonly DuckDBJsonTypeMapping JsonDocument = new(typeof(JsonDocument));
    private static readonly DuckDBJsonTypeMapping JsonElement = new(typeof(JsonElement));
    private static readonly DuckDBStructuralJsonTypeMapping JsonOwned = new();

    private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
    {
        { typeof(string), DuckDBStringTypeMapping.Default },
        { typeof(byte[]), DuckDBBlobTypeMapping.Default },
        { typeof(bool), DuckDBBooleanTypeMapping.Default },
        { typeof(byte), DuckDBByteTypeMapping.Default },
        { typeof(char), DuckDBCharTypeMapping.Default },
        { typeof(int), DuckDBInt32TypeMapping.Default },
        { typeof(long), DuckDBInt64TypeMapping.Default },
        { typeof(sbyte), DuckDBSByteTypeMapping.Default },
        { typeof(short), DuckDBInt16TypeMapping.Default },
        { typeof(uint), DuckDBUInt32TypeMapping.Default },
        { typeof(ulong), DuckDBUInt64TypeMapping.Default },
        { typeof(ushort), DuckDBUInt16TypeMapping.Default },
        { typeof(DateTime), DuckDBTimestampTypeMapping.Timestamp },
        { typeof(DateTimeOffset), DuckDBTimestampTypeMapping.TimestampTz },
        { typeof(DateOnly), DuckDBDateOnlyTypeMapping.Default },
        { typeof(TimeSpan), DuckDBTimeTypeMapping.TimeSpan },
        { typeof(TimeOnly), DuckDBTimeTypeMapping.Time },
        { typeof(decimal), DuckDBDecimalTypeMapping.Default },
        { typeof(double), DuckDBDoubleTypeMapping.Default },
        { typeof(float), DuckDBFloatTypeMapping.Default },
        { typeof(Guid), DuckDBGuidTypeMapping.Default },
        { typeof(JsonDocument), JsonDocument },
        { typeof(JsonElement), JsonElement },
        { typeof(JsonTypePlaceholder), JsonOwned }
    };

    private static readonly Dictionary<string, RelationalTypeMapping> StoreTypeMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        // Blob types
        { "BLOB", DuckDBBlobTypeMapping.Default },
        { "BYTEA", DuckDBBlobTypeMapping.Default },
        { "BINARY", DuckDBBlobTypeMapping.Default },
        { "VARBINARY", DuckDBBlobTypeMapping.Default },

        // Fixed-Width Integer Types
        { "TINYINT", DuckDBSByteTypeMapping.Default },
        { "INT1", DuckDBSByteTypeMapping.Default },

        { "SMALLINT", DuckDBInt16TypeMapping.Default },
        { "INT2", DuckDBInt16TypeMapping.Default },
        { "INT16", DuckDBInt16TypeMapping.Default },
        { "SHORT", DuckDBInt16TypeMapping.Default },
        
        { "INTEGER", DuckDBInt32TypeMapping.Default },
        { "INT4", DuckDBInt32TypeMapping.Default },
        { "INT32", DuckDBInt32TypeMapping.Default },
        { "INT", DuckDBInt32TypeMapping.Default },
        { "SIGNED", DuckDBInt32TypeMapping.Default },

        { "BIGINT", DuckDBInt64TypeMapping.Default },
        { "INT8", DuckDBInt64TypeMapping.Default },
        { "INT64", DuckDBInt64TypeMapping.Default },
        { "LONG", DuckDBInt64TypeMapping.Default },

        { "UTINYINT", DuckDBByteTypeMapping.Default },
        { "UINT8", DuckDBByteTypeMapping.Default },

        { "USMALLINT", DuckDBUInt16TypeMapping.Default },
        { "UINT16", DuckDBUInt16TypeMapping.Default },

        { "UINTEGER", DuckDBUInt32TypeMapping.Default },
        { "UINT32", DuckDBUInt32TypeMapping.Default },

        { "UBIGINT", DuckDBUInt64TypeMapping.Default },
        { "UINT64", DuckDBUInt64TypeMapping.Default },

        { "FLOAT", DuckDBFloatTypeMapping.Default },
        { "FLOAT4", DuckDBFloatTypeMapping.Default },
        { "REAL", DuckDBFloatTypeMapping.Default },
        
        { "DOUBLE", DuckDBDoubleTypeMapping.Default },
        { "FLOAT8", DuckDBDoubleTypeMapping.Default },

        // Timestamp Types
        { "TIMESTAMP_NS", DuckDBTimestampTypeMapping.TimestampNs },
        { "TIMESTAMP", DuckDBTimestampTypeMapping.Timestamp },
        { "DATETIME", DuckDBTimestampTypeMapping.Timestamp },
        { "TIMESTAMP WITHOUT TIME ZONE", DuckDBTimestampTypeMapping.Timestamp },
        { "TIMESTAMP_MS", DuckDBTimestampTypeMapping.TimestampMs },
        { "TIMESTAMP_S", DuckDBTimestampTypeMapping.TimestampS }, 
        { "TIMESTAMPTZ", DuckDBTimestampTypeMapping.TimestampTz },
        { "TIMESTAMP WITH TIME ZONE", DuckDBTimestampTypeMapping.TimestampTz },

        // Time types
        { "TIME", DuckDBTimeTypeMapping.Time },
        { "TIME WITHOUT TIME ZONE", DuckDBTimeTypeMapping.Time },
        { "TIMETZ", DuckDBTimeTypeMapping.TimeTz },
        { "TIME WITH TIME ZONE", DuckDBTimeTypeMapping.TimeTz },
        { "TIME_NS", DuckDBTimeTypeMapping.TimeNs },

        { "CHAR", DuckDBStringTypeMapping.Default },
        { "BPCHAR", DuckDBStringTypeMapping.Default },
        { "TEXT", DuckDBStringTypeMapping.Default },
        { "STRING", DuckDBStringTypeMapping.Default },
        { "JSON", JsonString }
    };

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBTypeMappingSource(TypeMappingSourceDependencies dependencies, RelationalTypeMappingSourceDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    /// <inheritdoc />
    protected override RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        var mapping = base.FindMapping(mappingInfo)
                      ?? FindRawMapping(mappingInfo)?.Clone(mappingInfo)
                      ?? FindRowValueMapping(mappingInfo)?.Clone(mappingInfo);

        return mapping != null && mappingInfo.StoreTypeName != null
            ? mapping.WithStoreTypeAndSize(mappingInfo.StoreTypeName, null)
            : mapping;
    }

    /// <inheritdoc />
    protected override RelationalTypeMapping? FindCollectionMapping(
        RelationalTypeMappingInfo info,
        Type? modelType,
        Type? providerType,
        CoreTypeMapping? elementMapping)
    {
        var result = FindCollectionMapping(info.StoreTypeName, modelType, providerType, elementMapping);

        if (result is null && modelType is not null)
        {
            var elemType = modelType.TryGetElementType(typeof(IEnumerable<>)) ?? modelType.GetElementType();

            if (elemType == typeof(object))
            {
                return base.FindCollectionMapping(info, modelType, providerType, elementMapping);
            }
        }

        return result;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    [EntityFrameworkInternal]
    public virtual RelationalTypeMapping? FindCollectionMapping(
        string? storeType,
        Type? modelClrType,
        Type? providerClrType,
        CoreTypeMapping? elementMapping)
    {
        if (elementMapping is not null and not RelationalTypeMapping)
        {
            return null;
        }

        Type concreteCollectionType;
        Type? elementType = null;

        if (modelClrType is not null)
        {
            elementType = modelClrType.TryGetElementType(typeof(IEnumerable<>)) ?? modelClrType.GetElementType();

            if (elementType is null || elementType == modelClrType || modelClrType.GetGenericTypeImplementations(typeof(IDictionary<,>)).Any())
            {
                return null;
            }
        }

        switch (storeType)
        {
            case null:
            {
                if (modelClrType is null)
                {
                    return null;
                }

                Debug.Assert(elementType is not null, "elementClrType is null");

                if (elementType == typeof(object))
                {
                    return null;
                }

                var relationalElementMapping = elementMapping as RelationalTypeMapping ?? FindMapping(elementType);
                if (relationalElementMapping is not { ElementTypeMapping: null })
                {
                    return null;
                }

                concreteCollectionType = FindTypeToInstantiate(modelClrType, elementType);

                return (DuckDBArrayTypeMapping)Activator.CreateInstance(
                    typeof(DuckDBArrayTypeMapping<,,>).MakeGenericType(modelClrType, concreteCollectionType, elementType),
                    relationalElementMapping)!;
            }

            case var _ when storeType.EndsWith("[]", StringComparison.Ordinal):
            {
                var elementStoreType = storeType.Substring(0, storeType.Length - 2);

                var relationalElementMapping = elementMapping as RelationalTypeMapping
                    ?? (elementType is null
                        ? FindMapping(elementStoreType)
                        : FindMapping(elementType, elementStoreType));
                if (relationalElementMapping is not { ElementTypeMapping: null })
                {
                    return null;
                }

                if (relationalElementMapping is not null and not DuckDBArrayTypeMapping)
                {
                    if (modelClrType is null)
                    {
                        elementType = relationalElementMapping.ClrType;
                        modelClrType = concreteCollectionType = typeof(List<>).MakeGenericType(elementType);
                    }
                    else
                    {
                        concreteCollectionType = FindTypeToInstantiate(modelClrType, elementType!);
                        Debug.Assert(elementType is not null, "elementType is null");
                    }

                    return (DuckDBArrayTypeMapping)Activator.CreateInstance(
                        typeof(DuckDBArrayTypeMapping<,,>).MakeGenericType(modelClrType, concreteCollectionType, elementType),
                        storeType, relationalElementMapping)!;
                }

                return null;
            }

#pragma warning disable EF1001 // SelectExpression constructors are pubternal

            case "JSON" or "json" when modelClrType is not null:
                return base.FindCollectionMapping(
                    new RelationalTypeMappingInfo(
                        modelClrType, (RelationalTypeMapping?)elementMapping, storeTypeName: storeType, storeTypeNameBase: storeType),
                    modelClrType,
                    providerClrType,
                    elementMapping);
#pragma warning restore EF1001 // SelectExpression constructors are pubternal

            default:
                return null;
        }

        static Type FindTypeToInstantiate(Type collectionType, Type elementType)
        {
            if (collectionType.IsArray)
            {
                return collectionType;
            }

            var listOfT = typeof(List<>).MakeGenericType(elementType);

            if (collectionType.IsAssignableFrom(listOfT))
            {
                if (!collectionType.IsAbstract)
                {
                    var constructor = collectionType.GetDeclaredConstructor(null);
                    if (constructor?.IsPublic == true)
                    {
                        return collectionType;
                    }
                }

                return listOfT;
            }

            return collectionType;
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual RelationalTypeMapping? FindRowValueMapping(in RelationalTypeMappingInfo mappingInfo)
        => mappingInfo.ClrType is { } clrType
           && clrType.IsAssignableTo(typeof(ITuple))
            ? new DuckDBRowValueTypeMapping(clrType)
            : null;

    private RelationalTypeMapping? FindRawMapping(RelationalTypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;
        if (clrType == typeof(byte[]) && mappingInfo.ElementTypeMapping != null)
        {
            return null;
        }

        var storeTypeName = mappingInfo.StoreTypeName;

        if (FindMapMapping(clrType, storeTypeName) is { } mapMapping)
        {
            return mapMapping;
        }

        if (storeTypeName != null && IsBitStoreType(storeTypeName))
        {
            return clrType switch
            {
                null => DuckDBBitStringTypeMapping.String,
                _ when clrType == typeof(string) => DuckDBBitStringTypeMapping.String,
                _ when clrType == typeof(BitArray) => DuckDBBitStringTypeMapping.Default,
                _ => null
            };
        }

        if (clrType == typeof(BitArray) && storeTypeName == null)
        {
            return DuckDBBitStringTypeMapping.Default;
        }

        if (clrType != null && ClrTypeMappings.TryGetValue(clrType, out var mapping))
        {
            if (storeTypeName != null)
            {
                if (mapping.StoreType.Equals(storeTypeName, StringComparison.OrdinalIgnoreCase)
                    || mapping.StoreTypeNameBase.Equals(storeTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    return mapping;
                }

                if (StoreTypeMappings.TryGetValue(storeTypeName, out var storeMapping)
                    && storeMapping.ClrType.UnwrapNullableType() != clrType)
                {
                    return null;
                }

                var affinityMapping = _typeRules.Select(r => r(storeTypeName)).FirstOrDefault(r => r != null);
                if (affinityMapping != null && affinityMapping.ClrType.UnwrapNullableType() != clrType)
                {
                    return null;
                }
            }

            return mapping;
        }

        if (storeTypeName != null
            && StoreTypeMappings.TryGetValue(storeTypeName, out mapping)
            && (clrType == null || mapping.ClrType.UnwrapNullableType() == clrType))
        {
            return mapping;
        }

        if (storeTypeName != null)
        {
            var affinityTypeMapping = _typeRules.Select(r => r(storeTypeName)).FirstOrDefault(r => r != null);

            if (affinityTypeMapping != null)
            {
                return clrType == null || affinityTypeMapping.ClrType.UnwrapNullableType() == clrType
                    ? affinityTypeMapping
                    : null;
            }

            if (clrType == null || clrType == typeof(byte[]))
            {
                return DuckDBBlobTypeMapping.Default;
            }
        }

        return null;
    }

    private readonly Func<string, RelationalTypeMapping?>[] _typeRules =
    [
        name => Contains(name, "INT")
            ? DuckDBInt32TypeMapping.Default
            : null,
        name => Contains(name, "CHAR")
                || Contains(name, "BPCHAR")
                || Contains(name, "TEXT")
                || Contains(name, "STRING")
            ? DuckDBStringTypeMapping.Default
            : null,
        name => Contains(name, "BLOB")
            ? DuckDBBlobTypeMapping.Default
            : null,
        name => Contains(name, "REAL")
                || Contains(name, "FLOAT")
            ? DuckDBFloatTypeMapping.Default
            : null
    ];

    private static bool Contains(string haystack, string needle)
        => haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0;

    private static bool IsBitStoreType(string storeTypeName)
        => storeTypeName.Equals(BitTypeName, StringComparison.OrdinalIgnoreCase)
            || storeTypeName.Equals("BITSTRING", StringComparison.OrdinalIgnoreCase);

    private RelationalTypeMapping? FindMapMapping(Type? clrType, string? storeTypeName)
    {
        var isMapStoreType = storeTypeName != null && TryParseMapStoreType(storeTypeName, out _, out _);

        if (clrType == null)
        {
            // Without a CLR type there is nothing to instantiate when reading, so let other rules handle it.
            return null;
        }

        if (!TryGetDictionaryTypes(clrType, out var keyType, out var valueType))
        {
            return null;
        }

        if (storeTypeName != null && !isMapStoreType)
        {
            // The property explicitly asked for a different store type; don't hijack it.
            return null;
        }

        RelationalTypeMapping? keyMapping;
        RelationalTypeMapping? valueMapping;

        if (storeTypeName != null
            && TryParseMapStoreType(storeTypeName, out var keyStoreType, out var valueStoreType))
        {
            keyMapping = FindMapping(keyType, keyStoreType);
            valueMapping = FindMapping(valueType.UnwrapNullableType(), valueStoreType);
        }
        else
        {
            keyMapping = FindMapping(keyType);
            valueMapping = FindMapping(valueType.UnwrapNullableType());
        }

        if (keyMapping == null || valueMapping == null)
        {
            return null;
        }

        return new DuckDBMapTypeMapping(clrType, keyMapping, valueMapping, storeTypeName);
    }

    private static bool TryGetDictionaryTypes(
        Type clrType,
        [NotNullWhen(true)] out Type? keyType,
        [NotNullWhen(true)] out Type? valueType)
    {
        keyType = null;
        valueType = null;

        // The CLR type must be instantiable: both DuckDB.NET and the value comparer create instances of it.
        // It must also implement IDictionary (non-generic) for literal generation and parameter conversion.
        if (clrType.IsInterface
            || clrType.IsAbstract
            || clrType.GetConstructor(Type.EmptyTypes) == null
            || !clrType.IsAssignableTo(typeof(IDictionary)))
        {
            return false;
        }

        var dictionaryInterface = clrType.GetGenericTypeImplementations(typeof(IDictionary<,>)).FirstOrDefault();

        if (dictionaryInterface == null)
        {
            return false;
        }

        keyType = dictionaryInterface.GenericTypeArguments[0];
        valueType = dictionaryInterface.GenericTypeArguments[1];

        return true;
    }

    private static bool TryParseMapStoreType(
        string storeTypeName,
        [NotNullWhen(true)] out string? keyStoreType,
        [NotNullWhen(true)] out string? valueStoreType)
    {
        keyStoreType = null;
        valueStoreType = null;

        if (!storeTypeName.StartsWith(MapTypeNamePrefix, StringComparison.OrdinalIgnoreCase)
            || !storeTypeName.EndsWith(")", StringComparison.Ordinal))
        {
            return false;
        }

        var arguments = storeTypeName.Substring(
            MapTypeNamePrefix.Length,
            storeTypeName.Length - MapTypeNamePrefix.Length - 1);

        // Split on the top-level comma only, so that nested types such as MAP(VARCHAR, MAP(INTEGER, VARCHAR)) work.
        var depth = 0;

        for (var i = 0; i < arguments.Length; i++)
        {
            switch (arguments[i])
            {
                case '(':
                    depth++;
                    break;
                case ')':
                    depth--;
                    break;
                case ',' when depth == 0:
                    keyStoreType = arguments.Substring(0, i).Trim();
                    valueStoreType = arguments.Substring(i + 1).Trim();

                    return keyStoreType.Length > 0 && valueStoreType.Length > 0;
            }
        }

        return false;
    }
}
