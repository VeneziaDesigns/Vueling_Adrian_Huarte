using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireInfrastructure;

namespace FireDomain
{
    public class FireService : IFireService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public FireService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<string>> GetFireTypes()
        {
            List<string> result = await _pokemonRepository.GetAttackName();

            return result;
        }
        public async Task<List<string>> GetPokemon(string type)
        {
            List<string> result = await _pokemonRepository.GetPokemonListByType(type);

            return result;
        }

        public async Task<List<string>> GetTypes()
        {
            List<string> result = await _pokemonRepository.GetTypePokemonList();

            return result;
        }
    }
}
