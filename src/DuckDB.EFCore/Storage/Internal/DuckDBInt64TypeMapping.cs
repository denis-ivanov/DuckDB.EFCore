using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBInt64TypeMapping : LongTypeMapping
{
    public DuckDBInt64TypeMapping() : base("BIGINT", System.Data.DbType.Int64)
    {
    }

    protected DuckDBInt64TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBInt64TypeMapping(parameters);
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
