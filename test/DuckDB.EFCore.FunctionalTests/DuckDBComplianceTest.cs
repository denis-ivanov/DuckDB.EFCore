using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

public class DuckDBComplianceTest : RelationalComplianceTestBase
{
    protected override ICollection<Type> IgnoredTestBases { get; } = new HashSet<Type>
    {
        typeof(FromSqlSprocQueryTestBase<>),
        typeof(SqlExecutorTestBase<>),
        typeof(UdfDbFunctionTestBase<>),
        typeof(StoredProcedureUpdateTestBase), // DuckDB does not support stored procedures
        typeof(RuntimeMigrationTestBase<>) // TODO Some tests are non-virtual.
    };

    protected override Assembly TargetAssembly { get; } = typeof(DuckDBComplianceTest).Assembly;
}
