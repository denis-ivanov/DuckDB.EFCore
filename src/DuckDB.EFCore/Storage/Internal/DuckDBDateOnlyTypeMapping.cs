using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBDateOnlyTypeMapping : DateOnlyTypeMapping
{
    public DuckDBDateOnlyTypeMapping() : base("DATE", System.Data.DbType.Date)
    {
    }

    protected DuckDBDateOnlyTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBDateOnlyTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((DuckDBParameter)parameter).RemoveDollarSign();
        base.ConfigureParameter(parameter);
    }

    protected override string SqlLiteralFormatString => "'{0:yyyy-MM-dd}'";
}
