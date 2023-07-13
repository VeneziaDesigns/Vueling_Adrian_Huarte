using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RecetasDomain.CustomExceptions;
using RecetasService.RecipeDTO;
using RecetasService.ServiceContracts;

namespace ApiRecetas.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecetaController(IRecipeService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpGet("Recipe")]
        public IActionResult SelectRecipe([Required] string recipe)
        {
            try
            {
                RecipeDTOs recipePrice = _service.PriceOfRecipe(recipe);

                return Ok(recipePrice);
            }
            catch (NotRecipeException ex)
            {
                return Ok(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
