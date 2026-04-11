using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class WithConstructorsDuckDBTest : WithConstructorsTestBase<WithConstructorsDuckDBTest.WithConstructorsDuckDBFixture>
{
    public WithConstructorsDuckDBTest(WithConstructorsDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_and_update_using_constructors_with_property_parameters()
    {
        await base.Query_and_update_using_constructors_with_property_parameters();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_keyless_type()
    {
        base.Query_with_keyless_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_context_injected()
    {
        base.Query_with_context_injected();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_context_injected_into_property()
    {
        base.Query_with_context_injected_into_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_context_injected_into_constructor_with_property()
    {
        base.Query_with_context_injected_into_constructor_with_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_context()
    {
        base.Attaching_entity_sets_context();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_EntityType_injected()
    {
        base.Query_with_EntityType_injected();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_EntityType_injected_into_property()
    {
        base.Query_with_EntityType_injected_into_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_EntityType_injected_into_constructor_with_property()
    {
        base.Query_with_EntityType_injected_into_constructor_with_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_EntityType()
    {
        base.Attaching_entity_sets_EntityType();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_StateManager_injected()
    {
        base.Query_with_StateManager_injected();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_StateManager_injected_into_property()
    {
        base.Query_with_StateManager_injected_into_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_StateManager_injected_into_constructor_with_property()
    {
        base.Query_with_StateManager_injected_into_constructor_with_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_StateManager()
    {
        base.Attaching_entity_sets_StateManager();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_for_reference()
    {
        base.Query_with_loader_injected_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_for_collections()
    {
        base.Query_with_loader_injected_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_injected_for_reference_async()
    {
        await base.Query_with_loader_injected_for_reference_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_injected_for_collections_async()
    {
        await base.Query_with_loader_injected_for_collections_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_POCO_loader_injected_for_reference()
    {
        base.Query_with_POCO_loader_injected_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_POCO_loader_injected_for_collections()
    {
        base.Query_with_POCO_loader_injected_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_delegate_injected_for_reference_async()
    {
        await base.Query_with_loader_delegate_injected_for_reference_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_delegate_injected_for_collections_async()
    {
        await base.Query_with_loader_delegate_injected_for_collections_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_property_for_reference()
    {
        base.Query_with_loader_injected_into_property_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_property_for_collections()
    {
        base.Query_with_loader_injected_into_property_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_lazy_loader()
    {
        base.Attaching_entity_sets_lazy_loader();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Detaching_entity_resets_lazy_loader_so_it_can_be_reattached()
    {
        base.Detaching_entity_resets_lazy_loader_so_it_can_be_reattached();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_field_for_reference()
    {
        base.Query_with_loader_injected_into_field_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_field_for_collections()
    {
        base.Query_with_loader_injected_into_field_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_lazy_loader_field()
    {
        base.Attaching_entity_sets_lazy_loader_field();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Detaching_entity_resets_lazy_loader_field_so_it_can_be_reattached()
    {
        base.Detaching_entity_resets_lazy_loader_field_so_it_can_be_reattached();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attaching_entity_sets_lazy_loader_delegate()
    {
        base.Attaching_entity_sets_lazy_loader_delegate();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Detaching_entity_resets_lazy_loader_delegate_so_it_can_be_reattached()
    {
        base.Detaching_entity_resets_lazy_loader_delegate_so_it_can_be_reattached();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_delegate_injected_into_property_for_reference()
    {
        base.Query_with_loader_delegate_injected_into_property_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_delgate_injected_into_property_for_collections()
    {
        base.Query_with_loader_delgate_injected_into_property_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_delegate_injected_into_property_for_reference_async()
    {
        await base.Query_with_loader_delegate_injected_into_property_for_reference_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Query_with_loader_delegate_injected_into_property_for_collections_async()
    {
        await base.Query_with_loader_delegate_injected_into_property_for_collections_async();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_property_via_constructor_for_reference()
    {
        base.Query_with_loader_injected_into_property_via_constructor_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_injected_into_property_via_constructor_for_collections()
    {
        base.Query_with_loader_injected_into_property_via_constructor_for_collections();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_delegate_injected_into_property_via_constructor_for_reference()
    {
        base.Query_with_loader_delegate_injected_into_property_via_constructor_for_reference();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Query_with_loader_delegate_injected_into_property_via_constructor_for_collections()
    {
        base.Query_with_loader_delegate_injected_into_property_via_constructor_for_collections();
    }

    public override async Task Add_immutable_record()
    {
        await base.Add_immutable_record();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    public class WithConstructorsDuckDBFixture : WithConstructorsFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<BlogQuery>().HasNoKey().ToSqlQuery("SELECT * FROM Blog");
        }
    }
}