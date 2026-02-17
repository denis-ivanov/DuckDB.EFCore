using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBSByteTypeMapping : SByteTypeMapping
{
    public DuckDBSByteTypeMapping() : base("TINYINT", System.Data.DbType.SByte)
    {
    }

    protected DuckDBSByteTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBSByteTypeMapping(parameters);
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