using CursoDotNet.CrossCutting.Contracts.Services;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CursoDotNet.CrossCutting.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetUsingCache<T>(string cacheKey, Func<Task<T>> getFunction) where T : class
        {
            T element = null;

            element = GetElementFromCache<T>(cacheKey);

            if (element == null)
            {
                element = await getFunction();

                AddElementToCache(cacheKey, element);
            }

            return element;
        }

        public async Task<T> GetUsingCache<T, U>(string cacheKey, Func<U, Task<T>> getFunction, U functionParameter) where T : class
        {
            T element = null;

            element = GetElementFromCache<T>(cacheKey);

            if (element == null)
            {
                element = await getFunction(functionParameter);

                AddElementToCache(cacheKey, element);
            }

            return element;
        }

        public void DeleteFromCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        private T GetElementFromCache<T>(string cacheKey) where T : class
        {
            T element = null;

            var elementJson = _cache.Get(cacheKey);

            if (elementJson != null)
            {
                element = JsonConvert.DeserializeObject<T>(elementJson.ToString());
            }

            return element;
        }

        private void AddElementToCache<T>(string cacheKey, T elementToStore) where T : class
        {
            if (elementToStore != null)
            {
                var elementJson = JsonConvert.SerializeObject(elementToStore);

                _cache.Set(cacheKey, elementJson);
            }
        }
    }
}
