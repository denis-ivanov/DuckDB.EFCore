namespace Microsoft.EntityFrameworkCore;

internal static class DuckDBSkipReasons
{
    public const string Tbd = "TBD";
    
    public const string NotSupportedByDuckDB = "No support for that ALTER TABLE option yet!";
}
