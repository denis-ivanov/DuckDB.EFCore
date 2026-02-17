using DuckDB.EFCore.Diagnostics.Internal;
using DuckDB.EFCore.Extensions;
using DuckDB.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.FunctionalTests.TestUtilities;

public class DuckDBTestHelpers : RelationalTestHelpers
{
    protected DuckDBTestHelpers()
    {
    }

    public static DuckDBTestHelpers Instance { get; } = new();

    public override IServiceCollection AddProviderServices(IServiceCollection services)
        => services.AddEntityFrameworkDuckDB();

    public override DbContextOptionsBuilder UseProviderOptions(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseDuckDB(new DuckDBConnection(DuckDBConnectionStringBuilder.InMemoryConnectionString));

    public override LoggingDefinitions LoggingDefinitions { get; } = new DuckDBLoggingDefinitions();
}
