using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Domain.DomainEntities;
using WebApi.Domain.DomainEntities.ServiceContracts;

namespace WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterController : ApiController
    {
        // readonly => para darle valor en el constructor 
        // pero que luego no se vuelva a modificar
        private readonly IDataServices _services;

        public RegisterController(IDataServices service)
        {
            _services = service;
        }

        /// <summary>
        /// Action to register data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(List<string> data)
        {
            if (data.Count != 2)
            {

                return BadRequest("Only name and residence");
            }
            else
            {
                Data datos = new Data
                {
                    RebelName = data[0],
                    NombreP = data[1],
                    PlanetName = DateTime.Now,
                };

                //Comunicamos la capa 1 con la capa 2 creando el objeto _services
                //que implementa la interfaz IDataServices
                _services.Register(datos);

                return Ok();
            }
        }
    }
}
