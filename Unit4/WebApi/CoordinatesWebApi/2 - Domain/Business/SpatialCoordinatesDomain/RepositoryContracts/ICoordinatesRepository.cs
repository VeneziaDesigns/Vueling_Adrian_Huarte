using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialCoordinatesDomain.RepositoryContracts
{
    public interface ICoordinatesRepository
    {
        void Insert(Coordinates coords);
    }
}
