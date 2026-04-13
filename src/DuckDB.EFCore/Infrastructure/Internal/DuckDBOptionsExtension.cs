using DuckDB.EFCore.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Text;

namespace DuckDB.EFCore.Infrastructure.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class DuckDBOptionsExtension : RelationalOptionsExtension
{
    private DbContextOptionsExtensionInfo? _info;
    private bool _loadSpatialite;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public DuckDBOptionsExtension()
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected DuckDBOptionsExtension(DuckDBOptionsExtension copyFrom)
        : base(copyFrom)
    {
        ReverseNullOrdering = copyFrom.ReverseNullOrdering;
    }

    /// <summary>
    /// <see langword="true"/> if reverse null ordering is enabled; otherwise, <see langword="false" />.
    /// </summary>
    public virtual bool ReverseNullOrdering { get; private set; }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override RelationalOptionsExtension Clone()
    {
        return new DuckDBOptionsExtension(this);
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkDuckDB();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual DuckDBOptionsExtension WithLoadSpatialite(bool loadSpatialite)
    {
        var clone = (DuckDBOptionsExtension)Clone();

        clone._loadSpatialite = loadSpatialite;

        return clone;
    }

    /// <summary>
    ///     Returns a copy of the current instance configured with the specified value.
    /// </summary>
    /// <param name="reverseNullOrdering"><see langword="true"/> to enable reverse null ordering; otherwise, <see langword="false"/>.</param>
    internal virtual DuckDBOptionsExtension WithReverseNullOrdering(bool reverseNullOrdering)
    {
        var clone = (DuckDBOptionsExtension)Clone();

        clone.ReverseNullOrdering = reverseNullOrdering;

        return clone;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
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
