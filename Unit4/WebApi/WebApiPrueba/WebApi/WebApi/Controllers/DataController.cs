using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using DataDomain.DomainEntities;
using DataDomain.ServiceContracts;

namespace WebApi.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDataService _service;

        public DataController(IDataService service)
        {
            _service = service;
        }

        /// <summary>
        /// Actions to manage strings
        /// </summary>
        /// <param name="cadenas"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetStrings(List<string> cadenas)
        {

            if (cadenas.Count != 3)
            {
                return BadRequest("Only 3 strings");
            }
            else
            {
                Datos strings = new Datos()
                {
                    Colour = cadenas[0],
                    IntParseable = cadenas[1],
                    Free = cadenas[2],
                    Date = DateTime.Now,
                };
                try
                {
                    _service.Register(strings);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
