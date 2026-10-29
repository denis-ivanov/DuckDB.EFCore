using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public abstract class SaveChangesInterceptionDuckDBTestBase : SaveChangesInterceptionTestBase
{
    protected SaveChangesInterceptionDuckDBTestBase(InterceptionDuckDBFixtureBase fixture) : base(fixture)
    {
    }

    public abstract class InterceptionDuckDBFixtureBase : InterceptionFixtureBase
    {
        protected override string StoreName
            => "SaveChangesInterception";

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override IServiceCollection InjectInterceptors(
            IServiceCollection serviceCollection,
            IEnumerable<IInterceptor> injectedInterceptors)
            => base.InjectInterceptors(serviceCollection.AddEntityFrameworkDuckDB(), injectedInterceptors);
    }

    public class SaveChangesInterceptionDuckDBTest : SaveChangesInterceptionDuckDBTestBase, IClassFixture<SaveChangesInterceptionDuckDBTest.InterceptionDuckDBFixture>
    {
        public SaveChangesInterceptionDuckDBTest(InterceptionDuckDBFixture fixture) : base(fixture)
        {
        }

        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => false;
        }
    }

    public class SaveChangesInterceptionWithDiagnosticsDuckDBTest : SaveChangesInterceptionDuckDBTestBase,
            IClassFixture<SaveChangesInterceptionWithDiagnosticsDuckDBTest.InterceptionDuckDBFixture>
    {
        public SaveChangesInterceptionWithDiagnosticsDuckDBTest(InterceptionDuckDBFixture fixture) : base(fixture)
        {
        }

        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => true;
        }
    }
}
