using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBRowValueTypeMapping : RelationalTypeMapping
{
    public DuckDBRowValueTypeMapping(Type clrType)
        : base(new RelationalTypeMappingParameters(new CoreTypeMappingParameters(clrType), storeType: "record"))
    {
    }

    protected DuckDBRowValueTypeMapping(RelationalTypeMappingParameters parameters)
        : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new DuckDBRowValueTypeMapping(parameters);

    protected override string GenerateNonNullSqlLiteral(object value)
        => throw new InvalidOperationException("GenerateNonNullSqlLiteral not supported on DuckDBRowValueTypeMapping");

    protected override void ConfigureParameter(DbParameter parameter)
        => throw new InvalidOperationException("ConfigureParameter not supported on DuckDBRowValueTypeMapping");
}
