using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests.Query;

public class NorthwindNavigationsQueryDuckDBTest: NorthwindNavigationsQueryRelationalTestBase<
    NorthwindQueryDuckDBFixture<NoopModelCustomizer>>
{
    public NorthwindNavigationsQueryDuckDBTest(NorthwindQueryDuckDBFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = DuckDBSkipReasons.Tbd)]
    public override Task Select_collection_FirstOrDefault_project_anonymous_type_client_eval(bool async)
    {
        return base.Select_collection_FirstOrDefault_project_anonymous_type_client_eval(async);
    }
}