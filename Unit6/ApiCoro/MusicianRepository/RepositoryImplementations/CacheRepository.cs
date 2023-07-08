using Microsoft.Extensions.Caching.Memory;
using MusicianDomain.DomainEntities;
using MusicianDomain.RepositoryContracts;

namespace MusicianRepository.RepositoryImplementations
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<Musicos>? GetCache()
        {
            return _cache.Get<List<Musicos>?>("musicians");
        }

        public void SetCache(List<Musicos>? musicians)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                .SetSlidingExpiration(TimeSpan.FromSeconds(20))
                .SetSize(1024);

            _cache.Set("musicians", musicians, cacheOptions);
        }
    }
}
