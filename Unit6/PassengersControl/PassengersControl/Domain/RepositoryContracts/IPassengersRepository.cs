using Domain.DomainEntities;

namespace Domain.RepositoryContracts
{
    public interface IPassengersRepository
    {
        List<Passengers>? GetPassengersInfo();
    }
}
