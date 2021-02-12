using Microsoft.Extensions.Caching.Memory;
using System;

namespace Articles.Helpers
{
    public static class CacheHelper
    {
        public static void Store(this IMemoryCache memoryCache, string key, object obj)
        {
            memoryCache.Set(key, obj, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                Priority = CacheItemPriority.Normal
            });
        }

        public static object Load(this IMemoryCache memoryCache, string key)
        {
            if (memoryCache.TryGetValue(key, out object obj))
                return obj;
            return null;
        }
    }
}
