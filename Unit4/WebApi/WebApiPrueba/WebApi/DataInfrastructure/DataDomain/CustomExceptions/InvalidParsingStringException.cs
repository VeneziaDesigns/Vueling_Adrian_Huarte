using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.CustomExceptions
{
    public class InvalidParsingStringException : Exception
    {
        public InvalidParsingStringException()
        {
        }

        public InvalidParsingStringException(string message) : base(message)
        {
        }
    }
}
