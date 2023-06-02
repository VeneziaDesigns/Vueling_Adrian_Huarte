using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Parsing
    {
        public (bool, decimal) TryParseDecimalValue(string stringToParse)
        {
            //separador decimal específico para la configuración regional en la que se está ejecutando el código.
            string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            bool isParseable = decimal.TryParse(stringToParse.Replace(".", decimalSeparator).Replace(",", decimalSeparator), out decimal parsedDecimal);
            return (isParseable, parsedDecimal);
        }

        public (bool, int) TryParseIntValue(string stringToParse)
        {
            bool isParseable = int.TryParse(stringToParse, out int parsedInt);
            return (isParseable, parsedInt);
        }
    }
}
