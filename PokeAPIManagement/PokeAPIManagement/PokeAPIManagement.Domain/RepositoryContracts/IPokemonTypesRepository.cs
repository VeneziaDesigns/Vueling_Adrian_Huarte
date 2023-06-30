using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIManagement.Domain.RepositoryContracts
{
    public interface IPokemonTypesRepository
    {
        Task<List<string>> GetTypeIdList();

        Task<List<string>> GetPokemonsByType(string type);

        Task<List<string>> GetPokeTypes();
    }
}
