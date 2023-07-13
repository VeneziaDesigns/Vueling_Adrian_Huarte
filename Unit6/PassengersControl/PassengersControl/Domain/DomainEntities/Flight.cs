using System.Text.Json.Serialization;

namespace Domain.DomainEntities
{
    public class Flight
    {
        public string? FlightId { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime FlightDateWithoutHour { get; set; }
    }
}
