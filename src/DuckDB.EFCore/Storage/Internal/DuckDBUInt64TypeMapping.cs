using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBUInt64TypeMapping : ULongTypeMapping
{
    public DuckDBUInt64TypeMapping() : base("UBIGINT", System.Data.DbType.UInt64)
    {
    }

    protected DuckDBUInt64TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBUInt64TypeMapping(parameters);
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