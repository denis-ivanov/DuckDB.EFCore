using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace DuckDB.EFCore.Storage.Internal;

public class DuckDBRelationalTransactionFactory : RelationalTransactionFactory
{
    public DuckDBRelationalTransactionFactory(RelationalTransactionFactoryDependencies dependencies) : base(dependencies)
    {
    }

    public override RelationalTransaction Create(
        IRelationalConnection connection,
        DbTransaction transaction,
        Guid transactionId,
        IDiagnosticsLogger<DbLoggerCategory.Database.Transaction> logger,
        bool transactionOwned)
    {
        return new DuckDBRelationalTransaction(
            connection,
            transaction,
            transactionId,
            logger,
            transactionOwned,
            Dependencies.SqlGenerationHelper);
    }
}