using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonMiscellaneousDuckDBTest : ComplexJsonMiscellaneousRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonMiscellaneousDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_on_associate_scalar_property()
    {
        return base.Where_on_associate_scalar_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_on_nested_associate_scalar_property()
    {
        return base.Where_on_nested_associate_scalar_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_on_optional_associate_scalar_property()
    {
        return base.Where_on_optional_associate_scalar_property();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task FromSql_on_root()
    {
        return base.FromSql_on_root();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_HasValue_on_nullable_value_type()
    {
        return base.Where_HasValue_on_nullable_value_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_property_on_non_nullable_value_type()
    {
        return base.Where_property_on_non_nullable_value_type();
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_property_on_nullable_value_type_Value()
    {
        return base.Where_property_on_nullable_value_type_Value();
    }
}