using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
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
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return (bool)value ? "true" : "false";
    }
}
