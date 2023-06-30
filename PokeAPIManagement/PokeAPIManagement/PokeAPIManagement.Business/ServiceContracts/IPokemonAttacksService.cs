using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIManagement.Business.ServiceContracts
{
    public interface IPokemonAttacksService
    {
        Task<List<string>> GetTopTenFireAttackNamesInSpanish();

        Task<List<string>> GetPokemon(string type);

        Task<List<string>> GetTypes();
    }
}
