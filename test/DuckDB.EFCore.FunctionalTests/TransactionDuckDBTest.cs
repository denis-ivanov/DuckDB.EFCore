using DuckDB.EFCore.Extensions;
using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class TransactionDuckDBTest : TransactionTestBase<TransactionDuckDBTest.TransactionDuckDBFixture>
{
    public TransactionDuckDBTest(TransactionDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_can_be_used_with_AutoTransactionBehavior_Never(bool async)
    {
        await base.SaveChanges_can_be_used_with_AutoTransactionBehavior_Never(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_can_be_used_with_AutoTransactionsEnabled_false(bool async)
    {
        await base.SaveChanges_can_be_used_with_AutoTransactionsEnabled_false(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_can_be_used_with_AutoTransactionBehavior_Always(bool async)
    {
        await base.SaveChanges_can_be_used_with_AutoTransactionBehavior_Always(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_implicitly_starts_transaction_when_needed(bool async)
    {
        await base.SaveChanges_implicitly_starts_transaction_when_needed(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_enlisted_transaction(bool async, AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_enlisted_transaction(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_enlisted_transaction_after_connection_closed(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_enlisted_transaction_after_connection_closed(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_enlisted_transaction_connectionString(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_enlisted_transaction_connectionString(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_ambient_transaction(bool async, AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_ambient_transaction(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_ambient_transaction_with_connectionString(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_ambient_transaction_with_connectionString(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void SaveChanges_throws_for_suppressed_ambient_transactions(bool connectionString)
    {
        base.SaveChanges_throws_for_suppressed_ambient_transactions(connectionString);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void SaveChanges_allows_nested_ambient_transactions()
    {
        base.SaveChanges_allows_nested_ambient_transactions();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void SaveChanges_allows_independent_ambient_transaction_commits()
    {
        base.SaveChanges_allows_independent_ambient_transaction_commits();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void SaveChanges_uses_enlisted_transaction_after_ambient_transaction()
    {
        base.SaveChanges_uses_enlisted_transaction_after_ambient_transaction();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_does_not_close_connection_opened_by_user(bool async)
    {
        await base.SaveChanges_does_not_close_connection_opened_by_user(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_explicit_transaction_without_committing(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_explicit_transaction_without_committing(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_false_uses_explicit_transaction_without_committing_or_accepting_changes(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_false_uses_explicit_transaction_without_committing_or_accepting_changes(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_uses_explicit_transaction_with_failure_behavior(bool async,
        AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.SaveChanges_uses_explicit_transaction_with_failure_behavior(async, autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task RelationalTransaction_can_be_committed(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.RelationalTransaction_can_be_committed(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task RelationalTransaction_can_be_committed_from_context(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.RelationalTransaction_can_be_committed_from_context(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task RelationalTransaction_can_be_rolled_back(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.RelationalTransaction_can_be_rolled_back(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task RelationalTransaction_can_be_rolled_back_from_context(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.RelationalTransaction_can_be_rolled_back_from_context(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_uses_explicit_transaction(AutoTransactionBehavior autoTransactionBehavior)
    {
        base.Query_uses_explicit_transaction(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task QueryAsync_uses_explicit_transaction(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.QueryAsync_uses_explicit_transaction(autoTransactionBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_use_open_connection_with_started_transaction(AutoTransactionBehavior autoTransactionBehavior)
    {
        await base.Can_use_open_connection_with_started_transaction(autoTransactionBehavior);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void UseTransaction_throws_if_mismatched_connection()
    {
        base.UseTransaction_throws_if_mismatched_connection();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task UseTransaction_is_no_op_if_same_DbTransaction_is_used(bool async)
    {
        await base.UseTransaction_is_no_op_if_same_DbTransaction_is_used(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void UseTransaction_will_not_dispose_external_transaction()
    {
        base.UseTransaction_will_not_dispose_external_transaction();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void UseTransaction_throws_if_ambient_transaction_started()
    {
        base.UseTransaction_throws_if_ambient_transaction_started();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void UseTransaction_throws_if_enlisted_in_transaction()
    {
        base.UseTransaction_throws_if_enlisted_in_transaction();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_throws_if_another_transaction_started()
    {
        base.BeginTransaction_throws_if_another_transaction_started();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_throws_if_ambient_transaction_started()
    {
        base.BeginTransaction_throws_if_ambient_transaction_started();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_throws_if_enlisted_in_transaction()
    {
        base.BeginTransaction_throws_if_enlisted_in_transaction();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_can_be_used_after_ambient_transaction_ended()
    {
        base.BeginTransaction_can_be_used_after_ambient_transaction_ended();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_can_be_used_after_enlisted_transaction_ended()
    {
        base.BeginTransaction_can_be_used_after_enlisted_transaction_ended();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_can_be_used_after_another_transaction_if_connection_closed()
    {
        base.BeginTransaction_can_be_used_after_another_transaction_if_connection_closed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void BeginTransaction_can_be_used_after_enlisted_transaction_if_connection_closed()
    {
        base.BeginTransaction_can_be_used_after_enlisted_transaction_if_connection_closed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void EnlistTransaction_throws_if_another_transaction_started()
    {
        base.EnlistTransaction_throws_if_another_transaction_started();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void EnlistTransaction_throws_if_ambient_transaction_started()
    {
        base.EnlistTransaction_throws_if_ambient_transaction_started();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Externally_closed_connections_are_handled_correctly(bool async)
    {
        await base.Externally_closed_connections_are_handled_correctly(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_implicitly_creates_savepoint(bool async)
    {
        await base.SaveChanges_implicitly_creates_savepoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task SaveChanges_can_be_used_with_no_savepoint(bool async)
    {
        await base.SaveChanges_can_be_used_with_no_savepoint(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Savepoint_can_be_rolled_back(bool async)
    {
        await base.Savepoint_can_be_rolled_back(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Savepoint_can_be_released(bool async)
    {
        await base.Savepoint_can_be_released(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Savepoint_name_is_quoted(bool async)
    {
        await base.Savepoint_name_is_quoted(async);
    }

    protected override bool SnapshotSupported
        => false;

    protected override DbContext CreateContextWithConnectionString()
    {
        var options = Fixture.AddOptions(
                new DbContextOptionsBuilder().UseDuckDB(TestStore.ConnectionString)
                    .ConfigureWarnings(w => w.Log(RelationalEventId.AmbientTransactionWarning)))
            .UseInternalServiceProvider(Fixture.ServiceProvider);

        return new DbContext(options.Options);
    }

    public class TransactionDuckDBFixture : TransactionFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => SharedCacheDuckDBTestStoreFactory.Instance;

        public override async Task ReseedAsync()
        {
            using var context = CreateContext();
            context.Set<TransactionCustomer>().RemoveRange(await context.Set<TransactionCustomer>().ToListAsync());
            context.Set<TransactionOrder>().RemoveRange(await context.Set<TransactionOrder>().ToListAsync());
            await context.SaveChangesAsync();

            await SeedAsync(context);
        }

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder)
                .ConfigureWarnings(w => w.Log(RelationalEventId.AmbientTransactionWarning));
    }
}
