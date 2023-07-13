using System.Text.Json.Serialization;

namespace Domain.DomainEntities
{
    public class Baggage
    {
        public string? BaggageId { get; set; }
        public string? PassengerId { get; set; }
        public decimal Weight { get; set; }
        public string? BaggageType { get; set; }
    }
}
