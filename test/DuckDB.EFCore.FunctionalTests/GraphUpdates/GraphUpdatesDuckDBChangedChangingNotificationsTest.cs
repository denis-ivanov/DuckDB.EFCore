using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.GraphUpdates;

public class GraphUpdatesDuckDBChangedChangingNotificationsTest : GraphUpdatesDuckDBTestBase<GraphUpdatesDuckDBChangedChangingNotificationsTest.DuckDBFixture>
{
    public GraphUpdatesDuckDBChangedChangingNotificationsTest(DuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_add_multiple_dependents_when_multiple_possible_principal_sides()
    {
        await base.Can_add_multiple_dependents_when_multiple_possible_principal_sides();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Clearing_CLR_key_owned_collection(bool async, bool useUpdate, bool addNew)
    {
        await base.Clearing_CLR_key_owned_collection(async, useUpdate, addNew);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Clearing_shadow_key_owned_collection_throws(bool async, bool useUpdate, bool addNew)
    {
        await base.Clearing_shadow_key_owned_collection_throws(async, useUpdate, addNew);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_many_to_one_dependents_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_many_to_one_dependents_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_one_to_one_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_one_to_one_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Optional_one_to_one_with_alternate_key_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_one_to_one_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_non_PK_one_to_one_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_non_PK_one_to_one_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_non_PK_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_non_PK_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_one_to_one_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_one_to_one_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Resetting_a_deleted_reference_fixes_up_again()
    {
        await base.Resetting_a_deleted_reference_fixes_up_again();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Required_many_to_one_dependents_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_many_to_one_dependents_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class DuckDBFixture : GraphUpdatesDuckDBFixtureBase
    {
        protected override string StoreName
            => "GraphUpdatesChangedChangingTest";

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);

            base.OnModelCreating(modelBuilder, context);
        }
    }
}
