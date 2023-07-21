using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingDomain.DomainEntities
{
    public class Baggages
    {
        public string? BaggageId { get; set; }
        public string? PassengerId { get; set; }
        public decimal Weight { get; set; }
        public string? BaggageType { get; set; }
    }
}
