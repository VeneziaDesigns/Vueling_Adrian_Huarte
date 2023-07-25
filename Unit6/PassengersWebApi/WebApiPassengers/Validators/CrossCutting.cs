using System;
using System.Text.RegularExpressions;

namespace Validators
{
    public class CrossCutting
    {
        public static bool FlightValidator(string flightId)
        {
            string pattern = @"^FL\d{3}$";

            bool isValid = Regex.IsMatch(flightId, pattern, RegexOptions.IgnoreCase);

            return isValid;
        }

        public static bool TypeBaggage(string baggageType)
        {
            return baggageType.Equals("carry-on", StringComparison.OrdinalIgnoreCase) ||
                   baggageType.Equals("carry on", StringComparison.OrdinalIgnoreCase) ||
                   baggageType.Equals("personal", StringComparison.OrdinalIgnoreCase) ||
                   baggageType.Equals("checked", StringComparison.OrdinalIgnoreCase);
        }
    }
}
