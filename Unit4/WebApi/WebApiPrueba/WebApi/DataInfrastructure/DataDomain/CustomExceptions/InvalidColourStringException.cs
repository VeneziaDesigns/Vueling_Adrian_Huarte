using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.CustomExceptions
{
    public class InvalidColourStringException : Exception
    {
        public InvalidColourStringException()
        {
        }

        public InvalidColourStringException(string message) : base(message)
        {
        }
    }
}
