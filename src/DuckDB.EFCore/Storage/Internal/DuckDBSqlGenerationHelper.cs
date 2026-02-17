using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBSqlGenerationHelper : RelationalSqlGenerationHelper
{
    public DuckDBSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies) : base(dependencies)
    {
    }

    public override string GenerateParameterName(string name)
    {
        return name.StartsWith('$') ? name : '$' + name;
    }

    public override void GenerateParameterName(StringBuilder builder, string name)
    {
        builder.Append('$').Append(name);
    }
}
