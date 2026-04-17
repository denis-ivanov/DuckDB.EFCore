using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using Xunit.Abstractions;

namespace DuckDB.EFCore.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonPrimitiveCollectionDuckDBTest: ComplexJsonPrimitiveCollectionRelationalTestBase<ComplexJsonDuckDBFixture>
{
    public ComplexJsonPrimitiveCollectionDuckDBTest(ComplexJsonDuckDBFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}
