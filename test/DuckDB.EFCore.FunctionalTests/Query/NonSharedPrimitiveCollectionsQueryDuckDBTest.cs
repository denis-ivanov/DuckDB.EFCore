using DuckDB.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query;

public class NonSharedPrimitiveCollectionsQueryDuckDBTest : NonSharedPrimitiveCollectionsQueryRelationalTestBase
{
    public NonSharedPrimitiveCollectionsQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Multidimensional_array_is_not_supported()
    {
        return base.Multidimensional_array_is_not_supported();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Array_of_byte_array()
    {
        return base.Array_of_byte_array();
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
