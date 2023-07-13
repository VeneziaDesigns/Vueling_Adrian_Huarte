using RecetasDomain.DomainEntities;

namespace RecetasDomain.RepositoryContracts
{
    public interface IPriceForCookingRepository
    {
        PriceTimeInfo GetPriceForCooking();
    }
}
