using DuckDB.EFCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DuckDB.EFCore.Query.Internal;

public class DuckDBCompiledQueryCacheKeyGenerator : RelationalCompiledQueryCacheKeyGenerator
{
    public DuckDBCompiledQueryCacheKeyGenerator(
        CompiledQueryCacheKeyGeneratorDependencies dependencies,
        RelationalCompiledQueryCacheKeyGeneratorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }
    
    public override object GenerateCacheKey(Expression query, bool async)
        => new DuckDBCompiledQueryCacheKey(
            GenerateCacheKeyCore(query, async),
            RelationalDependencies.ContextOptions.FindExtension<DuckDBOptionsExtension>()?.ReverseNullOrdering ?? false);

    private struct DuckDBCompiledQueryCacheKey(
        RelationalCompiledQueryCacheKey relationalCompiledQueryCacheKey,
        bool reverseNullOrdering)
    {
        private readonly RelationalCompiledQueryCacheKey _relationalCompiledQueryCacheKey = relationalCompiledQueryCacheKey;
        private readonly bool _reverseNullOrdering = reverseNullOrdering;

        public override bool Equals(object? obj)
            => !(obj is null)
               && obj is DuckDBCompiledQueryCacheKey key
               && Equals(key);

        private bool Equals(DuckDBCompiledQueryCacheKey other)
            => _relationalCompiledQueryCacheKey.Equals(other._relationalCompiledQueryCacheKey)
               && _reverseNullOrdering == other._reverseNullOrdering;

        public override int GetHashCode()
            => HashCode.Combine(_relationalCompiledQueryCacheKey, _reverseNullOrdering);
    }
}