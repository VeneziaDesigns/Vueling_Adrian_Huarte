using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingDomain.DomainEntities;

namespace VuelingDomain.DomainServices
{
    public class FilterByFlight
    {
        public static List<PassengersWithCarryOn>? FilterPassengersByCarryOn(List<Passengers>? allPassengersInfo, List<Baggages>? allBaggageInfo, List<Flights>? allFlightsInfo)
        {
            List<PassengersWithCarryOn>? result = new();

            result = allPassengersInfo?
                .Where(p => allBaggageInfo.Any(b => b.PassengerId == p.PassengerId && b.BaggageType == "Carry-on" && b.Weight <= 10) &&
                            allFlightsInfo.Any(f => f.FlightId == p.FlightId))
                .Select(p => new PassengersWithCarryOn
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
