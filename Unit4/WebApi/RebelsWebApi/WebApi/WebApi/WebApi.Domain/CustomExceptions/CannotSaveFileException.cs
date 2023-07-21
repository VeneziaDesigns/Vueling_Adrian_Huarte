using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.CustomExceptions
{
    public class CannotSaveFileException : Exception
    {
        public CannotSaveFileException(string message) : base(message) { }

        public CannotSaveFileException()
        {

        }
    }
}
