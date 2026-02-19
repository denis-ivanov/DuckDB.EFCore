namespace DuckDB.EFCore.FunctionalTests.BulkUpdates;

public class TPCFiltersInheritanceBulkUpdatesDuckDBFixture : TPCInheritanceBulkUpdatesDuckDBFixture
{
    public override bool EnableFilters => true;
}