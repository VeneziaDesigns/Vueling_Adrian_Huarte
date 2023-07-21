using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeAPIManagement.Business.ServiceContracts;
using PokeAPIManagement.Data.RepositoryImplementations.SecurityCopy;
using PokeAPIManagement.Domain.DomainEntities;
using PokeAPIManagement.Domain.RepositoryContracts;

namespace PokeAPIManagement.Business.ServiceImplementations
{
    public class PokemonService : IPokemonAttacksService
    {
        private readonly IPokemonTypesRepository _pokemonTypesRepository;
        private readonly IPokemonMovementsRepository _pokemonMovementsRepository;
        private readonly ISecurityImplementation _securityImplementation;
        public PokemonService(IPokemonTypesRepository pokemonTypesRepository,
            IPokemonMovementsRepository pokemonMovementsRepository,
            ISecurityImplementation securityImplementation)
        {
            _pokemonTypesRepository = pokemonTypesRepository;
            _pokemonMovementsRepository = pokemonMovementsRepository;
            _securityImplementation = securityImplementation;
        }

        public async Task<List<string>> GetTopTenFireAttackNamesInSpanish()
        {
            //Task.WaitAll(_repository.GetTypesInfo());
            List<string> typeIdList = await _pokemonTypesRepository.GetTypeIdList();

            List<string> result = new List<string>();

            typeIdList = typeIdList.Take(10).ToList();
            foreach (var typeId in typeIdList)
            {
                MovementLanguageInfoList movementLanguageInfo = await _pokemonMovementsRepository.GetMovementLanguageInfoById(typeId);
                string movementSpanishName = movementLanguageInfo.GetMovementNameByLanguageId("es");
                result.Add(movementSpanishName);
            }

            _securityImplementation.SecurityCopy(result);

            return result;
        }

        public async Task<List<string>> GetPokemon(string type)
        {
            //Task.WaitAll(_repository.GetTypesInfo());
            List<string> result = await _pokemonTypesRepository.GetPokemonsByType(type);

            result.Sort();

            _securityImplementation.SecurityCopy(result);

            return result;
        }

        public async Task<List<string>> GetTypes()
        {
            //Task.WaitAll(_repository.GetTypesInfo());
            List<string> result = await _pokemonTypesRepository.GetPokeTypes();

            result.Sort();

            _securityImplementation.SecurityCopy(result);

            return result;
        }
    }
}
