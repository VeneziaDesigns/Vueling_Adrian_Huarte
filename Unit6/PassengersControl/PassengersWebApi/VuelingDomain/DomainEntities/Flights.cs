using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingDomain.DomainEntities
{
    public class Flights
    {
        public string? FlightId { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime FlightDateWithoutHour { get; set; }
    }
}
