namespace DuckDB.EFCore.FunctionalTests.BulkUpdates;

public class TPTFiltersInheritanceBulkUpdatesDuckDBFixture : TPTInheritanceBulkUpdatesDuckDBFixture
{
    public override bool EnableFilters => true;
}
