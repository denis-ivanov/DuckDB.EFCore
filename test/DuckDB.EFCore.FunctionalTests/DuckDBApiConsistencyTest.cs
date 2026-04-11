using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class DuckDBApiConsistencyTest : ApiConsistencyTestBase<DuckDBApiConsistencyTest.DuckDBApiConsistencyFixture>
{
    public DuckDBApiConsistencyTest(DuckDBApiConsistencyFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Public_inheritable_apis_should_be_virtual()
    {
        base.Public_inheritable_apis_should_be_virtual();
    }

    protected override void AddServices(ServiceCollection serviceCollection)
        => serviceCollection.AddEntityFrameworkDuckDB();

    protected override Assembly TargetAssembly
        => typeof(DuckDBRelationalConnection).Assembly;

    public class DuckDBApiConsistencyFixture : ApiConsistencyFixtureBase
    {
        public override HashSet<Type> FluentApiTypes { get; } =
        [
            typeof(DuckDBServiceCollectionExtensions),
            typeof(DuckDBDbContextOptionsBuilderExtensions),
            typeof(DuckDBDbContextOptionsBuilder),
            typeof(DuckDBTableBuilderExtensions)
        ];
    }
}
