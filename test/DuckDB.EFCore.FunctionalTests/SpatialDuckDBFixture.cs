using DuckDB.EFCore.FunctionalTests.TestUtilities;
using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.NTS.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.SpatialModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.FunctionalTests;

public class SpatialDuckDBFixture  : SpatialFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => DuckDBTestStoreFactory.Instance;

    protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
        => base.AddServices(serviceCollection)
            .AddEntityFrameworkDuckDBNetTopologySuite();

    public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
    {
        var optionsBuilder = base.AddOptions(builder);
        new DuckDBDbContextOptionsBuilder(optionsBuilder).UseNetTopologySuite();

        return optionsBuilder;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<PointEntity>().Property(e => e.PointZ).HasColumnType("POINTZ");
        modelBuilder.Entity<PointEntity>().Property(e => e.PointM).HasColumnType("POINTM");
        modelBuilder.Entity<PointEntity>().Property(e => e.PointZM).HasColumnType("POINTZM");
    }
}