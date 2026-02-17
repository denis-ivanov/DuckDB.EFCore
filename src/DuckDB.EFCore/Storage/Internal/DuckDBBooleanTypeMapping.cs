using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBBooleanTypeMapping : BoolTypeMapping
{
    public DuckDBBooleanTypeMapping() : base("BOOLEAN", System.Data.DbType.Boolean)
    {
    }

    protected DuckDBBooleanTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBBooleanTypeMapping(parameters);
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
