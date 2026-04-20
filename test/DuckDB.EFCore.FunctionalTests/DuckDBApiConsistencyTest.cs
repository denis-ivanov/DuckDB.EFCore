using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

public class DuckDBApiConsistencyTest : ApiConsistencyTestBase<DuckDBApiConsistencyTest.DuckDBApiConsistencyFixture>
{
    public DuckDBApiConsistencyTest(DuckDBApiConsistencyFixture fixture) : base(fixture)
    {
    }

    protected override void AddServices(ServiceCollection serviceCollection)
        => serviceCollection.AddEntityFrameworkDuckDB();

    protected override Assembly TargetAssembly
        => typeof(DuckDBRelationalConnection).Assembly;

    public sealed class DuckDBApiConsistencyFixture : ApiConsistencyFixtureBase
    {
        private static readonly MethodInfo CloseDbConnection = typeof(DuckDBRelationalConnection)
            .GetMethod(
                "CloseDbConnectionAsync",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                Type.EmptyTypes)!;

        public DuckDBApiConsistencyFixture()
        {
            AsyncMethodExceptions.Add(CloseDbConnection);
        }

        public override HashSet<Type> FluentApiTypes { get; } =
        [
            typeof(DuckDBServiceCollectionExtensions),
            typeof(DuckDBDbContextOptionsBuilderExtensions),
            typeof(DuckDBDbContextOptionsBuilder),
            typeof(DuckDBTableBuilderExtensions)
        ];
    }
}
