using System;

namespace Microsoft.Extensions.Caching.Memory
{
    public static class CacheHelper
    {
        /// <summary>
        /// 5 dk. cache'te tut.
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public static void Store(this IMemoryCache memoryCache, string key, object obj)
        {
            memoryCache.Remove(key);

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
