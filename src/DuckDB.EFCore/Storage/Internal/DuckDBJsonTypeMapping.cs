using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Reflection;

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

    public override MethodInfo GetDataReaderMethod()
    {
        return GetDataReaderMethod(typeof(string));
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }
}
