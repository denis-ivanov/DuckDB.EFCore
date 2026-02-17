using Microsoft.EntityFrameworkCore.Update;

namespace DuckDB.EFCore.Update.Internal;

public class DuckDBUpdateSqlGenerator : UpdateSqlGenerator
{
    public DuckDBUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }
}