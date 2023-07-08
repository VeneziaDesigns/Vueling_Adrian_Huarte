using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianDomain.CustomExceptions
{
    public class ResourceNotAvailableException : Exception
    {
        public ResourceNotAvailableException(string message) : base(message) { }

        public ResourceNotAvailableException()
        {

        }
    }
}
