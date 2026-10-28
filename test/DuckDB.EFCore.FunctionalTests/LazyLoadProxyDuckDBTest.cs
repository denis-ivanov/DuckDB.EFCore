using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class LazyLoadProxyDuckDBTest : LazyLoadProxyRelationalTestBase<LazyLoadProxyDuckDBTest.LoadDuckDBFixture>
{
    public LazyLoadProxyDuckDBTest(LoadDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_serialize_proxies_to_JSON()
    {
        base.Can_serialize_proxies_to_JSON();
    }

    public class ThrowingInterceptor : DbCommandInterceptor
    {
        public bool Throw { get; set; }

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            if (Throw)
            {
                throw new Exception("Bang!");
            }

            return base.ReaderExecuting(command, eventData, result);
        }
    }

    public class LoadDuckDBFixture : LoadRelationalFixtureBase
    {
        public ThrowingInterceptor Interceptor { get; } = new();

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder.UseLazyLoadingProxies().AddInterceptors(Interceptor));

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
