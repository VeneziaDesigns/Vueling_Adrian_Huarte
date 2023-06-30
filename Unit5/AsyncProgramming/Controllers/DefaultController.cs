using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using AsyncProgramming.CharmanderDTO;
using AsyncProgramming.Services;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;

namespace AsyncProgramming.Controllers
{
    [RoutePrefix("api/Default")]
    public class DefaultController : ApiController
    {
        private readonly ILogger _logger;

        public DefaultController(ILogger log) // Recibe un Ilogger por parametro
        {
            _logger = log; //Lo iguala a la var privada creada
        }

        [Route("Test")]         // Sin [RoutePrefix("api/Default")] => [RoutePrefix("api/Default/Test")]
        public IHttpActionResult Test()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            #region LINQ - Where
            List<int> evenNumbers = numbers.Where(number => number % 2 == 0 && number > 5).ToList();

            List<int> evenNumbersV2 = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0 && number > 5)
                {
                    evenNumbersV2.Add(number);
                }
            }
            #endregion

            #region LINQ - FirstOrDefault
            int firstEvenNumber = numbers.FirstOrDefault(number => number % 2 == 0 && number > 5);

            int firstEvenNumberV2 = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0 && number > 5)
                {
                    firstEvenNumberV2 = number;
                    break;
                }
            }
            #endregion

            #region LINQ - Select
            List<PokeInfoDTO> pokeInfoDTOList = new List<PokeInfoDTO>
            {
                new PokeInfoDTO() {
                base_experience = 5,
                height = 6,
                name = "Unown"
            },
                new PokeInfoDTO() {
                base_experience = 15,
                height = 16,
                name = "mew"
            }
            };

            List<string> pokeNames = pokeInfoDTOList.Select(pokeInfo => pokeInfo.name).ToList();
            var pokeNamesComplexType = pokeInfoDTOList.Select(pokeInfo => new { pokeInfo.name, pokeInfo.height }).ToList();

            #endregion

            _logger.LogInformation("He pasado por aqui");

            return Ok("Test");
        }
        // Devolvera un IHttpActionResult normal, aunque sea Task<IHttpActionResult>, la advertencia
        // verde en el metodo indica que no se ha puesto un await, sin await se comportara de forma normal
        public async Task<IHttpActionResult> Get()
        {
            // Crea una instancia de CommonService, espera a que se complete la tarea devuelta por el método ServiceMethod() 
            PokeInfoDTO message = await new CommonService().ServiceMethod();

            // Devuelve una respuesta HTTP 200 OK con el mensaje obtenido como contenido de la respuesta.
            return Ok(message);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            PokeInfoDTO message = await new CommonService().ServiceMethod();

            return Ok(message);
        }
    }
}
