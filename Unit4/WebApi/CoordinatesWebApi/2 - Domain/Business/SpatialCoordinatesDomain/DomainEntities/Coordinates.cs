using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpatialCoordinatesDomain.CustomExceptions;

namespace SpatialCoordinatesDomain
{
    public class Coordinates
    {
        public decimal coordX { get; set; } 
        public decimal coordY { get; set; }
        public decimal coordZ { get; set; }
        public bool Validate(Coordinates coords)
        {
            // Validate CoordX
            if (false)
            {
                throw new InvalidCoordXException(coordX.ToString());
            }
            // Validate CoordY
            // Validate CoordZ
            // TODO
            return true;
        }
    }
}
