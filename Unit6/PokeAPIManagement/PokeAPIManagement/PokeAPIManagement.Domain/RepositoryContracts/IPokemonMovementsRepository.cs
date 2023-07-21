using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeAPIManagement.Domain.DomainEntities;

namespace PokeAPIManagement.Domain.RepositoryContracts
{
    public interface IPokemonMovementsRepository
    {
        Task<MovementLanguageInfoList> GetMovementLanguageInfoById(string movementId);
    }
}
