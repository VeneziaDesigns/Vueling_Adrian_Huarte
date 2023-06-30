using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using FireDomain;
using Microsoft.SqlServer.Server;

namespace WebApiFire.Controllers
{
    [RoutePrefix("api/Pokemon")]
    public class PokemonController : ApiController
    {
        private readonly IFireService _fireService;

        public PokemonController(IFireService fireService)
        {
            _fireService = fireService;
        }


        /// <summary>
        /// Listar los 10 primeros pokemon de tipo fuego
        /// </summary>
        /// <remarks>
        /// Listar los 10 primeros pokemon de fuego        
        /// </remarks>
        /// <returns></returns>
        [Route("GetTypeFire")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFireTypeAttacksInSpanish()
        {
            List<string> fireAttacks = await _fireService.GetFireTypes();
            
            return Ok(fireAttacks);
        }

        /// <summary>
        /// Obtener todos los pokemon por tipo
        /// </summary>
        /// <remarks>
        /// Obtener todos los pokemon por tipo
        /// </remarks>
        /// <returns></returns>
        [Route("GetPokemonsByType")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPokemonsByType(string type)
        {
            List<string> fireAttacks = await _fireService.GetPokemon(type);

            return Ok(fireAttacks);
        }

        /// <summary>
        /// Obtener todos los tipos de pokemon
        /// </summary>
        /// <remarks>
        /// Obtener todos los tipos de pokemon
        /// </remarks>
        /// <returns></returns>
        [Route("GetTypesOfPokemons")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTypes()
        {
            List<string> fireAttacks = await _fireService.GetTypes();

            return Ok(fireAttacks);
        }

        /// <summary>
        /// Test para expresiones regulares
        /// </summary>
        /// <remarks>
        /// Test para expresiones regulares
        /// </remarks>
        /// <returns></returns>
        [Route("TestRegex")]
        public IHttpActionResult TestRegex()
        {
            Regex regex = new Regex("^[+-]?([0-9]*[.])?[0-9]+$");

            string strToParse = "1.72";

            bool isParseable = regex.IsMatch(strToParse);
            Match firstMatch = regex.Match(strToParse);

            return Ok(firstMatch);
        }
    }
}
