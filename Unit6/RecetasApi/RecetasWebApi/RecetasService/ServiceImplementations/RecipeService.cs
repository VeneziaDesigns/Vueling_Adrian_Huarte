using RecetasDomain.DomainEntities;
using RecetasDomain.DomainServices;
using RecetasDomain.RepositoryContracts;
using RecetasService.RecipeDTO;
using RecetasService.ServiceContracts;

namespace RecetasService.ServiceImplementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IPriceIngredientsRepository _priceIngredientsRepository;
        private readonly IPriceForCookingRepository _priceForCookingRepository;

        public RecipeService(IRecipeRepository recipeRepository, 
                    IPriceIngredientsRepository priceIngredientsRepository,
                    IPriceForCookingRepository priceForCookingRepository)
        {
            _recipeRepository = recipeRepository;
            _priceIngredientsRepository = priceIngredientsRepository;
            _priceForCookingRepository = priceForCookingRepository;
        }

        public RecipeDTOs PriceOfRecipe(string recipe)
        {
            RecipesInfo quantityIngredientsAndTimeOfCooking = _recipeRepository.GetRecipe(recipe);

            List<PricesInfo> pricesIngredientsList = _priceIngredientsRepository.GetPriceOfIngredients();

            PriceTimeInfo priceForMinute = _priceForCookingRepository.GetPriceForCooking();

            decimal? finalPrice = CalcPriceOfRecipe.PriceOfIngredients(quantityIngredientsAndTimeOfCooking, pricesIngredientsList)
                            + CalcPriceOfRecipe.PriceOfCooked(quantityIngredientsAndTimeOfCooking, priceForMinute);

            RecipeDTOs recipePrice = new()
            {
                Name = quantityIngredientsAndTimeOfCooking.Name,
                Price = Math.Round (finalPrice ?? 0, 2)
            };

            return recipePrice;
        }
    }
}
