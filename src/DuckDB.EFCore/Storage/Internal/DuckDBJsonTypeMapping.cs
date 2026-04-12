using DuckDB.EFCore.Extensions.Internal;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBJsonTypeMapping : JsonTypeMapping
{
    public DuckDBJsonTypeMapping(Type clrType)
        : base("JSON", clrType, System.Data.DbType.String)
    {
    }

    protected DuckDBJsonTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new DuckDBJsonTypeMapping(parameters);
    }

    protected virtual string EscapeSqlLiteral(string literal)
    {
        return literal.Replace("'", "''");
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        switch (value)
        {
            case JsonDocument _:
            case JsonElement _:
                {
                    using var stream = new MemoryStream();
                    using var writer = new Utf8JsonWriter(stream);
                    if (value is JsonDocument doc)
                    {
                        doc.WriteTo(writer);
                    }
                    else
                    {
                        ((JsonElement)value).WriteTo(writer);
                    }

                    writer.Flush();
                    return $"'{EscapeSqlLiteral(Encoding.UTF8.GetString(stream.ToArray()))}'";
                }
            case string s:
                return $"'{EscapeSqlLiteral(s)}'";
            default:
                return $"'{EscapeSqlLiteral(JsonSerializer.Serialize(value))}'";
        }
    }

    public override Expression GenerateCodeLiteral(object value)
        => value switch
        {
            JsonDocument document => Expression.Call(
                ParseMethod, Expression.Constant(document.RootElement.ToString()), DefaultJsonDocumentOptions),
            JsonElement element => Expression.Property(
                Expression.Call(ParseMethod, Expression.Constant(element.ToString()), DefaultJsonDocumentOptions),
                nameof(JsonDocument.RootElement)),
            string s => Expression.Constant(s),
            _ => throw new NotSupportedException("Cannot generate code literals for JSON POCOs")
        };

    private static readonly Expression DefaultJsonDocumentOptions = Expression.New(typeof(JsonDocumentOptions));

    private static readonly MethodInfo ParseMethod =
        typeof(JsonDocument).GetMethod(nameof(JsonDocument.Parse), [typeof(string), typeof(JsonDocumentOptions)])!;

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
