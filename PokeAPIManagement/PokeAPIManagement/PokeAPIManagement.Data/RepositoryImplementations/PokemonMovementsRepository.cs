using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeAPIManagement.Data.DataEntities;
using PokeAPIManagement.Domain.DomainEntities;
using PokeAPIManagement.Domain.RepositoryContracts;

namespace PokeAPIManagement.Data.RepositoryImplementations
{
    public class PokemonMovementsRepository : IPokemonMovementsRepository
    {

        public async Task<MovementLanguageInfoList> GetMovementLanguageInfoById(string movementId)
        {
            HttpClient httpClient = new HttpClient();

            // Obtencion de la constante url a partir del archivo Web.config pasando como para metro la key
            string urlTypes = ConfigurationManager.AppSettings["Moves"];

            HttpResponseMessage resultFromURL = await httpClient.GetAsync($"{urlTypes}/{movementId}");

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            PokemonMovementEntity resultFromURLAsDataEntity = null;
            resultFromURLAsDataEntity = JsonConvert.DeserializeObject<PokemonMovementEntity>(resultFromURLAsString);

            // map data entity to domain entity
            MovementLanguageInfoList result = new MovementLanguageInfoList
            {
                MovementLanguageInfo = resultFromURLAsDataEntity.names.Select(nameFromJson => new MovementLanguageInfo
                {
                    LanguageName = nameFromJson.language.name,
                    MovementName = nameFromJson.name,
                }).ToList()
            };

            return result;
        }
    }
}
