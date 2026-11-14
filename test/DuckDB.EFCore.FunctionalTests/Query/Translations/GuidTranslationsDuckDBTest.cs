using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class GuidTranslationsDuckDBTest : GuidTranslationsTestBase<BasicTypesQueryDuckDBFixture>
{
    public GuidTranslationsDuckDBTest(BasicTypesQueryDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
