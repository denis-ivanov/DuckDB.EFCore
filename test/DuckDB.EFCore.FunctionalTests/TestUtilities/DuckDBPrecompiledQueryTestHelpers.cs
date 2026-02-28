using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Reflection;

namespace DuckDB.EFCore.FunctionalTests.TestUtilities;

public class DuckDBPrecompiledQueryTestHelpers : PrecompiledQueryTestHelpers
{
    public static readonly DuckDBPrecompiledQueryTestHelpers Instance = new();

    protected override IEnumerable<MetadataReference> BuildProviderMetadataReferences()
    {
        yield return MetadataReference.CreateFromFile(typeof(DuckDBOptionsExtension).Assembly.Location);
        yield return MetadataReference.CreateFromFile(Assembly.GetExecutingAssembly().Location);
    }
}
