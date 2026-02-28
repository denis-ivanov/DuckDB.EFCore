using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class FunkyDataQueryDuckDBTest : FunkyDataQueryTestBase<FunkyDataQueryDuckDBTest.FunkyDataQueryDuckDBFixture>
{
    public FunkyDataQueryDuckDBTest(FunkyDataQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_contains_on_argument_with_wildcard_column_negated(bool async)
    {
        return base.String_contains_on_argument_with_wildcard_column_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_contains_on_argument_with_wildcard_constant(bool async)
    {
        return base.String_contains_on_argument_with_wildcard_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_contains_on_argument_with_wildcard_parameter(bool async)
    {
        return base.String_contains_on_argument_with_wildcard_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_equals_nullable_column(bool async)
    {
        return base.String_ends_with_equals_nullable_column(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_inside_conditional_negated(bool async)
    {
        return base.String_ends_with_inside_conditional_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_not_equals_nullable_column(bool async)
    {
        return base.String_ends_with_not_equals_nullable_column(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_on_argument_with_wildcard_column_negated(bool async)
    {
        return base.String_ends_with_on_argument_with_wildcard_column_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_on_argument_with_wildcard_constant(bool async)
    {
        return base.String_ends_with_on_argument_with_wildcard_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_ends_with_on_argument_with_wildcard_parameter(bool async)
    {
        return base.String_ends_with_on_argument_with_wildcard_parameter(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_FirstOrDefault_and_LastOrDefault(bool async)
    {
        return base.String_FirstOrDefault_and_LastOrDefault(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_starts_with_on_argument_with_wildcard_column_negated(bool async)
    {
        return base.String_starts_with_on_argument_with_wildcard_column_negated(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_starts_with_on_argument_with_wildcard_constant(bool async)
    {
        return base.String_starts_with_on_argument_with_wildcard_constant(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task String_starts_with_on_argument_with_wildcard_parameter(bool async)
    {
        return base.String_starts_with_on_argument_with_wildcard_parameter(async);
    }

    public class FunkyDataQueryDuckDBFixture : FunkyDataQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;
    }
}
