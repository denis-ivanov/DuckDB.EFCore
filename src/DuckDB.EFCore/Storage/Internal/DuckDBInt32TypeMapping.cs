using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBInt32TypeMapping : IntTypeMapping
{
    public DuckDBInt32TypeMapping() : base("INTEGER", System.Data.DbType.Int32)
    {
    }

    protected DuckDBInt32TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBInt32TypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        if (parameter.ParameterName.StartsWith('$'))
        {
            parameter.ParameterName = parameter.ParameterName.Substring(1);
        }

        base.ConfigureParameter(parameter);
    }
}