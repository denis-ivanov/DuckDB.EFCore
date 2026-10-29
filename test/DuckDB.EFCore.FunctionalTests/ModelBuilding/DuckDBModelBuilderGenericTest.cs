using Xunit;

namespace Microsoft.EntityFrameworkCore.ModelBuilding;

public class DuckDBModelBuilderGenericTest : DuckDBModelBuilderTestBase
{
    public class DuckDBGenericNonRelationship : DuckDBNonRelationship
    {
        public DuckDBGenericNonRelationship(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        protected override void Mapping_ignores_ignored_three_dimensional_array()
        {
            base.Mapping_ignores_ignored_three_dimensional_array();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        protected override void Mapping_ignores_ignored_two_dimensional_array()
        {
            base.Mapping_ignores_ignored_two_dimensional_array();
        }

        [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
        protected override void Mapping_throws_for_non_ignored_three_dimensional_array()
        {
            base.Mapping_throws_for_non_ignored_three_dimensional_array();
        }

        [ConditionalFact(Skip = "DuckDB supports dictionary types, so this test from EF Core no longer throws.")]
        protected override void Throws_for_int_keyed_dictionary()
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericComplexType : DuckDBComplexType
    {
        public DuckDBGenericComplexType(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericComplexCollection : DuckDBComplexCollection
    {
        public DuckDBGenericComplexCollection(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericInheritance : DuckDBInheritance
    {
        public DuckDBGenericInheritance(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericOneToMany : DuckDBOneToMany
    {
        public DuckDBGenericOneToMany(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericManyToOne : DuckDBManyToOne
    {
        public DuckDBGenericManyToOne(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericOneToOne : DuckDBOneToOne
    {
        public DuckDBGenericOneToOne(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericManyToMany : DuckDBManyToMany
    {
        public DuckDBGenericManyToMany(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }

    public class DuckDBGenericOwnedTypes : DuckDBOwnedTypes
    {
        public DuckDBGenericOwnedTypes(DuckDBModelBuilderFixture fixture) : base(fixture)
        {
        }

        protected override TestModelBuilder CreateModelBuilder(
            Action<ModelConfigurationBuilder>? configure)
            => new GenericTestModelBuilder(Fixture, configure);
    }
}
