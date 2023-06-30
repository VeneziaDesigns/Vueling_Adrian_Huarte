using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireInfrastructure
{
    public interface IPokemonRepository
    {
        Task<List<string>> GetAttackName();
        Task<List<string>> GetPokemonListByType(string type);
        Task<List<string>> GetTypePokemonList();
    }
}