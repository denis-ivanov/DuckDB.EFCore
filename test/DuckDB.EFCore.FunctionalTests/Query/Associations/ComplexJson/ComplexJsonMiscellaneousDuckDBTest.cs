using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonMiscellaneousDuckDBTest : ComplexJsonMiscellaneousRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonMiscellaneousDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
