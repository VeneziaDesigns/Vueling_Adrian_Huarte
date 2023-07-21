using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpatialCoordinatesDomain.CustomExceptions
{
    public class InvalidCoordXException : Exception
    {
        public InvalidCoordXException()
        {
        }

        public InvalidCoordXException(string message) : base(message) { }
    }
}
