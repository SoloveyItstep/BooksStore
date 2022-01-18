using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Books.Infrastructure.Business.Extensions
{
    public static class DistributedCacheExtension
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
                                                   string recordId, 
                                                   T record, 
                                                   TimeSpan? absoluteExpireTime = null, 
                                                   TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(5),
                SlidingExpiration = unusedExpireTime
            };
            var json = JsonSerializer.Serialize(record);
            await cache.SetStringAsync(recordId, json, options).ConfigureAwait(false);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var json = await cache.GetStringAsync(recordId).ConfigureAwait(false);
            if(json is null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
