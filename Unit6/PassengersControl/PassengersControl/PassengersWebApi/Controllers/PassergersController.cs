using Business.ServiceContracts;
using DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PassengersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassergersController : ControllerBase
    {
        private readonly IPassengersService _service;

        public PassergersController(IPassengersService service)
        {
            _service = service;
        }

        [HttpGet("Passenger list by flight")]
        public IActionResult GetPassengersListByFlight()
        {
            try
            {
                List<PassengersWithCarryOnDTO> getPassengersListByFlight = _service.GetAllInformation();

                return Ok(getPassengersListByFlight);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Total passengers and baggage of all flights per day 'Kg'")]
        public IActionResult TotalPassengersAndBaggageOfAllFlightsPerDayKg()
        {
            return Ok();
        }

        [HttpGet("Average kg 'passengers + baggage' per flight number")]
        public IActionResult AverageKgPassengersAndBaggagePerFlightNumber()
        {
            return Ok();
        }
    }
}
