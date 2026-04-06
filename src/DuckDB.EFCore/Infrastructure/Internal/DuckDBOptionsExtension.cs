using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
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
        ReverseNullOrdering = copyFrom.ReverseNullOrdering;
    }

    public virtual bool ReverseNullOrdering { get; private set; }

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

    internal virtual DuckDBOptionsExtension WithReverseNullOrdering(bool reverseNullOrdering)
    {
        var clone = (DuckDBOptionsExtension)Clone();

        clone.ReverseNullOrdering = reverseNullOrdering;

        return clone;
    }

    public override DbContextOptionsExtensionInfo Info => _info ??= new ExtensionInfo(this);

    private sealed class ExtensionInfo(IDbContextOptionsExtension extension) : RelationalExtensionInfo(extension)
    {
        private int? _serviceProviderHash;
        private string? _logFragment;

        private new DuckDBOptionsExtension Extension
            => (DuckDBOptionsExtension)base.Extension;

        public override bool IsDatabaseProvider
            => true;

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
            => other is ExtensionInfo otherInfo
               && Extension.ReverseNullOrdering == otherInfo.Extension.ReverseNullOrdering;

        public override string LogFragment
        {
            get
            {
                if (_logFragment == null)
                {
                    var builder = new StringBuilder();

                    builder.Append(base.LogFragment);

                    if (Extension.ReverseNullOrdering)
                    {
                        builder.Append(nameof(Extension.ReverseNullOrdering)).Append(' ');
                    }

                    _logFragment = builder.ToString();
                }

                return _logFragment;
            }
        }

        public override int GetServiceProviderHashCode()
        {
            if (_serviceProviderHash == null)
            {
                var hashCode = new HashCode();
                
                hashCode.Add(Extension.ReverseNullOrdering);

                _serviceProviderHash = hashCode.ToHashCode();
            }

            return _serviceProviderHash.Value;
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
            debugInfo["DuckDB"] = "1";
            debugInfo["DuckDB.EFCore:" + nameof(ReverseNullOrdering)] = Extension.ReverseNullOrdering.GetHashCode()
                .ToString(CultureInfo.InvariantCulture);
        }
    }
}
