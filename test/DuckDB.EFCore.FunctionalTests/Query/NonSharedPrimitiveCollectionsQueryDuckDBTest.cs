using DuckDB.EFCore.FunctionalTests.TestUtilities;
using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NonSharedPrimitiveCollectionsQueryDuckDBTest : NonSharedPrimitiveCollectionsQueryRelationalTestBase
{
    public NonSharedPrimitiveCollectionsQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Column_collection_inside_json_owned_entity()
    {
        return base.Column_collection_inside_json_owned_entity();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_Contains_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        return base.Parameter_collection_Contains_with_default_mode_EF_Parameter(mode);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_Count_with_column_predicate_with_default_mode(ParameterTranslationMode mode)
    {
        return base.Parameter_collection_Count_with_column_predicate_with_default_mode(mode);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        return base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(mode);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_bool()
    {
        return base.Array_of_bool();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_byte_array()
    {
        return base.Array_of_byte_array();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_DateOnly()
    {
        return base.Array_of_DateOnly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_DateTime()
    {
        return base.Array_of_DateTime();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_DateTime_with_microseconds()
    {
        return base.Array_of_DateTime_with_microseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_DateTime_with_milliseconds()
    {
        return base.Array_of_DateTime_with_milliseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_DateTimeOffset()
    {
        return base.Array_of_DateTimeOffset();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_decimal()
    {
        return base.Array_of_decimal();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_double()
    {
        return base.Array_of_double();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_enum()
    {
        return base.Array_of_enum();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_float()
    {
        return base.Array_of_float();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_Guid()
    {
        return base.Array_of_Guid();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_int()
    {
        return base.Array_of_int();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_long()
    {
        return base.Array_of_long();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_short()
    {
        return base.Array_of_short();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_string()
    {
        return base.Array_of_string();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_TimeOnly()
    {
        return base.Array_of_TimeOnly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_TimeOnly_with_microseconds()
    {
        return base.Array_of_TimeOnly_with_microseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_TimeOnly_with_milliseconds()
    {
        return base.Array_of_TimeOnly_with_milliseconds();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Subquery_over_primitive_collection_on_inheritance_derived_type()
    {
        return base.Subquery_over_primitive_collection_on_inheritance_derived_type();
    }

    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override DbContextOptionsBuilder SetParameterizedCollectionMode(DbContextOptionsBuilder optionsBuilder,
        ParameterTranslationMode parameterizedCollectionMode)
    {
        new DuckDBDbContextOptionsBuilder(optionsBuilder).UseParameterizedCollectionMode(parameterizedCollectionMode);

        return optionsBuilder;
    }
}
