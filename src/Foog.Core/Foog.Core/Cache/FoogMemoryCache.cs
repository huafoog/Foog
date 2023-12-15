using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foog.Core.Cache
{
    public class FoogMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public FoogMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<long> DeleteAsync(string key)
        {
            await Task.CompletedTask;
            _memoryCache.Remove(key);
            return 1;
        }

        public async Task<string> GetAsync(string key)
        {
            await Task.CompletedTask;
            return _memoryCache.Get<string>(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            await Task.CompletedTask;
            return _memoryCache.Get<T>(key);
        }

        public async Task<bool> SetAsync(string key, object t, int expiresSec = -1)
        {
            await Task.CompletedTask;
            _memoryCache.Set(key, TimeSpan.FromSeconds(expiresSec));
            return true;
        }

        public async Task<bool> SetAsync(string key, object t, TimeSpan expirationTime)
        {
            await Task.CompletedTask;
            _memoryCache.Set(key, expirationTime);
            return true;
        }
    }
}
