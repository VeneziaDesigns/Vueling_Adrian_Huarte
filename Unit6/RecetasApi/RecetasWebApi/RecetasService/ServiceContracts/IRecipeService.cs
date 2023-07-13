using RecetasService.RecipeDTO;

namespace RecetasService.ServiceContracts
{
    public interface IRecipeService
    {
        RecipeDTOs PriceOfRecipe(string recipe);
    }
}
