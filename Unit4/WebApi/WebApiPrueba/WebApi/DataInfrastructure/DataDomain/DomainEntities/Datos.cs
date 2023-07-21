using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DataDomain.CustomExceptions;

namespace DataDomain.DomainEntities
{
    public class Datos
    {
        public string Colour { get; set; }
        public string IntParseable { get; set; }
        public string Free { get; set; }
        public DateTime Date { get; set; }

        public void IsAColour(string colour)
        {
            if (!colour.ToLower().Equals("red") && !colour.ToLower().Equals("green") && !colour.ToLower().Equals("blue"))
            {
                throw new InvalidColourStringException("Invalid colour");
            }
            
        }

        public bool IsParseable(string num)
        {
            bool Parse = int.TryParse(num, out int value);

            if (Parse == false || value < 0 || value > 100)
            {
                return false;
                throw new InvalidParsingStringException("Invalid Parsing");
            }
            else
            {
                return true;
            }
        }
    }
}
