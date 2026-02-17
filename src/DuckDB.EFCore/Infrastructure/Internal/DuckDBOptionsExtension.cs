using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DuckDB.EFCore.Infrastructure.Internal;

public class DuckDBOptionsExtension : RelationalOptionsExtension
{
    private DbContextOptionsExtensionInfo? _info;
    private bool _loadSpatialite;
    
    public DuckDBOptionsExtension()
    {
    }

    protected DuckDBOptionsExtension(DuckDBOptionsExtension copyFrom)
        : base(copyFrom)
    {
    }
    
    protected override RelationalOptionsExtension Clone()
    {
        return new DuckDBOptionsExtension(this);
    }

    public override void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkDuckDB();
    }

    public virtual DuckDBOptionsExtension WithLoadSpatialite(bool loadSpatialite)
    {
        var clone = (DuckDBOptionsExtension)Clone();

        clone._loadSpatialite = loadSpatialite;

        return clone;
    }

    public override DbContextOptionsExtensionInfo Info => _info ??= new ExtensionInfo(this);

    private sealed class ExtensionInfo(IDbContextOptionsExtension extension) : RelationalExtensionInfo(extension)
    {
        private string? _logFragment;

        private new DuckDBOptionsExtension Extension
            => (DuckDBOptionsExtension)base.Extension;

        public override bool IsDatabaseProvider
            => true;

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
            => other is ExtensionInfo;

        public override string LogFragment
        {
            get
            {
                if (_logFragment == null)
                {
                    var builder = new StringBuilder();

                    builder.Append(base.LogFragment);

                    _logFragment = builder.ToString();
                }

                return _logFragment;
            }
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            => debugInfo["DuckDB"] = "1";
    }
}