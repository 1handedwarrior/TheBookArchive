using BooksProj.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BooksProj.Services;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    public T? Get<T>(string key)
    {
        return _cache.TryGetValue(key, out T? value) ? value : default;
    }

    public void Set<T>(string key, T value, TimeSpan slidingExpiration, TimeSpan absoluteExpiration)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(slidingExpiration)
            .SetAbsoluteExpiration(absoluteExpiration)
            .SetPriority(CacheItemPriority.Normal);

        _cache.Set(key, value, cacheEntryOptions);
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
    }
}