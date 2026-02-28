using DuckDB.EFCore.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class AdHocManyToManyQueryDuckDBTest : AdHocManyToManyQueryRelationalTestBase
{
    public AdHocManyToManyQueryDuckDBTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory => DuckDBTestStoreFactory.Instance;

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Many_to_many_load_works_when_join_entity_has_custom_key(bool async)
    {
        return base.Many_to_many_load_works_when_join_entity_has_custom_key(async);
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task SelectMany_with_collection_selector_having_subquery()
    {
        return base.SelectMany_with_collection_selector_having_subquery();
    }
}
