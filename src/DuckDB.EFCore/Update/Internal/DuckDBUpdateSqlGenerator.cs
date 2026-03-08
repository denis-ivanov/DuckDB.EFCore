using Microsoft.EntityFrameworkCore.Update;
using System.Text;

namespace DuckDB.EFCore.Update.Internal;

public class DuckDBUpdateSqlGenerator : UpdateSqlGenerator
{
    public DuckDBUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    public override void AppendNextSequenceValueOperation(StringBuilder commandStringBuilder, string name, string? schema)
    {
        commandStringBuilder.Append("nextval(");
        SqlGenerationHelper.DelimitIdentifier(commandStringBuilder, name, schema);
        commandStringBuilder.Append(')');
    }
}
