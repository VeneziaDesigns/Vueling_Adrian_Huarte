using System.Text.Json.Serialization;

namespace Domain.DomainEntities
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
