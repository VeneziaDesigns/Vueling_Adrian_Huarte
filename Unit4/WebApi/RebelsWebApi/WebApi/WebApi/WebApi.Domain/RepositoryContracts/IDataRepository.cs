using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.DomainEntities;

namespace WebApi.Domain.RepositoryContracts
{
    public interface IDataRepository
    {
        // Como no necesitamos que el repositorio se conecte con niguna capa inferior no 
        // necesitamos un constructor que pase por inyeccion de dependencia ningun parametro

        void Insert(Data datos);
    }
}
