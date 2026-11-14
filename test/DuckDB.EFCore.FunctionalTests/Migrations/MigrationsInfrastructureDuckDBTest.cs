using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Migrations;

public class MigrationsInfrastructureDuckDBTest : MigrationsInfrastructureTestBase<MigrationsInfrastructureDuckDBTest.MigrationsInfrastructureDuckDBFixture>
{
    public MigrationsInfrastructureDuckDBTest(MigrationsInfrastructureDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_diff_against_2_2_model()
    {
        throw new NotImplementedException();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_diff_against_3_0_ASP_NET_Identity_model()
    {
        throw new NotImplementedException();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_diff_against_2_2_ASP_NET_Identity_model()
    {
        throw new NotImplementedException();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_diff_against_2_1_ASP_NET_Identity_model()
    {
        throw new NotImplementedException();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_apply_one_migration_in_parallel()
    {
        base.Can_apply_one_migration_in_parallel();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_apply_one_migration_in_parallel_async()
    {
        return base.Can_apply_one_migration_in_parallel_async();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_apply_range_of_migrations()
    {
        base.Can_apply_range_of_migrations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_apply_second_migration_in_parallel()
    {
        base.Can_apply_second_migration_in_parallel();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_apply_second_migration_in_parallel_async()
    {
        return base.Can_apply_second_migration_in_parallel_async();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_apply_two_migrations_in_transaction()
    {
        base.Can_apply_two_migrations_in_transaction();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_apply_two_migrations_in_transaction_async()
    {
        return base.Can_apply_two_migrations_in_transaction_async();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_idempotent_up_and_down_scripts()
    {
        return base.Can_generate_idempotent_up_and_down_scripts();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_idempotent_up_and_down_scripts_noTransactions()
    {
        return base.Can_generate_idempotent_up_and_down_scripts_noTransactions();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_migration_from_initial_database_to_initial()
    {
        return base.Can_generate_migration_from_initial_database_to_initial();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_no_migration_script()
    {
        return base.Can_generate_no_migration_script();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_one_up_and_down_script()
    {
        return base.Can_generate_one_up_and_down_script();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_script_using_names()
    {
        return base.Can_generate_up_and_down_script_using_names();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_scripts()
    {
        return base.Can_generate_up_and_down_scripts();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_scripts_noTransactions()
    {
        return base.Can_generate_up_and_down_scripts_noTransactions();
    }

    protected override Task ExecuteSqlAsync(string value)
    {
        ((DuckDBTestStore)Fixture.TestStore).ExecuteNonQuery(value);
        return Task.CompletedTask;
    }

    public class MigrationsInfrastructureDuckDBFixture : MigrationsInfrastructureFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
