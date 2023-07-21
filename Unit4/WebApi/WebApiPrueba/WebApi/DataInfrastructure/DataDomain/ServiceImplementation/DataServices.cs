using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain.DomainEntities;
using DataDomain.RepositoryContracts;
using DataDomain.ServiceContracts;

namespace DataDomain.ServiceImplementation
{
    public class DataServices : IDataService
    {
        public readonly IDataRepository _repository;

        public DataServices(IDataRepository repository)
        {
            _repository = repository;
        }

        public void Register(Datos cadenas)
        {
            cadenas.IsAColour(cadenas.Colour);
            cadenas.IsParseable(cadenas.IntParseable);


            _repository.Insert(cadenas);

        }
    }
}
