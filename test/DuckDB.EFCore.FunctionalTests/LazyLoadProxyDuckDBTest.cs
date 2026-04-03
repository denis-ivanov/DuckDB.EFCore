using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class LazyLoadProxyDuckDBTest : LazyLoadProxyRelationalTestBase<LazyLoadProxyDuckDBTest.LoadDuckDBFixture>
{
    public LazyLoadProxyDuckDBTest(LoadDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attached_collections_are_not_marked_as_loaded(EntityState state, bool lazy)
    {
        base.Attached_collections_are_not_marked_as_loaded(state, lazy);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attached_references_to_dependents_are_marked_as_loaded(EntityState state, bool lazy)
    {
        base.Attached_references_to_dependents_are_marked_as_loaded(state, lazy);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attached_references_to_principal_are_marked_as_loaded(EntityState state, bool lazy)
    {
        base.Attached_references_to_principal_are_marked_as_loaded(state, lazy);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection(EntityState state, bool useAttach, bool useDetach)
    {
        base.Lazy_load_collection(state, useAttach, useDetach);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal(EntityState state, bool useAttach, bool useDetach)
    {
        base.Lazy_load_many_to_one_reference_to_principal(state, useAttach, useDetach);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal(EntityState state, bool useAttach, bool useDetach)
    {
        base.Lazy_load_one_to_one_reference_to_principal(state, useAttach, useDetach);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent(EntityState state, bool useAttach, bool useDetach)
    {
        base.Lazy_load_one_to_one_reference_to_dependent(state, useAttach, useDetach);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_with_recursive_property(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_with_recursive_property(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_principal(EntityState state)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_principal(state);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_one_non_virtual_reference_to_owned_type()
    {
        base.Eager_load_one_to_one_non_virtual_reference_to_owned_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Non_virtual_reference_to_dependent_is_not_lazy_loaded()
    {
        base.Non_virtual_reference_to_dependent_is_not_lazy_loaded();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_serialize_proxies_to_JSON()
    {
        base.Can_serialize_proxies_to_JSON();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_use_proxies_from_multiple_threads_when_navigations_already_loaded(bool noTracking)
    {
        base.Can_use_proxies_from_multiple_threads_when_navigations_already_loaded(noTracking);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Detected_dependent_reference_navigation_changes_are_detected_and_marked_loaded()
    {
        base.Detected_dependent_reference_navigation_changes_are_detected_and_marked_loaded();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Detected_principal_reference_navigation_changes_are_detected_and_marked_loaded()
    {
        base.Detected_principal_reference_navigation_changes_are_detected_and_marked_loaded();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_many_non_virtual_collection_of_owned_types()
    {
        base.Eager_load_one_to_many_non_virtual_collection_of_owned_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_many_non_virtual_collection_of_owned_types_with_explicit_lazy_load()
    {
        base.Eager_load_one_to_many_non_virtual_collection_of_owned_types_with_explicit_lazy_load();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_many_virtual_collection_of_owned_types()
    {
        base.Eager_load_one_to_many_virtual_collection_of_owned_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_many_virtual_collection_of_owned_types_with_explicit_lazy_load()
    {
        base.Eager_load_one_to_many_virtual_collection_of_owned_types_with_explicit_lazy_load();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Eager_load_one_to_one_virtual_reference_to_owned_type()
    {
        base.Eager_load_one_to_one_virtual_reference_to_owned_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Entity_equality_with_proxy_parameter(bool async)
    {
        await base.Entity_equality_with_proxy_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_loaded(EntityState state, CascadeTiming cascadeDeleteTiming)
    {
        base.Lazy_load_collection_already_loaded(state, cascadeDeleteTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded(EntityState state)
    {
        base.Lazy_load_collection_already_partially_loaded(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_dependent(EntityState state)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_dependent(state);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Setting_reference_to_owned_type_to_null_is_allowed_on_non_virtual_navigation()
    {
        base.Setting_reference_to_owned_type_to_null_is_allowed_on_non_virtual_navigation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Setting_reference_to_owned_type_to_null_is_allowed_on_virtual_navigation()
    {
        base.Setting_reference_to_owned_type_to_null_is_allowed_on_virtual_navigation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Non_virtual_one_to_one_reference_to_principal_is_not_lazy_loaded()
    {
        base.Non_virtual_one_to_one_reference_to_principal_is_not_lazy_loaded();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Non_virtual_one_to_many_reference_to_principal_is_not_lazy_loaded()
    {
        base.Non_virtual_one_to_many_reference_to_principal_is_not_lazy_loaded();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Non_virtual_collection_is_not_lazy_loaded()
    {
        base.Non_virtual_collection_is_not_lazy_loaded();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_changed_non_found_FK(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_changed_non_found_FK(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_changed_found_FK(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_changed_found_FK(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_not_found(EntityState state)
    {
        base.Lazy_load_collection_not_found(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_not_found(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_not_found(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_not_found(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_not_found(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_not_found(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_not_found(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded_no_tracking(QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_partially_loaded_no_tracking(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_already_loaded(EntityState state, CascadeTiming cascadeDeleteTiming)
    {
        base.Lazy_load_many_to_one_reference_to_principal_already_loaded(state, cascadeDeleteTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_already_loaded(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_already_loaded(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_already_loaded(EntityState state, CascadeTiming cascadeDeleteTiming)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_already_loaded(state, cascadeDeleteTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(EntityState state)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(EntityState state)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_alternate_key(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_alternate_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_alternate_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_alternate_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_alternate_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_alternate_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_alternate_key(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_alternate_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_alternate_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_alternate_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_shadow_fk(EntityState state)
    {
        base.Lazy_load_collection_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_shadow_fk(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_shadow_fk(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_shadow_fk(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_shadow_fk(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_composite_key(EntityState state)
    {
        base.Lazy_load_collection_composite_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_composite_key(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_composite_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_composite_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_composite_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_composite_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_composite_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_composite_key(EntityState state)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_composite_key(state);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_composite_key(EntityState state)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_composite_key(state);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_for_detached_is_no_op()
    {
        base.Lazy_load_collection_for_detached_is_no_op();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_reference_to_principal_for_detached_is_no_op()
    {
        base.Lazy_load_reference_to_principal_for_detached_is_no_op();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_reference_to_dependent_for_detached_is_no_op()
    {
        base.Lazy_load_reference_to_dependent_for_detached_is_no_op();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_for_no_tracking_does_not_throw_if_populated()
    {
        base.Lazy_load_collection_for_no_tracking_does_not_throw_if_populated();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_reference_to_principal_for_no_tracking_does_not_throw_if_populated()
    {
        base.Lazy_load_reference_to_principal_for_no_tracking_does_not_throw_if_populated();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_reference_to_dependent_for_no_tracking_does_not_throw_if_populated()
    {
        base.Lazy_load_reference_to_dependent_for_no_tracking_does_not_throw_if_populated();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Load_collection(EntityState state, bool async)
    {
        return base.Load_collection(state, async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_finds_correct_entity_type_with_already_loaded_owned_types()
    {
        base.Lazy_loading_finds_correct_entity_type_with_already_loaded_owned_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_finds_correct_entity_type_with_multiple_queries()
    {
        base.Lazy_loading_finds_correct_entity_type_with_multiple_queries();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_finds_correct_entity_type_with_opaque_predicate_and_multiple_queries()
    {
        base.Lazy_loading_finds_correct_entity_type_with_opaque_predicate_and_multiple_queries();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_finds_correct_entity_type_with_multiple_queries_using_Count()
    {
        base.Lazy_loading_finds_correct_entity_type_with_multiple_queries_using_Count();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_shares_service_property_on_derived_types()
    {
        base.Lazy_loading_shares_service_property_on_derived_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_handles_shadow_nullable_GUID_FK_in_TPH_model()
    {
        base.Lazy_loading_handles_shadow_nullable_GUID_FK_in_TPH_model();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_finds_correct_entity_type_with_alternate_model()
    {
        base.Lazy_loading_finds_correct_entity_type_with_alternate_model();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Top_level_projection_track_entities_before_passing_to_client_method()
    {
        base.Top_level_projection_track_entities_before_passing_to_client_method();
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