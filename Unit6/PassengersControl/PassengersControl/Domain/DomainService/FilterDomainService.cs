using Domain.DomainEntities;
using DTOs.DTOs;

namespace Domain.DomainServices
{
    public class FilterDomainService
    {
        public static List<PassengersWithCarryOnDTO>? FilterPassengersByCarryOn(List<Passengers>? allPassengersInfo, List<Baggage>? allBaggagesInfo, List<Flight>? allFlightsInfo)
        {
            List<PassengersWithCarryOnDTO>? result = allPassengersInfo?
                .Where(p => allBaggagesInfo.Any(b => b.PassengerId == p.PassengerId && b.BaggageType == "Carry-on" && b.Weight <= 10) &&
                            allFlightsInfo.Any(f => f.FlightId == p.FlightId))
                .Select(p => new PassengersWithCarryOnDTO
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Flight = p.FlightId,
                    Departure = allFlightsInfo.FirstOrDefault(f => f.FlightId == p.FlightId)?.Departure,
                    Arrival = allFlightsInfo.FirstOrDefault(f => f.FlightId == p.FlightId)?.Arrival,
                    DateOfFlight = allFlightsInfo.FirstOrDefault(f => f.FlightId == p.FlightId)?.FlightDateWithoutHour ?? DateTime.MinValue,
                    CarryOn = true
                }).ToList();

            return result;
        }
    }
}
