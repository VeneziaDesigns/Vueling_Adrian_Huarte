using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.DomainEntities.ServiceContracts
{
    public interface IDataServices
    {
        void Register(Data datos);
    }
}
