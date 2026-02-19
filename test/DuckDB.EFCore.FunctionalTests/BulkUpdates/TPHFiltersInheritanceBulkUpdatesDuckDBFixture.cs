namespace DuckDB.EFCore.FunctionalTests.BulkUpdates;

public class TPHFiltersInheritanceBulkUpdatesDuckDBFixture : TPHInheritanceBulkUpdatesDuckDBFixture
{
    public override bool EnableFilters => true;
}