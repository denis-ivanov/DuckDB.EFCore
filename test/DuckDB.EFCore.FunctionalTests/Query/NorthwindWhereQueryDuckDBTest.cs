using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindWhereQueryDuckDBTest : NorthwindWhereQueryRelationalTestBase<NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindWhereQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_constructed_equal(bool async)
    {
        return base.Where_compare_constructed_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_constructed_multi_value_equal(bool async)
    {
        return base.Where_compare_constructed_multi_value_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_constructed_multi_value_not_equal(bool async)
    {
        return base.Where_compare_constructed_multi_value_not_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_constructed_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_constructed_multi_value_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_multi_value_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_constructed_multi_value_not_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_multi_value_not_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_create_constructed_equal(bool async)
    {
        return base.Where_compare_tuple_create_constructed_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_create_constructed_multi_value_equal(bool async)
    {
        return base.Where_compare_tuple_create_constructed_multi_value_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Where_compare_tuple_create_constructed_multi_value_not_equal(bool async)
    {
        return base.Where_compare_tuple_create_constructed_multi_value_not_equal(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task<string> Where_simple_closure(bool async)
    {
        return base.Where_simple_closure(async);
    }
}