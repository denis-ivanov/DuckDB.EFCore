using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBDecimalTypeMapping : DecimalTypeMapping
{
    private const int DefaultPrecision = 18;
    private const int DefaultScale = 3;

    public static readonly DuckDBDecimalTypeMapping Default = new(DefaultPrecision, DefaultScale);

    public DuckDBDecimalTypeMapping(int? precision = null, int? scale = null)
        : base(new RelationalTypeMappingParameters(
            new CoreTypeMappingParameters(
                clrType: typeof(decimal),
                jsonValueReaderWriter: JsonDecimalReaderWriter.Instance),
            storeType: "DECIMAL",
            StoreTypePostfix.PrecisionAndScale,
            System.Data.DbType.Decimal,
            precision: precision ?? DefaultPrecision,
            scale: scale ?? DefaultScale))
    {
    }

    protected DuckDBDecimalTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBDecimalTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        if (parameter.ParameterName.StartsWith('$'))
        {
            parameter.ParameterName = parameter.ParameterName[1..];
        }

        base.ConfigureParameter(parameter);
    }
}
