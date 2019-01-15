namespace AbpLearning.Common.Extensions
{
    using System.Threading.Tasks;
    using Abp.Runtime.Caching;

    public static class ChecheExtensions
    {
        /// <summary>
        /// 获取缓存的值
        /// </summary>
        /// <typeparam name="ValueT">缓存值类型</typeparam>
        /// <param name="cacheManager">缓存管理器</param>
        /// <param name="cacheKey">缓存管理器的键</param>
        /// <param name="key">缓存的键</param>
        /// <param name="clear">清理此缓存</param>
        /// <returns>缓存的值</returns>
        public static async Task<ValueT> GetValue<ValueT>(this ICacheManager cacheManager, string cacheKey, string key, bool clear = false)
        {
            var cache = cacheManager.GetCache(cacheKey);
            var cacheValue = await cache?.GetOrDefaultAsync<string, ValueT>(key);

            if (clear)
            {
                await cache.RemoveAsync(key);
            }
            return cacheValue;
        }
    }
}
