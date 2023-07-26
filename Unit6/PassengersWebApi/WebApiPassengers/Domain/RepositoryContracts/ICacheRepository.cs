namespace Domain.RepositoryContracts
{
    public interface ICacheRepository
    {
        T? GetCache<T>(string key);
        void SetCache<T>(string key, T element);
    }
}
