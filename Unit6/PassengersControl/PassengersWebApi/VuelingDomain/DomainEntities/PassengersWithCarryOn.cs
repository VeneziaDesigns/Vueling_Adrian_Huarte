using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingDomain.DomainEntities
{
    public class PassengersWithCarryOn
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Flight { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime DateOfFlight { get; set; }
        public bool CarryOn { get; set; }
    }
}
