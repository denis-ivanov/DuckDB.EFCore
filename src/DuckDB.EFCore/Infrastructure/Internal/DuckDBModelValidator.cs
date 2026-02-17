using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DuckDB.EFCore.Infrastructure.Internal;

public class DuckDBModelValidator : RelationalModelValidator
{
    public DuckDBModelValidator(ModelValidatorDependencies dependencies, RelationalModelValidatorDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }
}