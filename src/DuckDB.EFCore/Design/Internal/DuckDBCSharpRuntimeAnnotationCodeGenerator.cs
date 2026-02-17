using Microsoft.EntityFrameworkCore.Design.Internal;

namespace DuckDB.EFCore.Design.Internal;

public class DuckDBCSharpRuntimeAnnotationCodeGenerator : RelationalCSharpRuntimeAnnotationCodeGenerator
{
    public DuckDBCSharpRuntimeAnnotationCodeGenerator(CSharpRuntimeAnnotationCodeGeneratorDependencies dependencies, RelationalCSharpRuntimeAnnotationCodeGeneratorDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }
}
