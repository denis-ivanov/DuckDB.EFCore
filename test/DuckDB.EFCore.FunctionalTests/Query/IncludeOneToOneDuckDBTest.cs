using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class IncludeOneToOneDuckDBTest : IncludeOneToOneTestBase<IncludeOneToOneDuckDBTest.OneToOneQueryDuckDBFixture>
{
    public IncludeOneToOneDuckDBTest(OneToOneQueryDuckDBFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address()
    {
        base.Include_address();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address_EF_Property()
    {
        base.Include_address_EF_Property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address_no_tracking()
    {
        base.Include_address_no_tracking();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address_no_tracking_EF_Property()
    {
        base.Include_address_no_tracking_EF_Property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address_shadow()
    {
        base.Include_address_shadow();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_address_when_person_already_tracked()
    {
        base.Include_address_when_person_already_tracked();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person()
    {
        base.Include_person();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person_EF_Property()
    {
        base.Include_person_EF_Property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person_no_tracking()
    {
        base.Include_person_no_tracking();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person_no_tracking_EF_Property()
    {
        base.Include_person_no_tracking_EF_Property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person_shadow()
    {
        base.Include_person_shadow();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Include_person_when_address_already_tracked()
    {
        base.Include_person_when_address_already_tracked();
    }

    public class OneToOneQueryDuckDBFixture : OneToOneQueryFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory => (TestSqlLoggerFactory)ListLoggerFactory;
    }
}