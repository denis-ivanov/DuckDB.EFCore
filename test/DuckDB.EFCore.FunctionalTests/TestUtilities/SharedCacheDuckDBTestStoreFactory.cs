namespace Microsoft.EntityFrameworkCore.TestUtilities;

public class SharedCacheDuckDBTestStoreFactory : DuckDBTestStoreFactory
{
    public static new SharedCacheDuckDBTestStoreFactory Instance { get; } = new();

    protected SharedCacheDuckDBTestStoreFactory()
    {
    }

    public override TestStore GetOrCreate(string storeName)
        => DuckDBTestStore.GetOrCreate(storeName, sharedCache: true);
}