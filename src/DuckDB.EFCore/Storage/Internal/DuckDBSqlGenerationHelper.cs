using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBSqlGenerationHelper : RelationalSqlGenerationHelper
{
    private static readonly HashSet<string> ReservedWords = new(StringComparer.InvariantCultureIgnoreCase);

    static DuckDBSqlGenerationHelper()
    {
        using var connection = new DuckDBConnection(DuckDBConnectionStringBuilder.InMemorySharedConnectionString);
        using var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT keyword_name FROM duckdb_keywords()
                              UNION
                              SELECT function_name FROM duckdb_functions()
                              """;

        connection.Open();

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            ReservedWords.Add(reader.GetString(0));
        }
    }

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

    public override string DelimitIdentifier(string identifier)
    {
        return RequiresQuoting(identifier) ? base.DelimitIdentifier(identifier) : identifier;
    }

    public override void DelimitIdentifier(StringBuilder builder, string identifier)
    {
        if (RequiresQuoting(identifier))
        {
            base.DelimitIdentifier(builder, identifier);
        }
        else
        {
            builder.Append(identifier);
        }
    }

    private static bool RequiresQuoting(string identifier)
    {
        var first = identifier[0];

        if (!char.IsLower(first) && first != '_')
        {
            return true;
        }

        for (var i = 1; i < identifier.Length; i++)
        {
            var c = identifier[i];

            if (char.IsLower(c) || char.IsDigit(c) || c == '_')
            {
                continue;
            }

            return true;
        }

        return ReservedWords.Contains(identifier);
    }
}
