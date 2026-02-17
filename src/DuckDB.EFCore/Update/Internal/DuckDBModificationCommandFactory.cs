using Microsoft.EntityFrameworkCore.Update;

namespace DuckDB.EFCore.Update.Internal;

public class DuckDBModificationCommandFactory : IModificationCommandFactory
{
    public IModificationCommand CreateModificationCommand(in ModificationCommandParameters modificationCommandParameters)
    {
        return new DuckDBModificationCommand(modificationCommandParameters);
    }

    public INonTrackedModificationCommand CreateNonTrackedModificationCommand(
        in NonTrackedModificationCommandParameters modificationCommandParameters)
    {
        return new DuckDBModificationCommand(modificationCommandParameters);
    }
}
