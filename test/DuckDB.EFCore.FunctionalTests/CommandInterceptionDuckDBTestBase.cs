using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class CommandInterceptionDuckDBTestBase : CommandInterceptionTestBase
{
    public CommandInterceptionDuckDBTestBase(CommandInterceptionDuckDBTestBase.InterceptionDuckDBFixtureBase fixture)
        : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_CommandInitialized_to_mutate_query_command(bool async, bool inject)
    {
        return await base.Intercept_CommandInitialized_to_mutate_query_command(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_CommandInitialized_to_mutate_scalar_command(bool async, bool inject)
    {
        await base.Intercept_CommandInitialized_to_mutate_scalar_command(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_one_app_and_one_injected_interceptor(bool async)
    {
        await base.Intercept_non_query_one_app_and_one_injected_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_passively(bool async, bool inject)
    {
        await base.Intercept_non_query_passively(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_that_throws(bool async, bool inject)
    {
        await base.Intercept_non_query_that_throws(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_to_mutate_command(bool async, bool inject)
    {
        await base.Intercept_non_query_to_mutate_command(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_to_replace_execution(bool async, bool inject)
    {
        await base.Intercept_non_query_to_replace_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_to_replace_result(bool async, bool inject)
    {
        await base.Intercept_non_query_to_replace_result(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_to_suppress_execution(bool async, bool inject)
    {
        await base.Intercept_non_query_to_suppress_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_to_throw(bool async, bool inject)
    {
        await base.Intercept_non_query_to_throw(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_non_query_with_explicitly_composed_app_interceptor(bool async)
    {
        await base.Intercept_non_query_with_explicitly_composed_app_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intercept_non_query_with_two_injected_interceptors(bool async)
    {
        return base.Intercept_non_query_with_two_injected_interceptors(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_passively(bool async, bool inject)
    {
        return await base.Intercept_query_passively(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_that_throws(bool async, bool inject)
    {
        await base.Intercept_query_that_throws(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_call_DataReader_NextResult(bool async, bool inject)
    {
        return await base.Intercept_query_to_call_DataReader_NextResult(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_mutate_command(bool async, bool inject)
    {
        return await base.Intercept_query_to_mutate_command(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_replace_execution(bool async, bool inject)
    {
        return await base.Intercept_query_to_replace_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_replace_result(bool async, bool inject)
    {
        return await base.Intercept_query_to_replace_result(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_suppress_close_of_reader(bool async, bool inject)
    {
        return await base.Intercept_query_to_suppress_close_of_reader(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_to_suppress_command_creation(bool async, bool inject)
    {
        await base.Intercept_query_to_suppress_command_creation(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task<string> Intercept_query_to_suppress_execution(bool async, bool inject)
    {
        return await base.Intercept_query_to_suppress_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_to_throw(bool async, bool inject)
    {
        await base.Intercept_query_to_throw(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_with_explicitly_composed_app_interceptor(bool async)
    {
        await base.Intercept_query_with_explicitly_composed_app_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_with_one_app_and_one_injected_interceptor(bool async)
    {
        await base.Intercept_query_with_one_app_and_one_injected_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_query_with_two_injected_interceptors(bool async)
    {
        await base.Intercept_query_with_two_injected_interceptors(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_passively(bool async, bool inject)
    {
        await base.Intercept_scalar_passively(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_that_throws(bool async, bool inject)
    {
        await base.Intercept_scalar_that_throws(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_to_mutate_command(bool async, bool inject)
    {
        await base.Intercept_scalar_to_mutate_command(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_to_replace_execution(bool async, bool inject)
    {
        await base.Intercept_scalar_to_replace_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_to_replace_result(bool async, bool inject)
    {
        await base.Intercept_scalar_to_replace_result(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Intercept_scalar_to_suppress_execution(bool async, bool inject)
    {
        return base.Intercept_scalar_to_suppress_execution(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_to_throw(bool async, bool inject)
    {
        await base.Intercept_scalar_to_throw(async, inject);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_with_explicitly_composed_app_interceptor(bool async)
    {
        await base.Intercept_scalar_with_explicitly_composed_app_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_with_one_app_and_one_injected_interceptor(bool async)
    {
        await base.Intercept_scalar_with_one_app_and_one_injected_interceptor(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Intercept_scalar_with_two_injected_interceptors(bool async)
    {
        await base.Intercept_scalar_with_two_injected_interceptors(async);
    }

    public abstract class InterceptionDuckDBFixtureBase : InterceptionFixtureBase
    {
        protected override string StoreName
            => "CommandInterception";

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override IServiceCollection InjectInterceptors(
            IServiceCollection serviceCollection,
            IEnumerable<IInterceptor> injectedInterceptors)
            => base.InjectInterceptors(serviceCollection.AddEntityFrameworkDuckDB(), injectedInterceptors);
    }

    public class CommandInterceptionDuckDBTest(CommandInterceptionDuckDBTest.InterceptionDuckDBFixture fixture)
        : CommandInterceptionDuckDBTestBase(fixture), IClassFixture<CommandInterceptionDuckDBTest.InterceptionDuckDBFixture>
    {
        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => false;
        }
    }

    public class CommandInterceptionWithDiagnosticsDuckDBTest(
        CommandInterceptionWithDiagnosticsDuckDBTest.InterceptionDuckDBFixture fixture)
        : CommandInterceptionDuckDBTestBase(fixture), IClassFixture<CommandInterceptionWithDiagnosticsDuckDBTest.InterceptionDuckDBFixture>
    {
        public class InterceptionDuckDBFixture : InterceptionDuckDBFixtureBase
        {
            protected override bool ShouldSubscribeToDiagnosticListener
                => true;
        }
    }
}
