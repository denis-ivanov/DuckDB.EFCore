using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace DuckDB.EFCore.NTS.Design.Internal;

public class DuckDBNetTopologySuiteDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        throw new NotImplementedException();
    }
}