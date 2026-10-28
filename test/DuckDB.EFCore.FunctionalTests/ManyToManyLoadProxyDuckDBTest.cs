using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore;

public class ManyToManyLoadProxyDuckDBTest : ManyToManyLoadDuckDBTestBase<ManyToManyLoadProxyDuckDBTest.ManyToManyLoadProxyDuckDBFixture>
{
    public ManyToManyLoadProxyDuckDBTest(ManyToManyLoadProxyDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    protected override bool ExpectLazyLoading
        => true;

    public class ManyToManyLoadProxyDuckDBFixture : ManyToManyLoadDuckDBFixtureBase
    {
        protected override string StoreName
            => "ManyToManyLoadProxies";

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder).UseLazyLoadingProxies();

        protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
            => base.AddServices(serviceCollection.AddEntityFrameworkProxies());
    }
}
