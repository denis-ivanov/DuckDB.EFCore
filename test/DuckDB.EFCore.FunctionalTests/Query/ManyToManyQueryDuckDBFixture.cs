using Microsoft.EntityFrameworkCore.TestModels.ManyToManyModel;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class ManyToManyQueryDuckDBFixture : ManyToManyQueryRelationalFixture
{
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<JoinOneToTwo>().HasKey(e => new { e.OneId, e.TwoId });
        modelBuilder.Entity<JoinOneToThreePayloadFull>().HasKey(e => new { e.OneId, e.ThreeId });
        modelBuilder.Entity<JoinOneSelfPayload>().HasKey(e => new { e.LeftId, e.RightId });
        modelBuilder.Entity<JoinOneToBranch>().HasKey(e => new { e.EntityOneId, e.EntityBranchId });
        modelBuilder.Entity<JoinTwoToThree>().HasKey(e => new { e.TwoId, e.ThreeId });
        modelBuilder.Entity<JoinCompositeKeyToLeaf>().HasKey(e => new { e.CompositeId1, e.CompositeId2, e.CompositeId3, e.LeafId });

        modelBuilder.Entity<UnidirectionalJoinOneToTwo>().HasKey(e => new { e.OneId, e.TwoId });
        modelBuilder.Entity<UnidirectionalJoinOneToThreePayloadFull>().HasKey(e => new { e.OneId, e.ThreeId });
        modelBuilder.Entity<UnidirectionalJoinOneSelfPayload>().HasKey(e => new { e.LeftId, e.RightId });
        modelBuilder.Entity<UnidirectionalJoinOneToBranch>().HasKey(e => new { e.UnidirectionalEntityOneId, e.UnidirectionalEntityBranchId });
        modelBuilder.Entity<UnidirectionalJoinTwoToThree>().HasKey(e => new { e.TwoId, e.ThreeId });
        modelBuilder.Entity<UnidirectionalJoinCompositeKeyToLeaf>().HasKey(e => new { e.CompositeId1, e.CompositeId2, e.CompositeId3, e.LeafId });
    }
}
