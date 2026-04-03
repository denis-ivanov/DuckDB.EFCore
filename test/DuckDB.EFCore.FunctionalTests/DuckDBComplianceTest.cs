using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Xunit;

namespace DuckDB.EFCore.FunctionalTests;

public class DuckDBComplianceTest : RelationalComplianceTestBase
{
    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void All_test_bases_must_be_implemented()
    {
        base.All_test_bases_must_be_implemented();
    }

    protected override Assembly TargetAssembly { get; } = typeof(DuckDBComplianceTest).Assembly;
}
