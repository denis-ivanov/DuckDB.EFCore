using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace DuckDB.EFCore.Scaffolding.Internal;

public class DuckDBCodeGenerator : ProviderCodeGenerator
{
    public DuckDBCodeGenerator(ProviderCodeGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    public override MethodCallCodeFragment GenerateUseProvider(string connectionString, MethodCallCodeFragment? providerOptions)
    {
        throw new NotImplementedException();
    }
}
