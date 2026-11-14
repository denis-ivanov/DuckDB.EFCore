using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public class MonsterFixupChangedOnlyDuckDBTest : MonsterFixupTestBase<MonsterFixupChangedOnlyDuckDBTest.MonsterFixupChangedOnlyDuckDBFixture>
{
    public MonsterFixupChangedOnlyDuckDBTest(MonsterFixupChangedOnlyDuckDBFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_FKs()
    {
        await base.Can_build_monster_model_and_seed_data_using_FKs();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_all_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_all_navigations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_dependent_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_dependent_navigations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_navigations_with_deferred_add()
    {
        await base.Can_build_monster_model_and_seed_data_using_navigations_with_deferred_add();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_build_monster_model_and_seed_data_using_principal_navigations()
    {
        await base.Can_build_monster_model_and_seed_data_using_principal_navigations();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Composite_fixup_happens_when_FKs_change_test()
    {
        await base.Composite_fixup_happens_when_FKs_change_test();
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
