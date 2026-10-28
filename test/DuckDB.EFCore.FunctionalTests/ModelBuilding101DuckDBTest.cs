using DuckDB.EFCore.Extensions;

namespace Microsoft.EntityFrameworkCore;

public class ModelBuilding101DuckDBTest : ModelBuilding101RelationalTestBase
{
    protected override DbContextOptionsBuilder ConfigureContext(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseDuckDB();
}
