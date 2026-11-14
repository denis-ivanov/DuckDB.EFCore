using System.Linq;
using System.Text;
using DuckDB.EFCore.Design.Internal;
using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.EntityFrameworkCore.TestUtilities;

public class DuckDBDatabaseCleaner : RelationalDatabaseCleaner
{
    private readonly DuckDBSqlGenerationHelper _sqlGenerationHelper = new(new RelationalSqlGenerationHelperDependencies());

    protected override IDatabaseModelFactory CreateDatabaseModelFactory(ILoggerFactory loggerFactory)
    {
        var services = new ServiceCollection();
        services.AddEntityFrameworkDuckDB();

        new DuckDBDesignTimeServices().ConfigureDesignTimeServices(services);

        return services
            .BuildServiceProvider()
            .GetRequiredService<IDatabaseModelFactory>();
    }

    protected override bool AcceptTable(DatabaseTable table)
        => table is not DatabaseView;

    protected override string BuildCustomSql(DatabaseModel databaseModel)
    {
        var sb = new StringBuilder();

        foreach (var view in databaseModel.Tables.OfType<DatabaseView>())
        {
            sb.Append("DROP VIEW IF EXISTS ")
                .Append(_sqlGenerationHelper.DelimitIdentifier(view.Name, view.Schema))
                .Append(';');
        }

        return sb.ToString();
    }

    public override void Clean(DatabaseFacade facade, bool createTables = true)
    {
        base.Clean(facade, createTables);
        facade.EnsureCreated();
    }
}
