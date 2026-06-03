using Microsoft.EntityFrameworkCore.TestModels.JsonQuery;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query;

public class JsonQueryDuckDBFixture : JsonQueryRelationalFixture
{
    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<JsonEntityAllTypes>(b =>
        {
            b.Ignore(e => e.TestInt64CollectionCollection);
            b.Ignore(e => e.TestDoubleCollectionCollection);
            b.Ignore(e => e.TestSingleCollectionCollection);
            b.Ignore(e => e.TestBooleanCollectionCollection);
            b.Ignore(e => e.TestCharacterCollectionCollection);
            b.Ignore(e => e.TestDefaultStringCollectionCollection);
            b.Ignore(e => e.TestMaxLengthStringCollectionCollection);
            b.Ignore(e => e.TestInt16CollectionCollection);
            b.Ignore(e => e.TestInt32CollectionCollection);
            b.Ignore(e => e.TestNullableEnumWithIntConverterCollectionCollection);
            b.Ignore(e => e.TestNullableInt32CollectionCollection);
            b.Ignore(e => e.TestNullableEnumCollectionCollection);

            b.OwnsOne(
                e => e.Reference, owned =>
                {
                    owned.Ignore(e => e.TestInt64CollectionCollection);
                    owned.Ignore(e => e.TestDoubleCollectionCollection);
                    owned.Ignore(e => e.TestSingleCollectionCollection);
                    owned.Ignore(e => e.TestBooleanCollectionCollection);
                    owned.Ignore(e => e.TestCharacterCollectionCollection);
                    owned.Ignore(e => e.TestDefaultStringCollectionCollection);
                    owned.Ignore(e => e.TestMaxLengthStringCollectionCollection);
                    owned.Ignore(e => e.TestInt16CollectionCollection);
                    owned.Ignore(e => e.TestInt32CollectionCollection);
                    owned.Ignore(e => e.TestNullableEnumWithIntConverterCollectionCollection);
                    owned.Ignore(e => e.TestNullableInt32CollectionCollection);
                    owned.Ignore(e => e.TestNullableEnumCollectionCollection);
                });
            b.OwnsMany(
                x => x.Collection, owned =>
                {
                    owned.Ignore(e => e.TestInt64CollectionCollection);
                    owned.Ignore(e => e.TestDoubleCollectionCollection);
                    owned.Ignore(e => e.TestSingleCollectionCollection);
                    owned.Ignore(e => e.TestBooleanCollectionCollection);
                    owned.Ignore(e => e.TestCharacterCollectionCollection);
                    owned.Ignore(e => e.TestDefaultStringCollectionCollection);
                    owned.Ignore(e => e.TestMaxLengthStringCollectionCollection);
                    owned.Ignore(e => e.TestInt16CollectionCollection);
                    owned.Ignore(e => e.TestInt32CollectionCollection);
                    owned.Ignore(e => e.TestNullableEnumWithIntConverterCollectionCollection);
                    owned.Ignore(e => e.TestNullableInt32CollectionCollection);
                    owned.Ignore(e => e.TestNullableEnumCollectionCollection);
                });
        });
    }
}
