using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace Microsoft.EntityFrameworkCore.GraphUpdates;

public class GraphUpdatesDuckDBSnapshotNotificationsTest : GraphUpdatesDuckDBTestBase<GraphUpdatesDuckDBSnapshotNotificationsTest.DuckDBFixture>
{
    public GraphUpdatesDuckDBSnapshotNotificationsTest(DuckDBFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_add_multiple_dependents_when_multiple_possible_principal_sides()
    {
        await base.Can_add_multiple_dependents_when_multiple_possible_principal_sides();
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Optional_many_to_one_dependents_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_many_to_one_dependents_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Optional_one_to_one_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_one_to_one_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Optional_one_to_one_with_alternate_key_are_orphaned_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Optional_one_to_one_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_many_to_one_dependents_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_many_to_one_dependents_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_non_PK_one_to_one_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_non_PK_one_to_one_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_non_PK_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_non_PK_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_one_to_one_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_one_to_one_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Theory(Skip = DuckDBSkipReasons.Tbd)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.OnSaveChanges, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Immediate, CascadeTiming.Never)]
    [InlineData(CascadeTiming.Never, CascadeTiming.OnSaveChanges)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Immediate)]
    [InlineData(CascadeTiming.Never, CascadeTiming.Never)]
    [InlineData(null, null)]
    public override async Task Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming? cascadeDeleteTiming, CascadeTiming? deleteOrphansTiming)
    {
        await base.Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Resetting_a_deleted_reference_fixes_up_again()
    {
        await base.Resetting_a_deleted_reference_fixes_up_again();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class DuckDBFixture : GraphUpdatesDuckDBFixtureBase
    {
        protected override string StoreName
            => "GraphUpdatesSnapshotTest";

        public override bool AutoDetectChanges
            => true;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);

            base.OnModelCreating(modelBuilder, context);
        }
    }
}
