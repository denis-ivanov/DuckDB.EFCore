using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

// TODO
internal abstract class MonsterFixupChangedOnlyDuckDBTest : MonsterFixupTestBase<MonsterFixupChangedOnlyDuckDBTest.MonsterFixupChangedOnlyDuckDBFixture>
{
    protected MonsterFixupChangedOnlyDuckDBTest(MonsterFixupChangedOnlyDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_FKs()
    {
        await base.Can_build_monster_model_and_seed_data_using_FKs();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_all_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_all_navigations();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual async Task Can_build_monster_model_and_seed_data_using_dependent_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_dependent_navigations();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual async Task Can_build_monster_model_and_seed_data_using_principal_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_principal_navigations();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual async Task Can_build_monster_model_and_seed_data_using_navigations_with_deferred_add()
    {
        await base.Can_build_monster_model_and_seed_data_using_navigations_with_deferred_add();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void One_to_many_fixup_happens_when_FKs_change_test()
    {
        base.One_to_many_fixup_happens_when_FKs_change_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void One_to_many_fixup_happens_when_reference_changes()
    {
        base.One_to_many_fixup_happens_when_reference_changes();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void One_to_many_fixup_happens_when_collection_changes()
    {
        base.One_to_many_fixup_happens_when_collection_changes();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void One_to_one_fixup_happens_when_FKs_change_test()
    {
        base.One_to_one_fixup_happens_when_FKs_change_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void One_to_one_fixup_happens_when_reference_change_test()
    {
        base.One_to_one_fixup_happens_when_reference_change_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void Composite_fixup_happens_when_FKs_change_test()
    {
        base.Composite_fixup_happens_when_FKs_change_test();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public virtual void Fixup_with_binary_keys_happens_when_FKs_or_navigations_change_test()
    {
        base.Fixup_with_binary_keys_happens_when_FKs_or_navigations_change_test();
    }

    public class MonsterFixupChangedOnlyDuckDBFixture : MonsterFixupChangedOnlyFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override void OnModelCreating<TMessage, TProduct, TProductPhoto, TProductReview, TComputerDetail, TDimensions>(
            ModelBuilder builder)
        {
            base.OnModelCreating<TMessage, TProduct, TProductPhoto, TProductReview, TComputerDetail, TDimensions>(builder);

            builder.Entity<TMessage>().HasKey(e => e.MessageId);
            builder.Entity<TProductPhoto>().HasKey(e => e.PhotoId);
            builder.Entity<TProductReview>().HasKey(e => e.ReviewId);
        }
    }
}