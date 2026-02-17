using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBNetTopologySuiteMethodCallTranslatorPlugin : IMethodCallTranslatorPlugin
{
    public IEnumerable<IMethodCallTranslator> Translators { get; } = [];
}