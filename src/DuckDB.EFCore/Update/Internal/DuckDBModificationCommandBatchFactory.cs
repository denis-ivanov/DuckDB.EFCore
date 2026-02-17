using Microsoft.EntityFrameworkCore.Update;

namespace DuckDB.EFCore.Update.Internal;

public class DuckDBModificationCommandBatchFactory : IModificationCommandBatchFactory
{
    public DuckDBModificationCommandBatchFactory(ModificationCommandBatchFactoryDependencies dependencies)
    {
        Dependencies = dependencies;
    }

    protected virtual ModificationCommandBatchFactoryDependencies Dependencies { get; }
    
    public ModificationCommandBatch Create()
    {
        return new SingularModificationCommandBatch(Dependencies);
    }
}