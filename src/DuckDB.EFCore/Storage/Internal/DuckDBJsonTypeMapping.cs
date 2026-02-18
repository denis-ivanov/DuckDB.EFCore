using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBJsonTypeMapping : JsonTypeMapping
{
    public DuckDBJsonTypeMapping() : base("JSON", typeof(JsonTypePlaceholder), System.Data.DbType.String)
    {
    }

    protected DuckDBJsonTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBJsonTypeMapping(parameters);
    }
}