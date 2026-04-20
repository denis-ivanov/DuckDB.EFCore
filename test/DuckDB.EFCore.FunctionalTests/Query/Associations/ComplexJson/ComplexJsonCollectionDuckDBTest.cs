using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonCollectionDuckDBTest : ComplexJsonCollectionRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonCollectionDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
