using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeAPIManagement.Data.DataEntities;
using PokeAPIManagement.Domain.RepositoryContracts;

namespace PokeAPIManagement.Data.RepositoryImplementations
{
    public class PokemonTypesRepository : IPokemonTypesRepository
    {
        public async Task<List<string>> GetTypeIdList()
        {
            HttpClient httpClient = new HttpClient();

            // Obtencion de la constante url a partir del archivo Web.config pasando como para metro la key
            string urlTypes = ConfigurationManager.AppSettings["TypeFire"];

            HttpResponseMessage resultFromURL = await httpClient.GetAsync(urlTypes);

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            PokemonTypeFireEntity resultFromURLAsDataEntity = JsonConvert.DeserializeObject<PokemonTypeFireEntity>(resultFromURLAsString);

            // map data entity to domain entity
            List<string> result = resultFromURLAsDataEntity.moves.Select(movement => movement.url.TrimEnd('/').Split('/').Last()).ToList();

            return result;
        }

        public async Task<List<string>> GetPokemonsByType(string type)
        {
            HttpClient httpClient = new HttpClient();

            // Obtencion de la constante url a partir del archivo Web.config pasando como para metro la key
            string urlTypes = ConfigurationManager.AppSettings["GetByType"];

            HttpResponseMessage resultFromURL = await httpClient.GetAsync($"{urlTypes}/{type}");

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            PokemonTypeFireEntity resultFromURLAsDataEntity = JsonConvert.DeserializeObject<PokemonTypeFireEntity>(resultFromURLAsString);

            // map data entity to domain entity
            List<string> pokemonsByType = new List<string>();

            foreach (var result in resultFromURLAsDataEntity.pokemon)
            {
                pokemonsByType.Add(result.pokemon.name);
            }

            return pokemonsByType;
        }

        public async Task<List<string>> GetPokeTypes()
        {
            HttpClient httpClient = new HttpClient();

            // Obtencion de la constante url a partir del archivo Web.config pasando como para metro la key
            string urlTypes = ConfigurationManager.AppSettings["GetByType"];

            HttpResponseMessage resultFromURL = await httpClient.GetAsync(urlTypes);

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            PokeTypesEntities resultFromURLAsDataEntity = JsonConvert.DeserializeObject<PokeTypesEntities>(resultFromURLAsString);

            List<string> namesOfTypes = new List<string>();

            foreach (var result in resultFromURLAsDataEntity.results)
            {
                namesOfTypes.Add(result.name);
            }

            return namesOfTypes;
        }
    }
}
