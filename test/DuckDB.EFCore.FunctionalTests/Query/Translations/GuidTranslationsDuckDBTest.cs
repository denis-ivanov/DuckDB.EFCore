using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Translations;

public class GuidTranslationsDuckDBTest : GuidTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public GuidTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public override Task NewGuid()
    {
        return base.NewGuid();
    }
}
