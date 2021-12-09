using System;
using System.Threading.Tasks;

namespace Cleverti.Assessment.Domain.Interfaces.Cache
{
    public interface ICacheManager
    {
        Task<T> GetAsync<T>(string key, Func<Task<T>> value, int expiration = 5);
        Task<T> GetAsync<T>(string key, Func<T> value, int expiration = 5);
        Task UpdateAsync(string key, object value);
        Task RemoveAsync(string key);
        T Get<T>(string key, Func<T> value, int expiration = 5);
        void Update(string key, object value);
        void Remove(string key);
    }
}
