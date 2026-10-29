using Microsoft.EntityFrameworkCore.TestModels.ManyToManyModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore;

public class ManyToManyTrackingDuckDBTest : ManyToManyTrackingRelationalTestBase<ManyToManyTrackingDuckDBTest.ManyToManyTrackingDuckDBFixture>
{
    public ManyToManyTrackingDuckDBTest(ManyToManyTrackingDuckDBFixture fixture, ITestOutputHelper testOutputHelper) :
        base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many()
    {
        await base.Can_delete_with_many_to_many();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_composite_additional_pk_with_navs()
    {
        await base.Can_delete_with_many_to_many_composite_additional_pk_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_composite_additional_pk_with_navs_unidirectional()
    {
        await base.Can_delete_with_many_to_many_composite_additional_pk_with_navs_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_composite_shared_with_navs()
    {
        await base.Can_delete_with_many_to_many_composite_shared_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_composite_with_navs()
    {
        await base.Can_delete_with_many_to_many_composite_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_composite_with_navs_unidirectional()
    {
        await base.Can_delete_with_many_to_many_composite_with_navs_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_delete_with_many_to_many_with_navs()
    {
        await base.Can_delete_with_many_to_many_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_update_delete_proxyable_shared_type_entity_type()
    {
        await base.Can_insert_update_delete_proxyable_shared_type_entity_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_update_delete_proxyable_shared_type_entity_type_unidirectional()
    {
        await base.Can_insert_update_delete_proxyable_shared_type_entity_type_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_insert_update_delete_shared_type_entity_type()
    {
        await base.Can_insert_update_delete_shared_type_entity_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many()
    {
        await base.Can_update_many_to_many();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_composite_additional_pk_with_navs()
    {
        await base.Can_update_many_to_many_composite_additional_pk_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_composite_additional_pk_with_navs_unidirectional()
    {
        await base.Can_update_many_to_many_composite_additional_pk_with_navs_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_composite_shared_with_navs()
    {
        await base.Can_update_many_to_many_composite_shared_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_composite_with_navs()
    {
        await base.Can_update_many_to_many_composite_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_composite_with_navs_unidirectional()
    {
        await base.Can_update_many_to_many_composite_with_navs_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_self()
    {
        await base.Can_update_many_to_many_self();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_self_unidirectional()
    {
        await base.Can_update_many_to_many_self_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_self_with_payload()
    {
        await base.Can_update_many_to_many_self_with_payload();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_self_with_payload_unidirectional()
    {
        await base.Can_update_many_to_many_self_with_payload_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_shared()
    {
        await base.Can_update_many_to_many_shared();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_shared_unidirectional()
    {
        await base.Can_update_many_to_many_shared_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_shared_with_payload()
    {
        await base.Can_update_many_to_many_shared_with_payload();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_shared_with_payload_unidirectional()
    {
        await base.Can_update_many_to_many_shared_with_payload_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_with_inheritance()
    {
        await base.Can_update_many_to_many_with_inheritance();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_with_inheritance_unidirectional()
    {
        await base.Can_update_many_to_many_with_inheritance_unidirectional();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_with_navs()
    {
        await base.Can_update_many_to_many_with_navs();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Can_update_many_to_many_with_payload()
    {
        await base.Can_update_many_to_many_with_payload();
    }

    public class ManyToManyTrackingDuckDBFixture : ManyToManyTrackingRelationalFixture, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder
                .Entity<JoinOneSelfPayload>()
                .Property(e => e.Payload)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder
                .SharedTypeEntity<Dictionary<string, object>>("JoinOneToThreePayloadFullShared")
                .IndexerProperty<string>("Payload")
                .HasDefaultValue("Generated");

            modelBuilder
                .Entity<JoinOneToThreePayloadFull>()
                .Property(e => e.Payload)
                .HasDefaultValue("Generated");

            modelBuilder
                .Entity<UnidirectionalJoinOneSelfPayload>()
                .Property(e => e.Payload)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder
                .SharedTypeEntity<Dictionary<string, object>>("UnidirectionalJoinOneToThreePayloadFullShared")
                .IndexerProperty<string>("Payload")
                .HasDefaultValue("Generated");

            modelBuilder
                .Entity<UnidirectionalJoinOneToThreePayloadFull>()
                .Property(e => e.Payload)
                .HasDefaultValue("Generated");
        }
    }
}
