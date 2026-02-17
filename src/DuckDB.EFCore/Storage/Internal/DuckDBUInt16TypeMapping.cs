using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBUInt16TypeMapping : UShortTypeMapping
{
    public DuckDBUInt16TypeMapping() : base("USMALLINT", System.Data.DbType.UInt16)
    {
    }

    protected DuckDBUInt16TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBUInt16TypeMapping(parameters);
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