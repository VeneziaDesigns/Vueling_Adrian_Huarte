using Domain.DomainEntities;
using Domain.DTOs;
using Domain.DTOs.Request;

namespace Domain.DomainServices
{
    public class InfoToFill
    {
        public static List<PassengersByFlightDateResponse> FillAllPassengerByDate(List<PassengersInfo> passengersInfo, 
                                                     List<BaggagesInfo> baggagesInfo, List<FlightsInfo> flightsInfo)
        {
            List<PassengersByFlightDateResponse> result = new();

            result = flightsInfo.GroupBy(flight => flight.FlightDate)
                .Select(group => new PassengersByFlightDateResponse
                {
                    Day = group.Key,
                    Flights = group.Select(flight => new FlightsPerDay
                    {
                        FlightId = flight.FlightId,
                        Journey = $"From {flight.Departure} to {flight.Arrival}",
                        Passengers = passengersInfo.Where(passenger => passenger.FlightId == flight.FlightId)
                            .Select(passenger => new GetAllPassengersByDate
                            {
                                Name = passenger.Name,
                                Surname = passenger.Surname,
                                CarryOn = baggagesInfo.Any(b => b.PassengerId == passenger.PassengerId && b.BaggageType == "Carry-on" && b.Weight <= 10)

                            }).ToList()

                    }).ToList()

                }).ToList();

            return result;
        }

        public static TotalPassengersAndWeightFillByFlight FillTotalWeightAndTotalBaggageWeightByDay(List<PassengersInfo> passengersInfo,
                                                     List<BaggagesInfo> baggagesInfo, List<FlightsInfo> flightsInfo)
        {
            TotalPassengersAndWeightFillByFlight result = new()
            {
                PassengersNumber = passengersInfo.Count,
                TotalWeight = baggagesInfo.Sum(b => b.Weight) + passengersInfo.Sum(p => p.Weight),
                FlightsWeightBaggage = flightsInfo.Select(flight => new TotalWeightByFlight
                {
                    Day = flight.FlightDate,
                    FlightId = flight.FlightId,
                    Journey = $"From {flight.Departure} to {flight.Arrival}",
                    PassengersNumber = passengersInfo.Where(p => p.FlightId == flight.FlightId).Count(),
                    TotalWeight = baggagesInfo.Where(b => passengersInfo.Any(p => p.PassengerId == b.PassengerId &&
                                                                p.FlightId == flight.FlightId)).Sum(b => b.Weight)
                }).ToList()
            };

            return result;
        }

        public static List<AverageWeightByFlightResponse> FillAverageWeightByFlight(List<PassengersInfo> passengersInfo,
                                                     List<BaggagesInfo> baggagesInfo, List<FlightsInfo> flightsInfo)
        {
            List<AverageWeightByFlightResponse> result = new();

            result = flightsInfo.GroupBy(flight => flight.FlightDate)
                .Select(group => new AverageWeightByFlightResponse
                {
                    Day = group.Key,
                    Flights = group.Select(flight => new AverageWeight
                    {
                        FlightId = flight.FlightId,
                        Journey = $"From {flight.Departure} to {flight.Arrival}",
                        PassengersAverageWeight = Math.Round(passengersInfo.Average(p => p.Weight), 2),
                        BaggageAverageWeight = Math.Round(baggagesInfo.Average(b => b.Weight), 2)

                    }).ToList()

                }).ToList();

            return result;
        }

        public static TotalWeightByFlightFillResponse FillTotalWeightByBaggageType(List<PassengersInfo> passengersInfo,
                                                  List<BaggagesInfo> baggagesInfo, string FlightId, string BaggageType)
        {
            List<PassengersInfo> passerngersOfFligth = passengersInfo.Where(p => p.FlightId == FlightId.ToUpper()).ToList();

            TotalWeightByFlightFillResponse baggageOfPassengersByFlight = new()
            {
                TotalWeight = baggagesInfo.Where(b => passerngersOfFligth.Any(p => p.PassengerId == b.PassengerId && b.BaggageType.ToLower() == BaggageType.ToLower())).Sum(b => b.Weight)
            };

            return baggageOfPassengersByFlight;
        }
    }
}
