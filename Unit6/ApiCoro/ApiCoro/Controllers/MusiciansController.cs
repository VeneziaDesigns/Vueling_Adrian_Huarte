using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MusicianDomain.CustomExceptions;
using MusicianService.ServiceContracts;
using MusiciansManagement.DTOs;
using Newtonsoft.Json;

namespace ApiCoro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        public readonly ICoroService _service;
        private readonly ILogger<MusiciansController> _logger;

        public MusiciansController(ICoroService service, ILogger<MusiciansController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Selects a conbination of musicians for the meeting in the given date
        /// </summary>
        /// <param name="concertDate">Date of meeting</param>
        /// <returns></returns>
        [Route("Concierto")]
        [HttpGet]
        public IActionResult GetConcert([Required] string concertDate)
        {
            try
            {
                List<MusicianDTO> musiciansToConcert = _service.GetConcert(concertDate);

                return Ok(musiciansToConcert);
            }
            catch (ResourceNotAvailableException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                _logger.LogError("Something went wrong");
                return BadRequest("Something went wrong");
            }
        }
    }
}
