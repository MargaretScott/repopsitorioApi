using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoDotNet.CrossCutting.Contracts.Services
{
    public interface ICacheService
    {
        Task<T> GetUsingCache<T>(string cacheKey, Func<Task<T>> getFunction) where T : class;

        Task<T> GetUsingCache<T, U>(string cacheKey, Func<U, Task<T>> getFunction, U functionParameter) where T : class;

        void DeleteFromCache(string cacheKey);
    }
}
