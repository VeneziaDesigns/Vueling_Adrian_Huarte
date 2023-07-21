using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingDomain.DomainEntities;
using VuelingDomain.DomainServices;
using VuelingDomain.RepositoryContracts;
using VuelingServices.DTOs;
using VuelingServices.ServiceContracts;

namespace VuelingServices.ServiceImplementations
{
    public class VuelingService : IVuelingService
    {
        private readonly IPassengersRepository _passengersRepository;
        private readonly IBaggageRepository _baggageRepository;
        private readonly IFlightRepository _flightRepository;

        public VuelingService(IPassengersRepository passengersRepository, IBaggageRepository baggageRepository, IFlightRepository flightRepository)
        {
            _passengersRepository = passengersRepository;
            _baggageRepository = baggageRepository;
            _flightRepository = flightRepository;
        }

        public List<PassengersWithCarryOnDTO>? GetAllPassengersByDate()
        {
            List<Passengers>? passengers = _passengersRepository.GetPassengersInfo();
            List<Baggages>? baggages = _baggageRepository.GetBaggageInfo();
            List<Flights>? flights = _flightRepository.GetFlightInfo();

            List<PassengersWithCarryOn>? passengersWithCarryOn = FilterByFlight.FilterPassengersByCarryOn(passengers, baggages, flights);

            List<PassengersWithCarryOnDTO>? passengersWithCarryOnDTO = MapToDto(passengersWithCarryOn);

            return passengersWithCarryOnDTO;
        }

        private static List<PassengersWithCarryOnDTO>? MapToDto(List<PassengersWithCarryOn>? passengersWithCarryOn)
        {
            List<PassengersWithCarryOnDTO> passengersWithCarryOnDTO = passengersWithCarryOn.Select(p => new PassengersWithCarryOnDTO
            {
                Name = p.Name,
                Surname = p.Surname,
                Departure = p.Departure,
                Arrival = p.Arrival,
                DateOfFlight = p.DateOfFlight,
                CarryOn = p.CarryOn,
            }).ToList();

            return passengersWithCarryOnDTO;
        }
    }
}
