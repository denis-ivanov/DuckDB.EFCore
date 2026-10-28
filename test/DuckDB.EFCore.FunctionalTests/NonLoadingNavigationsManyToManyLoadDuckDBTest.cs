using Microsoft.EntityFrameworkCore.TestModels.ManyToManyModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore;

public class NonLoadingNavigationsManyToManyLoadDuckDBTest : ManyToManyLoadTestBase<NonLoadingNavigationsManyToManyLoadDuckDBTest.NonLoadingNavigationsManyToManyLoadDuckDBFixture>
{
    public NonLoadingNavigationsManyToManyLoadDuckDBTest(NonLoadingNavigationsManyToManyLoadDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public class NonLoadingNavigationsManyToManyLoadDuckDBFixture : ManyToManyLoadFixtureBase, ITestSqlLoggerFactory
    {
        protected override string StoreName
            => "NonLoadingNavigationsManyToMany";

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder).UseLazyLoadingProxies();

        protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
            => base.AddServices(serviceCollection.AddEntityFrameworkProxies());

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<JoinOneToTwo>().HasKey(e => new
            {
                e.OneId,
                e.TwoId
            });

            modelBuilder.Entity<JoinOneToThreePayloadFull>().HasKey(e => new
            {
                e.OneId,
                e.ThreeId
            });

            modelBuilder.Entity<JoinOneSelfPayload>().HasKey(e => new
            {
                e.LeftId,
                e.RightId
            });

            modelBuilder.Entity<JoinOneToBranch>().HasKey(e => new
            {
                e.EntityOneId,
                e.EntityBranchId
            });

            modelBuilder.Entity<JoinTwoToThree>().HasKey(e => new
            {
                e.TwoId,
                e.ThreeId
            });

            modelBuilder.Entity<JoinThreeToCompositeKeyFull>().HasKey(e => e.Id);

            modelBuilder.Entity<JoinCompositeKeyToLeaf>().HasKey(e => new
            {
                e.CompositeId1,
                e.CompositeId2,
                e.CompositeId3,
                e.LeafId
            });

            modelBuilder.Entity<JoinOneToTwoExtra>().HasKey(e => e.Id);

            modelBuilder.Entity<UnidirectionalJoinCompositeKeyToLeaf>().HasKey(e => new
            {
                e.CompositeId1,
                e.CompositeId2,
                e.CompositeId3,
                e.LeafId
            });

            modelBuilder.Entity<UnidirectionalJoinOneToTwo>().HasKey(e => new
            {
                e.OneId,
                e.TwoId
            });

            modelBuilder.Entity<UnidirectionalJoinOneToThreePayloadFull>().HasKey(e => new
            {
                e.OneId,
                e.ThreeId
            });

            modelBuilder.Entity<UnidirectionalJoinOneSelfPayload>().HasKey(e => new
            {
                e.LeftId,
                e.RightId
            });

            modelBuilder.Entity<UnidirectionalJoinOneToBranch>().HasKey(e => new
            {
                e.UnidirectionalEntityOneId,
                e.UnidirectionalEntityBranchId
            });

            modelBuilder.Entity<UnidirectionalJoinTwoToThree>().HasKey(e => new
            {
                e.TwoId,
                e.ThreeId
            });

            modelBuilder.Entity<UnidirectionalJoinThreeToCompositeKeyFull>().HasKey(e => e.Id);

            modelBuilder.Entity<UnidirectionalJoinOneToTwoExtra>().HasKey(e => e.Id);

            modelBuilder.Entity<EntityOne>(b =>
            {
                b.Navigation(e => e.Reference).EnableLazyLoading(false);
                b.Navigation(e => e.Collection).EnableLazyLoading(false);
                b.Navigation(e => e.TwoSkip).EnableLazyLoading(false);
                b.Navigation(e => e.ThreeSkipPayloadFull).EnableLazyLoading(false);
                b.Navigation(e => e.TwoSkipShared).EnableLazyLoading(false);
                b.Navigation(e => e.ThreeSkipPayloadFullShared).EnableLazyLoading(false);
                b.Navigation(e => e.JoinThreePayloadFullShared).EnableLazyLoading(false);
                b.Navigation(e => e.SelfSkipPayloadLeft).EnableLazyLoading(false);
                b.Navigation(e => e.JoinSelfPayloadLeft).EnableLazyLoading(false);
                b.Navigation(e => e.SelfSkipPayloadRight).EnableLazyLoading(false);
                b.Navigation(e => e.JoinSelfPayloadRight).EnableLazyLoading(false);
                b.Navigation(e => e.BranchSkip).EnableLazyLoading(false);
            });

            modelBuilder.Entity<EntityCompositeKey>(b =>
            {
                b.Navigation(e => e.TwoSkipShared).EnableLazyLoading(false);
                b.Navigation(e => e.ThreeSkipFull).EnableLazyLoading(false);
                b.Navigation(e => e.JoinThreeFull).EnableLazyLoading(false);
                b.Navigation(e => e.RootSkipShared).EnableLazyLoading(false);
                b.Navigation(e => e.LeafSkipFull).EnableLazyLoading(false);
                b.Navigation(e => e.JoinLeafFull).EnableLazyLoading(false);
            });
        }
    }
}
