using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Buffers;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

namespace DuckDB.EFCore.Storage.Json.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBUInt128ReaderWriter : JsonValueReaderWriter<UInt128>
{
    private static readonly PropertyInfo InstanceProperty = typeof(DuckDBUInt128ReaderWriter).GetProperty(nameof(Instance))!;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static DuckDBUInt128ReaderWriter Instance { get; } = new();

    /// <inheritdoc />
    public override Expression ConstructorExpression => Expression.Property(null, InstanceProperty);
    
    /// <inheritdoc />
    public override UInt128 FromJsonTyped(ref Utf8JsonReaderManager manager, object? existingObject = null)
    {
        return UInt128.Parse(manager.CurrentReader.HasValueSequence
            ? manager.CurrentReader.ValueSequence.ToArray()
            : manager.CurrentReader.ValueSpan);
    }

    /// <inheritdoc />
    public override void ToJsonTyped(Utf8JsonWriter writer, UInt128 value)
    {
        writer.WriteRawValue(value.ToString(CultureInfo.InvariantCulture));
    }
}
