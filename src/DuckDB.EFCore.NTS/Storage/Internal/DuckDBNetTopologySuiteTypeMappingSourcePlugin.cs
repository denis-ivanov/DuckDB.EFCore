using Microsoft.EntityFrameworkCore.Storage;

namespace DuckDB.EFCore.NTS.Storage.Internal;

public class DuckDBNetTopologySuiteTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
{
    public RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        // TODO Implement NetTopologySuite type mappings for DuckDB
        return null;
    }
}