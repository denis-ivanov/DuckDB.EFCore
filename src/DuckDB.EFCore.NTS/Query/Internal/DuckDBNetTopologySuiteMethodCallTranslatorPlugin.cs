using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBNetTopologySuiteMethodCallTranslatorPlugin : IMethodCallTranslatorPlugin
{
    public DuckDBNetTopologySuiteMethodCallTranslatorPlugin(
        ISqlExpressionFactory sqlExpressionFactory,
        IRelationalTypeMappingSource typeMappingSource)
    {
        Translators =
        [
            new DuckDBGeometryMethodTranslator(sqlExpressionFactory),
            new DuckDBGeometryCollectionMethodTranslator(sqlExpressionFactory),
            new DuckDBLineStringMethodTranslator(sqlExpressionFactory),
            new DuckDBPolygonMethodTranslator(sqlExpressionFactory),
            new DuckDBDbFunctionsExtensionsMethodTranslator(sqlExpressionFactory, typeMappingSource)
        ];
    }

    public IEnumerable<IMethodCallTranslator> Translators { get; }
}
