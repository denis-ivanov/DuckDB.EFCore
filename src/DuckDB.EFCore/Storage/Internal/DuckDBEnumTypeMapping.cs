using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Reflection;

namespace DuckDB.EFCore.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new EnumTypeMapping release.
/// </summary>
public class DuckDBEnumTypeMapping : RelationalTypeMapping
{
    private static readonly MethodInfo GetFieldValueMethod = typeof(DuckDBDataReader)
        .GetMethod(nameof(DuckDBDataReader.GetFieldValue), 1, [typeof(int)])!;

    private readonly MethodInfo _dataReaderMethod;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new release.
    /// </summary>
    public DuckDBEnumTypeMapping(Type enumType, string storeType)
        : base(
            storeType: storeType,
            clrType: enumType,
            dbType: System.Data.DbType.String,
            jsonValueReaderWriter: null)
    {
        _dataReaderMethod = GetFieldValueMethod.MakeGenericMethod(enumType);
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new release.
    /// </summary>
    protected DuckDBEnumTypeMapping(RelationalTypeMappingParameters parameters)
        : base(parameters)
    {
        _dataReaderMethod = GetFieldValueMethod.MakeGenericMethod(parameters.CoreParameters.ClrType);
    }

    /// <inheritdoc />
    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new DuckDBEnumTypeMapping(parameters);

    /// <inheritdoc />
    public override MethodInfo GetDataReaderMethod()
        => _dataReaderMethod;

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
        var enumValue = (Enum)value;
        var literal = enumValue.ToString();
        return $"'{literal.Replace("'", "''")}'::{StoreType}";
    }
}
