using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RecetasDomain.DomainEntities;
using RecetasDomain.RepositoryContracts;
using RecetasRepository.DataModels;

namespace RecetasRepository.RepositoryImplementations
{
    public class PriceForCookingRepository : IPriceForCookingRepository
    {
        private readonly string? _priceForCookingPath;

        public PriceForCookingRepository(IConfiguration configuration)
        {
            _priceForCookingPath = configuration.GetSection("DbSettings:PrecioCocinado").Value;
        }

        public PriceTimeInfo GetPriceForCooking()
        {
            string? json = File.ReadAllText(_priceForCookingPath);

            PriceByMinuteFromJson? priceFromJson = JsonSerializer.Deserialize<PriceByMinuteFromJson>(json);

            PriceTimeInfo priceForMinute = new()
            {
                Price = priceFromJson.Price
            };

            return priceForMinute;
        }
    }
}
