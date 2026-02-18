using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBCharTypeMapping : StringTypeMapping
{
    public DuckDBCharTypeMapping()
        : base(new RelationalTypeMappingParameters(
            new CoreTypeMappingParameters(
                clrType: typeof(char),
                converter: new CharToStringConverter(),
                comparer: null,
                keyComparer: null,
                providerValueComparer: null,
                valueGeneratorFactory: null,
                elementMapping: null,
                jsonValueReaderWriter: JsonStringReaderWriter.Instance),
            "VARCHAR",
            StoreTypePostfix.Size,
            System.Data.DbType.StringFixedLength,
            unicode: true,
            size: 1,
            fixedLength: true))
    {
    }

    protected DuckDBCharTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBCharTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }
}