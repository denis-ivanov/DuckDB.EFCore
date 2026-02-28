namespace DuckDB.EFCore.FunctionalTests.Query;

public class IncompleteMappingInheritanceQueryDuckDBFixture : TPHInheritanceQueryDuckDBFixture
{
    public override bool IsDiscriminatorMappingComplete
        => false;
}