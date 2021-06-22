using System;
using System.Threading.Tasks;
using EnoCore.Scoreboard;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace EnoLandingPageBackend.Cache
{
    public class ScoreboardCache
    {
        private readonly string defaultKey = "default";
        private MemoryCache _cache { get; set; }
        public ScoreboardCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
        }

        public Scoreboard TryGetDefault()
        {
            Scoreboard cacheEntry;
            this._cache.TryGetValue(defaultKey, out cacheEntry);
            return cacheEntry;
        }
        public void InvalidateDefault()
        {
            this._cache.Remove(defaultKey);
        }

        public void CreateDefault(Scoreboard scoreboard)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(1);
            _cache.Set(this.defaultKey, scoreboard, cacheEntryOptions);
        }

        public Scoreboard GetOrCreate(object key, Func<Scoreboard> createItem)
        {
            Scoreboard cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(1)
                    .SetPriority(CacheItemPriority.Normal);

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public async Task<Scoreboard> GetOrCreateAsync(object key, Func<Task<Scoreboard>> createItem)
        {
            var func = await createItem();
            return this.GetOrCreate(key, () =>
            {
                return func;
            });
        }
    }
}