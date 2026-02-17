using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBDoubleTypeMapping : DoubleTypeMapping
{
    public DuckDBDoubleTypeMapping() : base("DOUBLE", System.Data.DbType.Double)
    {
    }

    protected DuckDBDoubleTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBDoubleTypeMapping(parameters);
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