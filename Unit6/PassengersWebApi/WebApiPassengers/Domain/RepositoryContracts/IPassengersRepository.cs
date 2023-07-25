using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainEntities;

namespace Domain.RepositoryContracts
{
    public interface IPassengersRepository
    {
        Task<List<PassengersInfo>> GetPassengersInfo();
    }
}
