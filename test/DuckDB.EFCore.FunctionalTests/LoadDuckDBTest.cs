using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class LoadDuckDBTest : LoadTestBase<LoadDuckDBTest.LoadDuckDBFixture>
{
    public LoadDuckDBTest(LoadDuckDBFixture fixture) : base(fixture)
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

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_change_IsLoaded_flag_for_collection()
    {
        base.Can_change_IsLoaded_flag_for_collection();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Can_change_IsLoaded_flag_for_reference_only_if_null()
    {
        base.Can_change_IsLoaded_flag_for_reference_only_if_null();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Fixup_one_to_one_reference_after_FK_change_without_DetectChanges()
    {
        base.Fixup_one_to_one_reference_after_FK_change_without_DetectChanges();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Fixup_reference_after_FK_change_without_DetectChanges()
    {
        base.Fixup_reference_after_FK_change_without_DetectChanges();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_collection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_collection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_collection_already_loaded(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_collection_already_loaded(state, deleteOrphansTiming, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_loaded_delegate_loader_constructor_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_loaded_delegate_loader_constructor_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_loaded_delegate_loader_property_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_loaded_delegate_loader_property_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_loaded_delegate_loader_with_state_property_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_loaded_delegate_loader_with_state_property_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_collection_already_loaded_full_loader_constructor_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_collection_already_loaded_full_loader_constructor_injection(state, deleteOrphansTiming, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_collection_already_partially_loaded(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_collection_already_partially_loaded(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_partially_loaded_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_partially_loaded_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_partially_loaded_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_already_partially_loaded_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_already_partially_loaded_full_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_composite_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_collection_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_collection_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_collection_not_found(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_collection_not_found(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_not_found_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_not_found_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_not_found_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_not_found_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_not_found_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_not_found_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_collection_not_found_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_collection_not_found_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_collection_shadow_fk(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_collection_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_many_to_one_reference_to_principal(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_many_to_one_reference_to_principal(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_many_to_one_reference_to_principal_already_loaded(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_many_to_one_reference_to_principal_already_loaded(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_already_loaded_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_many_to_one_reference_to_principal_already_loaded_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_many_to_one_reference_to_principal_already_loaded_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_alternate_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_alternate_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_composite_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_many_to_one_reference_to_principal_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_many_to_one_reference_to_principal_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_many_to_one_reference_to_principal_not_found(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_many_to_one_reference_to_principal_not_found(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_not_found_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_many_to_one_reference_to_principal_not_found_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_many_to_one_reference_to_principal_not_found_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_many_to_one_reference_to_principal_null_FK(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_many_to_one_reference_to_principal_null_FK(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_alternate_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_alternate_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_composite_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_many_to_one_reference_to_principal_null_FK_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_many_to_one_reference_to_principal_null_FK_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_null_FK_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_many_to_one_reference_to_principal_shadow_fk(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_many_to_one_reference_to_principal_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_dependent(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_dependent(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_principal(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_principal(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_dependent(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_dependent(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_one_to_one_reference_to_dependent_already_loaded(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_one_to_one_reference_to_dependent_already_loaded(state, deleteOrphansTiming, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_constructor_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_constructor_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_property_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_property_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_with_state_property_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_already_loaded_delegate_loader_with_state_property_injection(state, deleteOrphansTiming, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_dependent_already_loaded_full_loader_constructor_injection(EntityState state, CascadeTiming deleteOrphansTiming, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_dependent_already_loaded_full_loader_constructor_injection(state, deleteOrphansTiming, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_alternate_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_alternate_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_composite_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_one_to_one_reference_to_dependent_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_one_to_one_reference_to_dependent_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_one_to_one_reference_to_dependent_not_found(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_one_to_one_reference_to_dependent_not_found(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_with_state_property_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_not_found_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_one_to_one_reference_to_dependent_not_found_full_loader_constructor_injection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_one_to_one_reference_to_dependent_not_found_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_dependent_shadow_fk(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_dependent_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Lazy_load_one_to_one_reference_to_principal(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        return base.Lazy_load_one_to_one_reference_to_principal(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_null_FK(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_null_FK(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_not_found(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_not_found(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_already_loaded(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_already_loaded(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_alternate_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_alternate_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_alternate_key(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_alternate_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_shadow_fk(EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_shadow_fk(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_composite_key(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_composite_key(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_composite_key(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_full_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_null_FK_full_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_null_FK_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_not_found_full_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_not_found_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_load_one_to_one_reference_to_principal_already_loaded_full_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Lazy_load_one_to_one_reference_to_principal_already_loaded_full_loader_constructor_injection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_delegate_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_constructor_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_constructor_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_delegate_loader_property_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_property_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_property_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_property_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_delegate_loader_with_state_property_injection(EntityState state,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_with_state_property_injection(
        EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_null_FK_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_with_state_property_injection(
        EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_not_found_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_with_state_property_injection(
        EntityState state, QueryTrackingBehavior queryTrackingBehavior)
    {
        base.Lazy_load_one_to_one_reference_to_principal_already_loaded_delegate_loader_with_state_property_injection(state, queryTrackingBehavior);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Lazy_loading_uses_field_access_when_abstract_base_class_navigation()
    {
        base.Lazy_loading_uses_field_access_when_abstract_base_class_navigation();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection(EntityState state, QueryTrackingBehavior queryTrackingBehavior, bool async)
    {
        await base.Load_collection(state, queryTrackingBehavior, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_when_NoTracking_behavior(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_when_NoTracking_behavior(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_principal(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_principal(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_dependent(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_dependent(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query(EntityState state, bool async)
    {
        await base.Load_collection_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_principal_using_Query(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_principal_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_dependent_using_Query(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_dependent_using_Query(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_null_FK(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_null_FK(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_null_FK(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_null_FK(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_null_FK(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_null_FK(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_null_FK(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_null_FK(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_not_found(EntityState state, bool async)
    {
        await base.Load_collection_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_not_found(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_not_found(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_not_found(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_not_found(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_not_found(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_not_found(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_not_found(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_not_found(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_already_loaded(EntityState state, bool async, CascadeTiming deleteOrphansTiming)
    {
        await base.Load_collection_already_loaded(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_already_loaded(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_already_loaded(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_one_to_one_reference_to_principal_already_loaded(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_already_loaded(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_one_to_one_reference_to_dependent_already_loaded(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_principal_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_dependent_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_already_loaded(EntityState state, bool async, CascadeTiming deleteOrphansTiming)
    {
        await base.Load_collection_using_Query_already_loaded(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_already_loaded(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_already_loaded(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_already_loaded(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_already_loaded(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_principal_using_Query_already_loaded(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_principal_using_Query_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_PK_to_PK_reference_to_dependent_using_Query_already_loaded(EntityState state, bool async)
    {
        await base.Load_one_to_one_PK_to_PK_reference_to_dependent_using_Query_already_loaded(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_untyped(EntityState state, bool async)
    {
        await base.Load_collection_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_untyped(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_collection_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_not_found_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_not_found_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_already_loaded_untyped(EntityState state, bool async, CascadeTiming deleteOrphansTiming)
    {
        await base.Load_collection_already_loaded_untyped(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_already_loaded_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_already_loaded_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_already_loaded_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_already_loaded_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_already_loaded_untyped(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_one_to_one_reference_to_dependent_already_loaded_untyped(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_already_loaded_untyped(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_collection_using_Query_already_loaded_untyped(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_already_loaded_untyped(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_already_loaded_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_already_loaded_untyped(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_already_loaded_untyped(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_already_loaded_untyped(EntityState state, bool async,
        CascadeTiming deleteOrphansTiming)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_already_loaded_untyped(state, async, deleteOrphansTiming);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_alternate_key(EntityState state, bool async)
    {
        await base.Load_collection_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_alternate_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_alternate_key(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_alternate_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_null_FK_alternate_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_null_FK_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_null_FK_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_null_FK_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_null_FK_alternate_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_null_FK_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_null_FK_alternate_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_null_FK_alternate_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_shadow_fk(EntityState state, bool async)
    {
        await base.Load_collection_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_shadow_fk(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_shadow_fk(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_shadow_fk(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_null_FK_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_null_FK_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_null_FK_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_null_FK_shadow_fk(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_null_FK_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_null_FK_shadow_fk(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_null_FK_shadow_fk(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_composite_key(EntityState state, bool async)
    {
        await base.Load_collection_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_composite_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_collection_using_Query_composite_key(EntityState state, bool async)
    {
        await base.Load_collection_using_Query_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_composite_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_dependent_using_Query_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_dependent_using_Query_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_null_FK_composite_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_null_FK_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_null_FK_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_null_FK_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_many_to_one_reference_to_principal_using_Query_null_FK_composite_key(EntityState state, bool async)
    {
        await base.Load_many_to_one_reference_to_principal_using_Query_null_FK_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Load_one_to_one_reference_to_principal_using_Query_null_FK_composite_key(EntityState state, bool async)
    {
        await base.Load_one_to_one_reference_to_principal_using_Query_null_FK_composite_key(state, async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override void Setting_navigation_to_null_is_detected_by_local_DetectChanges()
    {
        base.Setting_navigation_to_null_is_detected_by_local_DetectChanges();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Lazy_loading_is_thread_safe(bool noTracking, bool async)
    {
        await base.Lazy_loading_is_thread_safe(noTracking, async);
    }

    public class LoadDuckDBFixture : LoadFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}