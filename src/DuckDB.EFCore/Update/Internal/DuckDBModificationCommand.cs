using Microsoft.EntityFrameworkCore.Update;

namespace DuckDB.EFCore.Update.Internal;

public class DuckDBModificationCommand : ModificationCommand
{
    public DuckDBModificationCommand(in ModificationCommandParameters modificationCommandParameters) : base(in modificationCommandParameters)
    {
    }

    public DuckDBModificationCommand(in NonTrackedModificationCommandParameters modificationCommandParameters) : base(in modificationCommandParameters)
    {
    }
}