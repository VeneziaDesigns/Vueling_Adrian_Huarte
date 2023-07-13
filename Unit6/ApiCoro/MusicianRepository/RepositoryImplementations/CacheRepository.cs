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
