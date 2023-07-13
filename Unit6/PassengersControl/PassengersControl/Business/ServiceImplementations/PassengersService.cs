using Business.ServiceContracts;
using Domain.DomainEntities;
using Domain.DomainServices;
using Domain.RepositoryContracts;
using DTOs.DTOs;

namespace Business.ServiceImplementations
{
    public class PassengersService : IPassengersService
    {
        private readonly IPassengersRepository _passengersRepository;
        private readonly IBaggageRepository _baggageRepository;
        private readonly IFlightRepository _flightRepository;

        public PassengersService(IPassengersRepository passengersRepository, IBaggageRepository baggageRepository,
                                                                             IFlightRepository flightRepository)
        {
            _passengersRepository = passengersRepository;
            _baggageRepository = baggageRepository;
            _flightRepository = flightRepository;
        }


        public List<PassengersWithCarryOnDTO> GetAllInformation()
        {
            List<Passengers>? allPassengersInfo = _passengersRepository.GetPassengersInfo();

            List<Baggage>? allBaggagesInfo = _baggageRepository.GetBaggageInfo();

            List<Flight>? allFlightsInfo = _flightRepository.GetFlightInfo();

            List<PassengersWithCarryOnDTO> getPassengersListByFlight = 
                FilterDomainService.FilterPassengersByCarryOn(allPassengersInfo, allBaggagesInfo, allFlightsInfo) ?? new List<PassengersWithCarryOnDTO>();

            return getPassengersListByFlight;
        }
    }
}
