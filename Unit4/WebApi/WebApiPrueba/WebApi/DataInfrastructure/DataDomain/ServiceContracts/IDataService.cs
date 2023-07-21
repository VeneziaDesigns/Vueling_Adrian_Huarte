using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain.DomainEntities;

namespace DataDomain.ServiceContracts
{
    public interface IDataService
    {
        void Register(Datos cadenas);
    }
}
