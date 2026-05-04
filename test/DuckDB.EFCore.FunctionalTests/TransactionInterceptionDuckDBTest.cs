using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public abstract class TransactionInterceptionDuckDBTestBase(TransactionInterceptionDuckDBTestBase.InterceptionDuckDBFixtureBase fixture)
    : TransactionInterceptionTestBase(fixture)
{
    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task UseTransaction_without_interceptor(bool async)
    {
        await base.UseTransaction_without_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_BeginTransaction(bool async)
    {
        await base.Intercept_BeginTransaction(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_BeginTransaction_with_isolation_level(bool async)
    {
        await base.Intercept_BeginTransaction_with_isolation_level(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_BeginTransaction_to_wrap(bool async)
    {
        await base.Intercept_BeginTransaction_to_wrap(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_UseTransaction(bool async)
    {
        await base.Intercept_UseTransaction(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_UseTransaction_to_wrap(bool async)
    {
        await base.Intercept_UseTransaction_to_wrap(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_Commit(bool async)
    {
        await base.Intercept_Commit(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_Commit_to_suppress(bool async)
    {
        await base.Intercept_Commit_to_suppress(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_Rollback(bool async)
    {
        await base.Intercept_Rollback(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_Rollback_to_suppress(bool async)
    {
        await base.Intercept_Rollback_to_suppress(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_CreateSavepoint(bool async)
    {
        await base.Intercept_CreateSavepoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_RollbackToSavepoint(bool async)
    {
        await base.Intercept_RollbackToSavepoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_ReleaseSavepoint(bool async)
    {
        await base.Intercept_ReleaseSavepoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_error_on_commit_or_rollback(bool async, bool commit)
    {
        await base.Intercept_error_on_commit_or_rollback(async, commit);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_connection_with_multiple_interceptors(bool async)
    {
        await base.Intercept_connection_with_multiple_interceptors(async);
    }

    public abstract class InterceptionDuckDBFixtureBase : InterceptionTestBase.InterceptionFixtureBase
    {
        protected override string StoreName
            => "TransactionInterception";

        protected override ITestStoreFactory TestStoreFactory
            => SharedCacheDuckDBTestStoreFactory.Instance;

        protected override IServiceCollection InjectInterceptors(
            IServiceCollection serviceCollection,
            IEnumerable<IInterceptor> injectedInterceptors)
            => base.InjectInterceptors(serviceCollection.AddEntityFrameworkDuckDB(), injectedInterceptors);
    }

    public class TransactionInterceptionDuckDBTest(TransactionInterceptionDuckDBTest.InterceptionDuckDBFixture fixture)
        : TransactionInterceptionDuckDBTestBase(fixture), IClassFixture<TransactionInterceptionDuckDBTest.InterceptionDuckDBFixture>
    {
        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => false;
        }
    }

    public class TransactionInterceptionWithDiagnosticsDuckDBTest(
        TransactionInterceptionWithDiagnosticsDuckDBTest.InterceptionDuckDBFixture fixture)
        : TransactionInterceptionDuckDBTestBase(fixture),
            IClassFixture<TransactionInterceptionWithDiagnosticsDuckDBTest.InterceptionDuckDBFixture>
    {
        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => true;
        }
    }
}
