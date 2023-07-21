using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.DomainEntities.ServiceContracts;
using WebApi.Domain.RepositoryContracts;

namespace WebApi.Domain.DomainEntities.ServiceImplementations
{
    public class DataServices : IDataServices
    {
        private readonly IDataRepository _repository;

        public DataServices(IDataRepository repository)
        {
            _repository = repository;
        }

        public void Register(Data datos)
        {
            _repository.Insert(datos);
        }
    }
}
