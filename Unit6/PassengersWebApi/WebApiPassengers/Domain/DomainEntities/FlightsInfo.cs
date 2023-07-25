using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class FlightsInfo
    {
        public string? FlightId { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime FlightDate { get; set; }
    }
}
