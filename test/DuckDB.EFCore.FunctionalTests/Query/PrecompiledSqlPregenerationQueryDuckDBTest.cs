using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query;

public class PrecompiledSqlPregenerationQueryDuckDBTest: PrecompiledSqlPregenerationQueryRelationalTestBase,
    IClassFixture<PrecompiledSqlPregenerationQueryDuckDBTest.PrecompiledSqlPregenerationQueryDuckDBFixture>
{
    public PrecompiledSqlPregenerationQueryDuckDBTest(PrecompiledSqlPregenerationQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Final_GroupBy()
    {
        return base.Final_GroupBy();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_single_query()
    {
        return base.Include_single_query();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Include_split_query()
    {
        return base.Include_split_query();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Many_non_nullable_parameters_do_not_prevent_pregeneration()
    {
        return base.Many_non_nullable_parameters_do_not_prevent_pregeneration();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task No_parameters()
    {
        return base.No_parameters();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Non_nullable_reference_type()
    {
        return base.Non_nullable_reference_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Non_nullable_value_type()
    {
        return base.Non_nullable_value_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_and_non_nullable_reference_types()
    {
        return base.Nullable_and_non_nullable_reference_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_and_non_nullable_value_types()
    {
        return base.Nullable_and_non_nullable_value_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_reference_type()
    {
        return base.Nullable_reference_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Nullable_value_type()
    {
        return base.Nullable_value_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Two_non_nullable_reference_types()
    {
        return base.Two_non_nullable_reference_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Too_many_nullable_parameters_prevent_pregeneration()
    {
        return base.Too_many_nullable_parameters_prevent_pregeneration();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Two_nullable_reference_types()
    {
        return base.Two_nullable_reference_types();
    }

    public class PrecompiledSqlPregenerationQueryDuckDBFixture : PrecompiledSqlPregenerationQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => DuckDBPrecompiledQueryTestHelpers.Instance;
    }
}