using Microsoft.EntityFrameworkCore.Query;

namespace DuckDB.EFCore.NTS.Query.Internal;

public class DuckDBNetTopologySuiteMemberTranslatorPlugin : IMemberTranslatorPlugin
{
    public IEnumerable<IMemberTranslator> Translators { get; } = [];
}