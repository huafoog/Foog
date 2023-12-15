using Foog.Core.Cache.Exceptions;
using Foog.Core.Cache.Options;
using FreeRedis;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foog.Core.Cache.Extensions
{
    public static class RedisCollectionExtension
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">配置</param>
        /// <returns></returns>
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheOption = configuration.GetSection(typeof(CacheOption).GetDescription()).Get<CacheOption>();
            if (cacheOption != null)
            {
                if (cacheOption.CacheWay.IsNull())
                {
                    throw new CacheErrorException("错误的缓存方式");
                }
                if (cacheOption.CacheWay.ToUpper() == "Redis".ToUpper())
                {
                    services.AddSingleton(new RedisClient($"{cacheOption.Redis.Host},password={cacheOption.Redis.Password},defaultDatabase={cacheOption.Redis.DefaultDatabase}"));
                    services.AddSingleton<ICache, RedisCache>();
                }
                else if (cacheOption.CacheWay.ToUpper() == "Memory".ToUpper())
                {
                    services.AddMemoryCache();
                    services.AddSingleton<ICache, FoogMemoryCache>();
                }
            }

            return services;
        }
    }
}
