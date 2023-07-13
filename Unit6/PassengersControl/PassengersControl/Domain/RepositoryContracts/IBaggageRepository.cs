using Domain.DomainEntities;

namespace Domain.RepositoryContracts
{
    public interface IBaggageRepository
    {
        List<Baggage>? GetBaggageInfo();
    }
}
