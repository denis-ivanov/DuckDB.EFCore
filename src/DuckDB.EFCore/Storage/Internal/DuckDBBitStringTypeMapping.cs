using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections;
using System.Data.Common;
using System.Text;

namespace DuckDB.EFCore.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBBitStringTypeMapping : RelationalTypeMapping
{
    private static readonly ValueConverter<BitArray, string> BitArrayConverter
        = new(v => ToBitString(v), v => ToBitArray(v));

    private static readonly ValueComparer<BitArray> BitArrayComparer
        = new(
            (l, r) => l == null ? r == null : r != null && ToBitString(l) == ToBitString(r),
            v => v == null ? 0 : ToBitString(v).GetHashCode(),
            v => new BitArray(v));

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static DuckDBBitStringTypeMapping Default { get; } = new(typeof(string));

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static DuckDBBitStringTypeMapping BitArray { get; } = new(typeof(BitArray));

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBBitStringTypeMapping(Type clrType, string storeType = DuckDBTypeMappingSource.BitTypeName)
        : this(
            new RelationalTypeMappingParameters(
                clrType == typeof(BitArray)
                    ? new CoreTypeMappingParameters(clrType, BitArrayConverter, BitArrayComparer)
                    : new CoreTypeMappingParameters(clrType, jsonValueReaderWriter: JsonStringReaderWriter.Instance),
                storeType,
                StoreTypePostfix.None,
                System.Data.DbType.String))
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected DuckDBBitStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    /// <inheritdoc />
    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBBitStringTypeMapping(parameters);
    }

    /// <inheritdoc />
    protected override string GenerateNonNullSqlLiteral(object value)
    {
        var bitString = value as string ?? ToBitString((BitArray)value);

        return $"'{bitString.Replace("'", "''")}'";
    }

    /// <inheritdoc />
    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }

    private static string ToBitString(BitArray value)
    {
        var builder = new StringBuilder(value.Length);

        for (var i = 0; i < value.Length; i++)
        {
            builder.Append(value[i] ? '1' : '0');
        }

        return builder.ToString();
    }

    private static BitArray ToBitArray(string value)
    {
        var result = new BitArray(value.Length);

        for (var i = 0; i < value.Length; i++)
        {
            result[i] = value[i] == '1';
        }

        return result;
    }
}
