using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokeAPIManagement.Business.ServiceContracts;
using static PokeAPIManagement.Data.DataEntities.PokeTypesEntities;

namespace PokeAPIManagement.WebAPI.Controllers
{
    public class PokeAPIController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IPokemonAttacksService _service;
        public PokeAPIController(ILogger log, IPokemonAttacksService service)
        {
            _logger = log;
            _service = service;
        }

        [Route("GetTypeFire")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTopTenFireAttackNamesInSpanish()
        {
            List<string> result = await _service.GetTopTenFireAttackNamesInSpanish();

            string jsonResult = JsonConvert.SerializeObject(result);

            _logger.LogInformation(jsonResult);
           
            return Ok(result);
        }

        [Route("GetPokemonsByType")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPokemons(string type)
        {
            List<string> pokemonsByType = await _service.GetPokemon(type);

            string jsonResult = JsonConvert.SerializeObject(pokemonsByType);

            _logger.LogInformation(jsonResult);

            return Ok(pokemonsByType);
        }

        [Route("GetTypesOfPokemons")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTypes()
        {
            List<string> types = await _service.GetTypes();

            string jsonResult = JsonConvert.SerializeObject(types);

            _logger.LogInformation(jsonResult);

            return Ok(types);
        }
    }
}
