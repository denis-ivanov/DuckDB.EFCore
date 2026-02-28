using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class AdHocComplexTypeQueryDuckDBTest : AdHocComplexTypeQueryTestBase
{
    public AdHocComplexTypeQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_type_equality_with_non_default_type_mapping()
    {
        return base.Complex_type_equality_with_non_default_type_mapping();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Complex_type_equals_parameter_with_nested_types_with_property_of_same_name()
    {
        return base.Complex_type_equals_parameter_with_nested_types_with_property_of_same_name();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Non_optional_complex_type_with_all_nullable_properties()
    {
        return base.Non_optional_complex_type_with_all_nullable_properties();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Optional_complex_type_with_discriminator()
    {
        return base.Optional_complex_type_with_discriminator();
    }
}
