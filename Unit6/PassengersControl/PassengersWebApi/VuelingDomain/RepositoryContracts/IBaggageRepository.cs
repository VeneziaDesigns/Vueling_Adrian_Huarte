using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingDomain.DomainEntities;

namespace VuelingDomain.RepositoryContracts
{
    public interface IBaggageRepository
    {
        List<Baggages>? GetBaggageInfo(); 
    }
}
