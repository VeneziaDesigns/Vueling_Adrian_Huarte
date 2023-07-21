using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingDomain.DomainEntities
{
    public class Passengers
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FlightId { get; set; }
        public string? PassengerId { get; set; }
        public decimal? Weight { get; set; }
    }
}
