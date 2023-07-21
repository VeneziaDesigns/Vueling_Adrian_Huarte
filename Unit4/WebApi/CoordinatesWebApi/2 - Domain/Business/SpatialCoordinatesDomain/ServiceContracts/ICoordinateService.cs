using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialCoordinatesDomain.IContracts
{
    public interface ICoordinateService
    {
        void Register(Coordinates coords);
    }
}
