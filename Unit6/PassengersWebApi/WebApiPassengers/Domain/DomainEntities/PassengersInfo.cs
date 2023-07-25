using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class PassengersInfo
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FlightId { get; set; }
        public string? PassengerId { get; set; }
        public decimal Weight { get; set; }
    }
}
