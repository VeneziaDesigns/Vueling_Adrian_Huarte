using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireDomain
{
    public interface IFireService
    {
        Task<List<string>> GetFireTypes();
        Task<List<string>> GetPokemon(string type);
        Task<List<string>> GetTypes();
    }
}