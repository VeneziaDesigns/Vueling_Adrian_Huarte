using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuelingServices.DTOs;
using VuelingServices.ServiceContracts;

namespace ApiVueling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly ILogger<PassengersController> _logger;
        private readonly IVuelingService _service;

        public PassengersController(ILogger<PassengersController> logger, IVuelingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("GetAllPassengersByDate")]
        public IActionResult GetAllPassengersByDate()
        {
            try
            {
                List<PassengersWithCarryOnDTO>? result = _service.GetAllPassengersByDate();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
