using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore;

public abstract class FieldMappingDuckDBTest
{
    public abstract class FieldMappingDuckDBTestBase<TFixture>(TFixture fixture) : FieldMappingTestBase<TFixture>(fixture)
        where TFixture : FieldMappingDuckDBTestBase<TFixture>.FieldMappingDuckDBFixtureBase, new()
    {
        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Can_define_a_backing_field_for_a_navigation_and_query_and_update_it()
        {
            base.Can_define_a_backing_field_for_a_navigation_and_query_and_update_it();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Field_mapping_with_conversion_does_not_throw()
        {
            base.Field_mapping_with_conversion_does_not_throw();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_auto_props(bool tracking)
        {
            base.Include_collection_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_fields_only(bool tracking)
        {
            base.Include_collection_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_fields_only_for_navs_too(bool tracking)
        {
            base.Include_collection_fields_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_full_props(bool tracking)
        {
            base.Include_collection_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_hiding_props(bool tracking)
        {
            base.Include_collection_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_full_props_with_named_fields(bool tracking)
        {
            base.Include_collection_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Include_collection_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_read_only_props(bool tracking)
        {
            base.Include_collection_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_read_only_props_with_named_fields(bool tracking)
        {
            base.Include_collection_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_write_only_props(bool tracking)
        {
            base.Include_collection_write_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_collection_write_only_props_with_named_fields(bool tracking)
        {
            base.Include_collection_write_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_auto_props(bool tracking)
        {
            base.Include_reference_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_fields_only(bool tracking)
        {
            base.Include_reference_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_fields_only_only_for_navs_too(bool tracking)
        {
            base.Include_reference_fields_only_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_full_props(bool tracking)
        {
            base.Include_reference_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_full_props_with_named_fields(bool tracking)
        {
            base.Include_reference_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_hiding_props(bool tracking)
        {
            base.Include_reference_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Include_reference_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_read_only_props(bool tracking)
        {
            base.Include_reference_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_read_only_props_with_named_fields(bool tracking)
        {
            base.Include_reference_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_write_only_props_with_named_fields(bool tracking)
        {
            base.Include_reference_write_only_props_with_named_fields(tracking);
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_auto_props()
        {
            base.Load_collection_auto_props();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Include_reference_write_only_props(bool tracking)
        {
            base.Include_reference_write_only_props(tracking);
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_fields_only()
        {
            base.Load_collection_fields_only();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_fields_only_only_for_navs_too()
        {
            base.Load_collection_fields_only_only_for_navs_too();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_full_props()
        {
            base.Load_collection_full_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_full_props_with_named_fields()
        {
            base.Load_collection_full_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_hiding_props()
        {
            base.Load_collection_hiding_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_props_with_IReadOnlyCollection()
        {
            base.Load_collection_props_with_IReadOnlyCollection();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_read_only_props()
        {
            base.Load_collection_read_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_read_only_props_with_named_fields()
        {
            base.Load_collection_read_only_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_write_only_props()
        {
            base.Load_collection_write_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_collection_write_only_props_with_named_fields()
        {
            base.Load_collection_write_only_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_auto_props()
        {
            base.Load_reference_auto_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_fields_only()
        {
            base.Load_reference_fields_only();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_fields_only_only_for_navs_too()
        {
            base.Load_reference_fields_only_only_for_navs_too();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_full_props()
        {
            base.Load_reference_full_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_full_props_with_named_fields()
        {
            base.Load_reference_full_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_hiding_props()
        {
            base.Load_reference_hiding_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_props_with_IReadOnlyCollection()
        {
            base.Load_reference_props_with_IReadOnlyCollection();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_read_only_props()
        {
            base.Load_reference_read_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_read_only_props_with_named_fields()
        {
            base.Load_reference_read_only_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_write_only_props()
        {
            base.Load_reference_write_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override void Load_reference_write_only_props_with_named_fields()
        {
            base.Load_reference_write_only_props_with_named_fields();
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_auto_props(bool tracking)
        {
            base.Projection_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_fields_only(bool tracking)
        {
            base.Projection_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_fields_only_only_for_navs_too(bool tracking)
        {
            base.Projection_fields_only_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_full_props(bool tracking)
        {
            base.Projection_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_full_props_with_named_fields(bool tracking)
        {
            base.Projection_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_hiding_props(bool tracking)
        {
            base.Projection_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Projection_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_read_only_props(bool tracking)
        {
            base.Projection_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_read_only_props_with_named_fields(bool tracking)
        {
            base.Projection_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_write_only_props(bool tracking)
        {
            base.Projection_write_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Projection_write_only_props_with_named_fields(bool tracking)
        {
            base.Projection_write_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_auto_props(bool tracking)
        {
            base.Query_with_conditional_constant_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_fields_only(bool tracking)
        {
            base.Query_with_conditional_constant_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_fields_only_only_for_navs_too(bool tracking)
        {
            base.Query_with_conditional_constant_fields_only_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_full_props(bool tracking)
        {
            base.Query_with_conditional_constant_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_full_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_constant_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Query_with_conditional_constant_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_hiding_props(bool tracking)
        {
            base.Query_with_conditional_constant_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_read_only_props(bool tracking)
        {
            base.Query_with_conditional_constant_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_read_only_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_constant_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_write_only_props(bool tracking)
        {
            base.Query_with_conditional_constant_write_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_constant_write_only_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_constant_write_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_auto_props(bool tracking)
        {
            base.Query_with_conditional_param_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_fields_only(bool tracking)
        {
            base.Query_with_conditional_param_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_fields_only_only_for_navs_too(bool tracking)
        {
            base.Query_with_conditional_param_fields_only_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_full_props(bool tracking)
        {
            base.Query_with_conditional_param_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_full_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_param_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_hiding_props(bool tracking)
        {
            base.Query_with_conditional_param_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Query_with_conditional_param_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_read_only_props(bool tracking)
        {
            base.Query_with_conditional_param_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_read_only_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_param_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_write_only_props(bool tracking)
        {
            base.Query_with_conditional_param_write_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Query_with_conditional_param_write_only_props_with_named_fields(bool tracking)
        {
            base.Query_with_conditional_param_write_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_auto_props(bool tracking)
        {
            base.Simple_query_auto_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_fields_only(bool tracking)
        {
            base.Simple_query_fields_only(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_fields_only_for_navs_too(bool tracking)
        {
            base.Simple_query_fields_only_for_navs_too(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_full_props(bool tracking)
        {
            base.Simple_query_full_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_full_props_with_named_fields(bool tracking)
        {
            base.Simple_query_full_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_hiding_props(bool tracking)
        {
            base.Simple_query_hiding_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_props_with_IReadOnlyCollection(bool tracking)
        {
            base.Simple_query_props_with_IReadOnlyCollection(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_read_only_props(bool tracking)
        {
            base.Simple_query_read_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_read_only_props_with_named_fields(bool tracking)
        {
            base.Simple_query_read_only_props_with_named_fields(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_write_only_props(bool tracking)
        {
            base.Simple_query_write_only_props(tracking);
        }

        [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
        public override void Simple_query_write_only_props_with_named_fields(bool tracking)
        {
            base.Simple_query_write_only_props_with_named_fields(tracking);
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_auto_props()
        {
            return base.Update_auto_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_fields_only()
        {
            return base.Update_fields_only();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_fields_only_only_for_navs_too()
        {
            return base.Update_fields_only_only_for_navs_too();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_full_props()
        {
            return base.Update_full_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_full_props_with_named_fields()
        {
            return base.Update_full_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_hiding_props()
        {
            return base.Update_hiding_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_props_with_IReadOnlyCollection()
        {
            return base.Update_props_with_IReadOnlyCollection();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_read_only_props()
        {
            return base.Update_read_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_read_only_props_with_named_fields()
        {
            return base.Update_read_only_props_with_named_fields();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_write_only_props()
        {
            return base.Update_write_only_props();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        public override Task Update_write_only_props_with_named_fields()
        {
            return base.Update_write_only_props_with_named_fields();
        }
        
        protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
            => facade.UseTransaction(transaction.GetDbTransaction());

        public abstract class FieldMappingDuckDBFixtureBase : FieldMappingFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory
                => DuckDBTestStoreFactory.Instance;
        }
    }

    public class DefaultMappingTest(DefaultMappingTest.DefaultMappingFixture fixture)
        : FieldMappingDuckDBTestBase<DefaultMappingTest.DefaultMappingFixture>(fixture)
    {
        public class DefaultMappingFixture : FieldMappingDuckDBFixtureBase;
    }

    public class EnforceFieldTest(EnforceFieldTest.EnforceFieldFixture fixture)
        : FieldMappingDuckDBTestBase<EnforceFieldTest.EnforceFieldFixture>(fixture)
    {
        public class EnforceFieldFixture : FieldMappingDuckDBFixtureBase
        {
            protected override string StoreName
                => "FieldMappingEnforceFieldTest";

            protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
            {
                modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Field);
                base.OnModelCreating(modelBuilder, context);
            }
        }
    }

    public class EnforceFieldForQueryTest(EnforceFieldForQueryTest.EnforceFieldForQueryFixture fixture)
        : FieldMappingDuckDBTestBase<EnforceFieldForQueryTest.EnforceFieldForQueryFixture>(fixture)
    {
        public class EnforceFieldForQueryFixture : FieldMappingDuckDBFixtureBase
        {
            protected override string StoreName
                => "FieldMappingFieldQueryTest";

            protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
            {
                modelBuilder.UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
                base.OnModelCreating(modelBuilder, context);
            }
        }
    }

    public class EnforcePropertyTest(EnforcePropertyTest.EnforcePropertyFixture fixture)
        : FieldMappingDuckDBTestBase<EnforcePropertyTest.EnforcePropertyFixture>(fixture)
    {
        // Cannot force property access when properties missing getter/setter
        public override void Simple_query_read_only_props(bool tracking)
        {
        }

        public override void Include_collection_read_only_props(bool tracking)
        {
        }

        public override void Include_reference_read_only_props(bool tracking)
        {
        }

        public override void Load_collection_read_only_props()
        {
        }

        public override void Load_reference_read_only_props()
        {
        }

        public override void Query_with_conditional_constant_read_only_props(bool tracking)
        {
        }

        public override void Query_with_conditional_param_read_only_props(bool tracking)
        {
        }

        public override void Projection_read_only_props(bool tracking)
        {
        }

        public override Task Update_read_only_props()
            => Task.CompletedTask;

        public override void Simple_query_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Include_collection_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Include_reference_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Load_collection_read_only_props_with_named_fields()
        {
        }

        public override void Load_reference_read_only_props_with_named_fields()
        {
        }

        public override void Query_with_conditional_constant_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Query_with_conditional_param_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Projection_read_only_props_with_named_fields(bool tracking)
        {
        }

        public override Task Update_read_only_props_with_named_fields()
            => Task.CompletedTask;

        public override void Simple_query_write_only_props(bool tracking)
        {
        }

        public override void Include_collection_write_only_props(bool tracking)
        {
        }

        public override void Include_reference_write_only_props(bool tracking)
        {
        }

        public override void Load_collection_write_only_props()
        {
        }

        public override void Load_reference_write_only_props()
        {
        }

        public override void Query_with_conditional_constant_write_only_props(bool tracking)
        {
        }

        public override void Query_with_conditional_param_write_only_props(bool tracking)
        {
        }

        public override void Projection_write_only_props(bool tracking)
        {
        }

        public override Task Update_write_only_props()
            => Task.CompletedTask;

        public override void Simple_query_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Include_collection_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Include_reference_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Load_collection_write_only_props_with_named_fields()
        {
        }

        public override void Load_reference_write_only_props_with_named_fields()
        {
        }

        public override void Query_with_conditional_constant_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Query_with_conditional_param_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override void Projection_write_only_props_with_named_fields(bool tracking)
        {
        }

        public override Task Update_write_only_props_with_named_fields()
            => Task.CompletedTask;

        public override void Simple_query_fields_only(bool tracking)
        {
        }

        public override void Include_collection_fields_only(bool tracking)
        {
        }

        public override void Include_reference_fields_only(bool tracking)
        {
        }

        public override void Load_collection_fields_only()
        {
        }

        public override void Load_reference_fields_only()
        {
        }

        public override void Query_with_conditional_constant_fields_only(bool tracking)
        {
        }

        public override void Query_with_conditional_param_fields_only(bool tracking)
        {
        }

        public override void Projection_fields_only(bool tracking)
        {
        }

        public override Task Update_fields_only()
            => Task.CompletedTask;

        public override void Simple_query_fields_only_for_navs_too(bool tracking)
        {
        }

        public override void Include_collection_fields_only_for_navs_too(bool tracking)
        {
        }

        public override void Include_reference_fields_only_only_for_navs_too(bool tracking)
        {
        }

        public override void Load_collection_fields_only_only_for_navs_too()
        {
        }

        public override void Load_reference_fields_only_only_for_navs_too()
        {
        }

        public override void Query_with_conditional_constant_fields_only_only_for_navs_too(bool tracking)
        {
        }

        public override void Query_with_conditional_param_fields_only_only_for_navs_too(bool tracking)
        {
        }

        public override void Projection_fields_only_only_for_navs_too(bool tracking)
        {
        }

        public override Task Update_fields_only_only_for_navs_too()
            => Task.CompletedTask;

        public override void Include_collection_full_props(bool tracking)
        {
        }

        public override void Include_reference_full_props(bool tracking)
        {
        }

        public override void Load_collection_full_props()
        {
        }

        public override void Load_reference_full_props()
        {
        }

        public override Task Update_full_props()
            => Task.CompletedTask;

        public override void Simple_query_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override void Include_collection_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override void Include_reference_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override void Load_collection_props_with_IReadOnlyCollection()
        {
        }

        public override void Load_reference_props_with_IReadOnlyCollection()
        {
        }

        public override void Query_with_conditional_constant_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override void Query_with_conditional_param_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override void Projection_props_with_IReadOnlyCollection(bool tracking)
        {
        }

        public override Task Update_props_with_IReadOnlyCollection()
            => Task.CompletedTask;

        public class EnforcePropertyFixture : FieldMappingDuckDBFixtureBase
        {
            protected override string StoreName
                => "FieldMappingEnforcePropertyTest";

            protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
            {
                modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);
                base.OnModelCreating(modelBuilder, context);
            }
        }
    }
}