using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs
{
    public class PassengersWithCarryOnDTO
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
