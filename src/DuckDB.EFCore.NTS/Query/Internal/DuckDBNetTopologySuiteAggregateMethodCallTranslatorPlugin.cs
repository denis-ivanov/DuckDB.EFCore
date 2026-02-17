using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBNetTopologySuiteAggregateMethodCallTranslatorPlugin : IAggregateMethodCallTranslatorPlugin
{
    public IEnumerable<IAggregateMethodCallTranslator> Translators { get; } = [];
}