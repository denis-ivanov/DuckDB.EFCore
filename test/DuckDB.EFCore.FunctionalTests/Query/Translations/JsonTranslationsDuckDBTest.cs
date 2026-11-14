using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query.Translations;

public class JsonTranslationsDuckDBTest : JsonTranslationsRelationalTestBase<JsonTranslationsDuckDBTest.JsonTranslationsQueryDuckDBFixture>
{
    public JsonTranslationsDuckDBTest(JsonTranslationsQueryDuckDBFixture fixture)
        : base(fixture)
    {
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task JsonPathExists_on_complex_property()
    {
        await base.JsonPathExists_on_complex_property();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task JsonPathExists_on_owned_entity()
    {
        await base.JsonPathExists_on_owned_entity();
    }

    [Fact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task JsonPathExists_on_scalar_string_column()
    {
        await base.JsonPathExists_on_scalar_string_column();
    }

    public class JsonTranslationsQueryDuckDBFixture : JsonTranslationsQueryFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        protected override string RemoveJsonProperty(string column, string property)
            => $"json_remove({column}, '$.{property}')";
    }
}
