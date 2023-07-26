using Domain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryImplementations
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T? GetCache<T>(string key)
        {
            var response = _cache.Get<T>(key);

            return response;
        }

        public void SetCache<T>(string key, T element)
        {
            _cache.Set(key, element);
        }
    }
}
