using RecetasDomain.DomainEntities;

namespace RecetasDomain.RepositoryContracts
{
    public interface IRecipeRepository
    {
        RecipesInfo GetRecipe(string? recipeToSearch);
    }
}
