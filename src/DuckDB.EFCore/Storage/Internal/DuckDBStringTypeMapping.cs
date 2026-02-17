using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBStringTypeMapping : StringTypeMapping
{
    public static new DuckDBStringTypeMapping Default { get; } = new(DuckDBTypeMappingSource.VarCharTypeName);
    
    public DuckDBStringTypeMapping(
        string storeType,
        DbType? dbType = null,
        bool unicode = false,
        int? size = null)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    typeof(string), jsonValueReaderWriter: JsonStringReaderWriter.Instance), storeType, StoreTypePostfix.None, dbType,
                unicode, size))
    {
    }

    protected DuckDBStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBStringTypeMapping(parameters);
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