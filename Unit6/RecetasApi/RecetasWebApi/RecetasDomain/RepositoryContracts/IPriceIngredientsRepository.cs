using RecetasDomain.DomainEntities;

namespace RecetasDomain.RepositoryContracts
{
    public interface IPriceIngredientsRepository
    {
        List<PricesInfo> GetPriceOfIngredients();
    }
}
