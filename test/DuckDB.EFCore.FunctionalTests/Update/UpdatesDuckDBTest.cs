using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Update;

public abstract class UpdatesDuckDBTest : UpdatesRelationalTestBase<UpdatesDuckDBTest.UpdatesDuckDBFixture>
{
    public UpdatesDuckDBTest(UpdatesDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_use_shared_columns_with_conversion()
    {
        return base.Can_use_shared_columns_with_conversion();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Save_with_shared_foreign_key()
    {
        return base.Save_with_shared_foreign_key();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SaveChanges_throws_for_entities_only_mapped_to_view()
    {
        return base.SaveChanges_throws_for_entities_only_mapped_to_view();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SaveChanges_works_for_entities_also_mapped_to_view()
    {
        return base.SaveChanges_works_for_entities_also_mapped_to_view();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Swap_computed_unique_index_values()
    {
        return base.Swap_computed_unique_index_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Swap_filtered_unique_index_values()
    {
        return base.Swap_filtered_unique_index_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Update_non_indexed_values()
    {
        return base.Update_non_indexed_values();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_add_and_remove_self_refs()
    {
        return base.Can_add_and_remove_self_refs();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_change_enums_with_conversion()
    {
        return base.Can_change_enums_with_conversion();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_change_type_of__dependent_by_replacing_with_new_dependent(bool async)
    {
        return base.Can_change_type_of__dependent_by_replacing_with_new_dependent(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_change_type_of_pk_to_pk_dependent_by_replacing_with_new_dependent(bool async)
    {
        return base.Can_change_type_of_pk_to_pk_dependent_by_replacing_with_new_dependent(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_delete_and_add_for_same_key(bool async)
    {
        return base.Can_delete_and_add_for_same_key(async);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Can_remove_partial()
    {
        return base.Can_remove_partial();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Identifiers_are_generated_correctly()
    {
        throw new NotImplementedException();
    }

    public class UpdatesDuckDBFixture : UpdatesRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;
    }
}
