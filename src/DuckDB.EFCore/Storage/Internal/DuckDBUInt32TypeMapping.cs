using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBUInt32TypeMapping : UIntTypeMapping
{
    public DuckDBUInt32TypeMapping() : base("UINTEGER", System.Data.DbType.UInt32)
    {
    }

    protected DuckDBUInt32TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBUInt32TypeMapping(parameters);
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