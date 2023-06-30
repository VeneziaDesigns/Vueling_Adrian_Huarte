using CrudDomain.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using TestSQLServer.DomainEntities;

namespace CrudInfrastructure.Data.RepositoryImplementations
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<UserWorkers>? GetCache()
        {
            return _cache.Get<List<UserWorkers>>("users");
        }

        public bool SetCache(List<UserWorkers> cachingWorkers)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                .SetSlidingExpiration(TimeSpan.FromSeconds(20))
                .SetSize(1024);

            _cache.Set("users", cachingWorkers, cacheOptions);

            return true;
        }
    }
}
