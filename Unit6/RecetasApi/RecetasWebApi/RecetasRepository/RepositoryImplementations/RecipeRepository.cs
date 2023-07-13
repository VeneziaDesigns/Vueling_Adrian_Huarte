using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RecetasDomain.CustomExceptions;
using RecetasDomain.DomainEntities;
using RecetasDomain.RepositoryContracts;
using RecetasRepository.DataModels;

namespace RecetasRepository.RepositoryImplementations
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string? _recipePath;

        public RecipeRepository(IConfiguration configuration)
        {
            _recipePath = configuration.GetSection("DbSettings:Recetas").Value;
        }

        public RecipesInfo GetRecipe(string? recipeToSearch)
        {
            string? json = File.ReadAllText(_recipePath);

            List<RecipeFromJson>? recipesData = JsonSerializer.Deserialize<List<RecipeFromJson>>(json);

            RecipesInfo? recipeinfo = MapToDomainEntity(recipesData, recipeToSearch);
            
            if (recipeinfo != null) return recipeinfo;

            throw new NotRecipeException("The recipe is not in data base");
        }

        public static RecipesInfo MapToDomainEntity(List<RecipeFromJson>? recipes, string? recipeToSearch)
        {
            foreach (RecipeFromJson recipe in recipes)
            {
                if (recipe.Name.ToLower().Equals(recipeToSearch.ToLower()))
                {
                    RecipesInfo recipeInfo = new()
                    {
                        Name = recipe.Name,
                        Ingredients = recipe.Ingredients,
                        TimeMinutes = recipe.TimeMinutes,
                    };

                    return recipeInfo;
                }
            }

            return null;
        }
    }
}
