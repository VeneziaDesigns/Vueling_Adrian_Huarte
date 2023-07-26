using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Request;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Validators;

namespace WebApiControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly ILogger<PassengersController> _logger;
        private readonly IControlService _service;

        public PassengersController(ILogger<PassengersController> logger, IControlService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetAllPassengersByDate")]
        public async Task<IActionResult> GetAllPassengersByDate()
        {
            try
            {
                List<PassengersByFlightDateResponse> response = await _service.GetAllPassengersByDate();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetTotalWeightAndTotalBaggageWeightByDay")]
        public async Task<IActionResult> GetTotalWeightAndTotalBaggageWeightByDay()
        {
            try
            {
                TotalPassengersAndWeightFillByFlight response = await _service.GetTotalWeightAndTotalBaggageWeightByDay();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAverageWeightByFlight")]
        public async Task<IActionResult> GetAverageWeightByFlight()
        {
            try
            {
                List<AverageWeightByFlightResponse> response = await _service.GetAverageWeightByFlight();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetTotalWeightByBaggageType")]
        public async Task<IActionResult> GetTotalWeightByBaggageType([Required] string FlightId, [Required] string BaggageType)
        {
            try
            {
                bool validFlightId = CrossCutting.FlightValidator(FlightId);
                bool validBaggageType = CrossCutting.TypeBaggage(BaggageType);

                if (validFlightId && validBaggageType)
                {
                    TotalWeightByFlightFillResponse response = await _service.GetTotalWeightByBaggageType(FlightId, BaggageType);

                    if (response.TotalWeight != 0) return Ok(response);

                    else return Ok($"{FlightId} or {BaggageType} does not correspond to any available data");
                }
 
                return Ok($"{FlightId} or {BaggageType} are not in the correct format");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
