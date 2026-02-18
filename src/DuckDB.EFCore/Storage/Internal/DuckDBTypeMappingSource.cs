using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBTypeMappingSource : RelationalTypeMappingSource
{
    internal const string VarCharTypeName = "VARCHAR";
    internal const string BlobTypeName = "BLOB";

    private static readonly DuckDBBooleanTypeMapping BooleanTypeMapping = new();
    private static readonly DuckDBByteTypeMapping ByteTypeMapping = new();
    private static readonly DuckDBDateOnlyTypeMapping DateTypeMapping = new();

    private static readonly DuckDBCharTypeMapping CharTypeMapping = new();
    // TODO Decimal
    private static readonly DuckDBDoubleTypeMapping DoubleTypeMapping = new();
    private static readonly DuckDBFloatTypeMapping FloatTypeMapping = new();
    private static readonly DuckDBGuidTypeMapping GuidTypeMapping = new();
    private static readonly DuckDBInt16TypeMapping Int16TypeMapping = new();
    private static readonly DuckDBInt32TypeMapping Int32TypeMapping = new();
    private static readonly DuckDBInt64TypeMapping Int64TypeMapping = new();
    private static readonly DuckDBSByteTypeMapping SByteTypeMapping = new();
    private static readonly DuckDBStringTypeMapping StringTypeMapping = DuckDBStringTypeMapping.Default;
    private static readonly DuckDBUInt16TypeMapping UInt16TypeMapping = new();
    private static readonly DuckDBUInt32TypeMapping UInt32TypeMapping = new();
    private static readonly DuckDBUInt64TypeMapping UInt64TypeMapping = new();
    private static readonly DuckDBJsonTypeMapping JsonTypeMapping = new();

    private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
    {
        { typeof(string), StringTypeMapping },
        { typeof(byte[]), DuckDBBlobTypeMapping.Default },
        { typeof(bool), BooleanTypeMapping },
        { typeof(byte), ByteTypeMapping },
        { typeof(char), CharTypeMapping },
        { typeof(int), Int32TypeMapping },
        { typeof(long), Int64TypeMapping },
        { typeof(sbyte), SByteTypeMapping },
        { typeof(short), Int16TypeMapping },
        { typeof(uint), UInt32TypeMapping },
        { typeof(ulong), UInt64TypeMapping },
        { typeof(ushort), UInt16TypeMapping },
        { typeof(DateTime), DuckDBTimestampTypeMapping.TimestampNs },
        { typeof(DateTimeOffset), DuckDBTimestampTypeMapping.TimestampTz },
        { typeof(DateOnly), DateTypeMapping },
        { typeof(TimeSpan), DuckDBTimeTypeMapping.TimeSpan },
        { typeof(TimeOnly), DuckDBTimeTypeMapping.Time },
        { typeof(decimal), DuckDBDecimalTypeMapping.Default },
        { typeof(double), DoubleTypeMapping },
        { typeof(float), FloatTypeMapping },
        { typeof(Guid), GuidTypeMapping },
        { typeof(JsonTypePlaceholder), JsonTypeMapping },
        // TODO { typeof(JsonElement), SqliteJsonTypeMapping.Default }
    };

    private static readonly Dictionary<string, RelationalTypeMapping> StoreTypeMappings = new()
    {
        { "INT8", UInt64TypeMapping },
        { "LONG", UInt64TypeMapping },
        { "BYTEA", DuckDBBlobTypeMapping.Default },
        { "BINARY", DuckDBBlobTypeMapping.Default },
        { "VARBINARY", DuckDBBlobTypeMapping.Default },
        { "BOOL", BooleanTypeMapping },
        { "LOGICAL", BooleanTypeMapping },
        { "FLOAT8", DoubleTypeMapping },
        { "FLOAT4", FloatTypeMapping },
        { "REAL", FloatTypeMapping },
        { "INT4", Int32TypeMapping },
        { "INT", Int32TypeMapping },
        { "SIGNED", Int32TypeMapping },
        { "INT2", Int16TypeMapping },
        { "SHORT", Int16TypeMapping },

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

        { "INT1", SByteTypeMapping },
        { "CHAR", StringTypeMapping },
        { "BPCHAR", StringTypeMapping },
        { "TEXT", StringTypeMapping },
        { "STRING", StringTypeMapping },
        { "JSON", JsonTypeMapping }
    };

    public DuckDBTypeMappingSource(TypeMappingSourceDependencies dependencies, RelationalTypeMappingSourceDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }

    protected override RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        var mapping = base.FindMapping(mappingInfo)
                      ?? FindRawMapping(mappingInfo);

        return mapping != null
               && mappingInfo.StoreTypeName != null
            ? mapping.WithStoreTypeAndSize(mappingInfo.StoreTypeName, null)
            : mapping;
    }
    
    private RelationalTypeMapping? FindRawMapping(RelationalTypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;
        if (clrType == typeof(byte[]) && mappingInfo.ElementTypeMapping != null)
        {
            return null;
        }

        if (clrType != null
            && ClrTypeMappings.TryGetValue(clrType, out var mapping))
        {
            return mapping;
        }

        var storeTypeName = mappingInfo.StoreTypeName;
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
            ? Int32TypeMapping
            : null,
        name => Contains(name, "CHAR")
                || Contains(name, "BPCHAR")
                || Contains(name, "TEXT")
                || Contains(name, "STRING")
            ? StringTypeMapping
            : null,
        name => Contains(name, "BLOB")
            ? DuckDBBlobTypeMapping.Default
            : null,
        name => Contains(name, "REAL")
                || Contains(name, "FLOAT")
            ? FloatTypeMapping
            : null
    ];

    private static bool Contains(string haystack, string needle)
        => haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0;
}
