using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpatialCoordinatesDomain.CustomExceptions;
using SpatialCoordinatesDomain.IContracts;
using SpatialCoordinatesDomain.RepositoryContracts;

namespace SpatialCoordinatesDomain.ServiceImplementation
{
    public class CoordinatesServices : ICoordinateService
    {
        public readonly ICoordinatesRepository _repository;

        public CoordinatesServices(ICoordinatesRepository repository)
        {
            _repository = repository;
        }

        public void Register(Coordinates coords)
        {
            coords.Validate(coords);

            try
            {
                _repository.Insert(coords);
            }
            catch (Exception ex)
            {
                throw new CanNotSaveDataException(ex.Message);
            }
        }
    }
}
