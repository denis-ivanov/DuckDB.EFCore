using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore.GraphUpdates;

public class ProxyGraphUpdatesDuckDBTest
{
    public abstract class ProxyGraphUpdatesDuckDBTestBase<TFixture>(TFixture fixture) : ProxyGraphUpdatesTestBase<TFixture>(fixture)
        where TFixture : ProxyGraphUpdatesDuckDBTestBase<TFixture>.ProxyGraphUpdatesDuckDBFixtureBase, new()
    {
        protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
            => facade.UseTransaction(transaction.GetDbTransaction());

        public abstract class ProxyGraphUpdatesDuckDBFixtureBase : ProxyGraphUpdatesFixtureBase
        {
            public TestSqlLoggerFactory TestSqlLoggerFactory
                => (TestSqlLoggerFactory)ListLoggerFactory;

            protected override ITestStoreFactory TestStoreFactory
                => DuckDBTestStoreFactory.Instance;
        }
    }

    public class LazyLoading(LazyLoading.ProxyGraphUpdatesWithLazyLoadingDuckDBFixture fixture)
        : ProxyGraphUpdatesDuckDBTestBase<LazyLoading.ProxyGraphUpdatesWithLazyLoadingDuckDBFixture>(fixture)
    {
        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Can_attach_full_required_non_PK_graph_of_duplicates()
        {
            await base.Can_attach_full_required_non_PK_graph_of_duplicates();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Save_changed_optional_one_to_one_with_alternate_key_in_store()
        {
            await base.Save_changed_optional_one_to_one_with_alternate_key_in_store();
        }

        protected override bool DoesLazyLoading
            => true;

        protected override bool DoesChangeTracking
            => false;

        public class ProxyGraphUpdatesWithLazyLoadingDuckDBFixture : ProxyGraphUpdatesDuckDBFixtureBase
        {
            protected override string StoreName
                => "ProxyGraphLazyLoadingUpdatesTest";

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
                => base.AddOptions(builder.UseLazyLoadingProxies());

            protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
                => base.AddServices(serviceCollection.AddEntityFrameworkProxies());
        }
    }

    public class ChangeTracking(ChangeTracking.ProxyGraphUpdatesWithChangeTrackingDuckDBFixture fixture)
        : ProxyGraphUpdatesDuckDBTestBase<ChangeTracking.ProxyGraphUpdatesWithChangeTrackingDuckDBFixture>(fixture)
    {
        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Can_attach_full_required_non_PK_graph_of_duplicates()
        {
            await base.Can_attach_full_required_non_PK_graph_of_duplicates();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Save_changed_optional_one_to_one_with_alternate_key_in_store()
        {
            await base.Save_changed_optional_one_to_one_with_alternate_key_in_store();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Save_two_entity_cycle_with_lazy_loading()
        {
            await base.Save_two_entity_cycle_with_lazy_loading();
        }

        protected override bool DoesLazyLoading
            => false;

        protected override bool DoesChangeTracking
            => true;

        public class ProxyGraphUpdatesWithChangeTrackingDuckDBFixture : ProxyGraphUpdatesDuckDBFixtureBase
        {
            protected override string StoreName
                => "ProxyGraphChangeTrackingUpdatesTest";

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
                => base.AddOptions(builder.UseChangeTrackingProxies());

            protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
                => base.AddServices(serviceCollection.AddEntityFrameworkProxies());
        }
    }

    public class ChangeTrackingAndLazyLoading(
        ChangeTrackingAndLazyLoading.ProxyGraphUpdatesWithChangeTrackingAndLazyLoadingDuckDBFixture fixture)
        : ProxyGraphUpdatesDuckDBTestBase<
            ChangeTrackingAndLazyLoading.ProxyGraphUpdatesWithChangeTrackingAndLazyLoadingDuckDBFixture>(fixture)
    {
        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Can_attach_full_required_non_PK_graph_of_duplicates()
        {
            await base.Can_attach_full_required_non_PK_graph_of_duplicates();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Optional_many_to_one_dependents_with_alternate_key_are_orphaned_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_many_to_one_dependents_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_non_PK_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_deleted_in_store(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(CascadeTiming cascadeDeleteTiming, CascadeTiming deleteOrphansTiming)
        {
            await base.Required_one_to_one_with_alternate_key_are_cascade_detached_when_Added(cascadeDeleteTiming, deleteOrphansTiming);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override async Task Save_changed_optional_one_to_one_with_alternate_key_in_store()
        {
            await base.Save_changed_optional_one_to_one_with_alternate_key_in_store();
        }

        protected override bool DoesLazyLoading
            => true;

        protected override bool DoesChangeTracking
            => true;

        public class ProxyGraphUpdatesWithChangeTrackingAndLazyLoadingDuckDBFixture : ProxyGraphUpdatesDuckDBFixtureBase
        {
            protected override string StoreName
                => "ProxyGraphChangeTrackingAndLazyLoadingUpdatesTest";

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
                => base.AddOptions(builder.UseChangeTrackingProxies().UseLazyLoadingProxies());

            protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
                => base.AddServices(serviceCollection.AddEntityFrameworkProxies());
        }
    }
}
