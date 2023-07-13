using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RecetasDomain.DomainEntities;
using RecetasDomain.RepositoryContracts;
using RecetasRepository.DataModels;

namespace RecetasRepository.RepositoryImplementations
{
    public class PriceIngredientsRepository : IPriceIngredientsRepository
    {
        private readonly string? _priceOfIngredientsPath;

        public PriceIngredientsRepository(IConfiguration configuration)
        {
            _priceOfIngredientsPath = configuration.GetSection("DbSettings:AlimentosRepository").Value;
        }

        public List<PricesInfo> GetPriceOfIngredients()
        {
            string? json = File.ReadAllText(_priceOfIngredientsPath);

            List<PricesOfIngredientsFromJson>? listOfPricesFromJson = JsonSerializer.Deserialize<List<PricesOfIngredientsFromJson>>(json);

            return listOfPricesFromJson.Select(dataFromJson => new PricesInfo
            {
                Name = dataFromJson.Name,
                Price = dataFromJson.Price,
            }).ToList();
        }
    }
}
