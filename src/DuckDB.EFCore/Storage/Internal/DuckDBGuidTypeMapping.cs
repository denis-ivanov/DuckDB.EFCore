using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBGuidTypeMapping : GuidTypeMapping
{
    public DuckDBGuidTypeMapping() : base("UUID", System.Data.DbType.Guid)
    {
    }

    protected DuckDBGuidTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBGuidTypeMapping(parameters);
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