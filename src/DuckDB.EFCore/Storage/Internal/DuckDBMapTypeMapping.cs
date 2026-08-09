using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;

namespace DuckDB.EFCore.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBMapTypeMapping : RelationalTypeMapping
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual RelationalTypeMapping KeyTypeMapping { get; }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual RelationalTypeMapping ValueTypeMapping { get; }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBMapTypeMapping(
        Type clrType,
        RelationalTypeMapping keyTypeMapping,
        RelationalTypeMapping valueTypeMapping,
        string? storeType = null)
        : this(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(clrType, comparer: CreateComparer(clrType)),
                storeType ?? CreateStoreType(keyTypeMapping, valueTypeMapping)),
            keyTypeMapping,
            valueTypeMapping)
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected DuckDBMapTypeMapping(
        RelationalTypeMappingParameters parameters,
        RelationalTypeMapping keyTypeMapping,
        RelationalTypeMapping valueTypeMapping)
        : base(parameters)
    {
        KeyTypeMapping = keyTypeMapping;
        ValueTypeMapping = valueTypeMapping;
    }

    /// <summary>
    ///     Builds the DuckDB store type name, for example <c>MAP(VARCHAR, INTEGER)</c>.
    /// </summary>
    public static string CreateStoreType(RelationalTypeMapping keyTypeMapping, RelationalTypeMapping valueTypeMapping)
        => $"MAP({keyTypeMapping.StoreType}, {valueTypeMapping.StoreType})";

    /// <inheritdoc />
    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new DuckDBMapTypeMapping(parameters, KeyTypeMapping, ValueTypeMapping);

    /// <inheritdoc />
    public override DbParameter CreateParameter(
        DbCommand command,
        string name,
        object? value,
        bool? nullable = null,
        ParameterDirection direction = ParameterDirection.Input)
        // DuckDB.NET cannot bind a dictionary directly: IDictionary is an ICollection, so it ends up in the
        // LIST branch of its CLR-to-DuckDB converter and fails. Send the DuckDB textual map representation
        // instead and let DuckDB implicitly cast VARCHAR to MAP.
        => base.CreateParameter(command, name, value is IDictionary dictionary ? ToMapString(dictionary) : value, nullable, direction);

    /// <inheritdoc />
    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        parameter.DbType = System.Data.DbType.String;
        base.ConfigureParameter(parameter);
    }

    /// <inheritdoc />
    protected override string GenerateNonNullSqlLiteral(object value)
    {
        if (value is not IDictionary dictionary)
        {
            throw new ArgumentException($"'{value}' is not an {nameof(IDictionary)}", nameof(value));
        }

        var builder = new StringBuilder("MAP {");
        var isFirst = true;

        foreach (DictionaryEntry entry in dictionary)
        {
            if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                builder.Append(", ");
            }

            builder
                .Append(KeyTypeMapping.GenerateProviderValueSqlLiteral(entry.Key))
                .Append(": ")
                .Append(
                    entry.Value is null
                        ? "NULL"
                        : ValueTypeMapping.GenerateProviderValueSqlLiteral(entry.Value));
        }

        // An empty map literal has type MAP(NULL, NULL), so always pin the literal to the column type.
        return builder.Append("}::").Append(StoreType).ToString();
    }

    /// <summary>
    ///     Converts a dictionary into the textual representation DuckDB uses when casting VARCHAR to MAP,
    ///     for example <c>{'a'='1', 'b'=NULL}</c>.
    /// </summary>
    private string ToMapString(IDictionary dictionary)
    {
        var builder = new StringBuilder("{");
        var isFirst = true;

        foreach (DictionaryEntry entry in dictionary)
        {
            if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                builder.Append(", ");
            }

            if (entry.Key is null)
            {
                throw new InvalidOperationException(
                    $"Cannot store a map in a column of type '{StoreType}' because it contains a null key.");
            }

            builder
                .Append(ToElementString(entry.Key))
                .Append('=')
                .Append(ToElementString(entry.Value));
        }

        return builder.Append('}').ToString();
    }

    private static string ToElementString(object? value)
    {
        if (value is null)
        {
            return "NULL";
        }

        var text = value switch
        {
            bool b => b ? "true" : "false",
            byte[] => throw new NotSupportedException("Binary map keys and values are not supported."),
            DateTime dateTime => dateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture),
            DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss.ffffffzzz", CultureInfo.InvariantCulture),
            DateOnly dateOnly => dateOnly.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            TimeOnly timeOnly => timeOnly.ToString("HH:mm:ss.ffffff", CultureInfo.InvariantCulture),
            TimeSpan timeSpan => timeSpan.ToString("c", CultureInfo.InvariantCulture),
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => value.ToString() ?? string.Empty
        };

        // Inside the textual map representation DuckDB unescapes '\\' and '\''; everything else is literal.
        return $"'{text.Replace("\\", "\\\\").Replace("'", "\\'")}'";
    }

    private static ValueComparer CreateComparer(Type clrType)
    {
        var dictionaryInterface = clrType.GetGenericTypeImplementations(typeof(IDictionary<,>)).First();

        return (ValueComparer)Activator.CreateInstance(
            typeof(MapComparer<,,>).MakeGenericType(
                clrType,
                dictionaryInterface.GenericTypeArguments[0],
                dictionaryInterface.GenericTypeArguments[1]))!;
    }

    private sealed class MapComparer<TDictionary, TKey, TValue> : ValueComparer<TDictionary>
        where TDictionary : IDictionary<TKey, TValue>, new()
        where TKey : notnull
    {
        public MapComparer()
            : base(
                (a, b) => AreEqual(a, b),
                d => GetMapHashCode(d),
                d => Snapshot(d))
        {
        }

        private static bool AreEqual(TDictionary? a, TDictionary? b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is null || b is null || a.Count != b.Count)
            {
                return false;
            }

            foreach (var pair in a)
            {
                if (!b.TryGetValue(pair.Key, out var otherValue)
                    || !EqualityComparer<TValue>.Default.Equals(pair.Value, otherValue))
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetMapHashCode(TDictionary? dictionary)
        {
            if (dictionary is null)
            {
                return 0;
            }

            var hash = 0;

            // Order-independent so that dictionaries comparing equal always hash equal.
            foreach (var pair in dictionary)
            {
                hash ^= HashCode.Combine(pair.Key, pair.Value);
            }

            return hash;
        }

        private static TDictionary Snapshot(TDictionary? dictionary)
        {
            if (dictionary is null)
            {
                return default!;
            }

            var snapshot = new TDictionary();

            foreach (var pair in dictionary)
            {
                snapshot.Add(pair.Key, pair.Value);
            }

            return snapshot;
        }
    }
}
