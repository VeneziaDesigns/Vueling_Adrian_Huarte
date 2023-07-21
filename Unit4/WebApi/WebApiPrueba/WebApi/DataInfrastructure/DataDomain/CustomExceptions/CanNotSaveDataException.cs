using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.CustomExceptions
{
    public class CanNotSaveDataException : Exception
    {
        public CanNotSaveDataException()
        {
        }

        public CanNotSaveDataException(string message) : base(message)
        {
        }
    }
}
