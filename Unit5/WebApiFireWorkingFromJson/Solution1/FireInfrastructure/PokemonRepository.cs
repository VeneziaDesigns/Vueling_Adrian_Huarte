using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FireInfrastructure
{
    public class PokemonRepository : IPokemonRepository
    {
        private const string TypeFireUrl = "https://pokeapi.co/api/v2/type/fire";
        private const string PokemonByType = "https://pokeapi.co/api/v2/type/";

        public async Task<List<string>> GetAttackName()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage resultFromURL = await httpClient.GetAsync(TypeFireUrl);

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            // Deserializar el json y obtener el nombre de tipo fuego
            JObject responseJson = JObject.Parse(resultFromURLAsString);

            // Obtener los primeros 10 nombres de los ataques de fuego
            var fireTypeAttacks = responseJson["moves"].Take(10);

            List<string> fireTypeAttackNamesInSpanish = new List<string>();

            // Recorrer los movimientos y obtener el nombre en español
            foreach (var attack in fireTypeAttacks)
            {
                string attackUrl = (string)attack["url"];
                HttpResponseMessage attackResult = await httpClient.GetAsync(attackUrl);
                string attackResultAsString = await attackResult.Content.ReadAsStringAsync();
                JObject attackJson = JObject.Parse(attackResultAsString);
                var attackNames = attackJson["names"];

                // Buscar el nombre en español en la lista de nombres
                var spanishName = attackNames.FirstOrDefault(name => (string)name["language"]["name"] == "es");
                if (spanishName != null)
                {
                    string attackNameInSpanish = (string)spanishName["name"];
                    fireTypeAttackNamesInSpanish.Add(attackNameInSpanish);
                }
            }

            return fireTypeAttackNamesInSpanish;
        }

        public async Task<List<string>> GetPokemonListByType(string type)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage resultFromURL = await httpClient.GetAsync(PokemonByType);

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            // Deserializar el json y obtener todos los tipos
            JObject responseJson = JObject.Parse(resultFromURLAsString);

            var result = responseJson["results"].FirstOrDefault(x => (string)x["name"] == type);

            if (result != null)
            {
                string urlType = result["url"].ToString();

                // Obtener los datos del tipo de Pokémon
                HttpResponseMessage typeResponse = await httpClient.GetAsync(urlType);
                string typeResponseString = await typeResponse.Content.ReadAsStringAsync();
                JObject typeJson = JObject.Parse(typeResponseString);

                // Obtener la lista de nombres de Pokémon asociados al tipo
                List<string> pokemonNames = typeJson["pokemon"]
                    .Select(p => (string)p["pokemon"]["name"])
                    .ToList();

                return pokemonNames;
            }

            return null;
        }

        public async Task<List<string>> GetTypePokemonList()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage resultFromURL = await httpClient.GetAsync(PokemonByType);

            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            // Deserializar el json
            JObject responseJson = JObject.Parse(resultFromURLAsString);

            //Obtenemos todos los tipos de Pokemons
            List<string> types = new List<string>();

            foreach (var result in responseJson["results"])
            {
                string name = (string)result["name"];
                types.Add(name);
            }

            return types;
        }
    }
}
