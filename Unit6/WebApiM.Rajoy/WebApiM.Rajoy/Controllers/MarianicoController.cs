using M.Domain.DomainEntities;
using M.Services.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiM.Rajoy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarianicoController : ControllerBase
    {
        private readonly IMarianicoService _services;

        public MarianicoController(IMarianicoService services)
        {
            _services = services;
        }

        #region GetAllFrases
        [Route("GetAllFrases")]
        [HttpGet]
        public IActionResult GetAllFrases()
        {
            List<Frase> getAllFrases = _services.GetAllFrases();

            if (getAllFrases.Count != 0)
            {
                return Ok(getAllFrases);
            }
            return BadRequest("No hay frases celebres en la base de datos.");
        }
        #endregion

        #region GetFraseByDate
        [Route("GetFraseByDate")]
        [HttpGet]
        public IActionResult GetFraseByDate(string fecha)
        {
            List<Frase> getAllFrases = _services.GetFraseByDate(fecha);

            if (getAllFrases.Count != 0)
            {
                return Ok(getAllFrases);
            }

            return BadRequest("No hay frases celebres en la base de datos con esa fecha.");
        }
        #endregion

        #region GetFraseById
        [Route("GetFraseById")]
        [HttpGet]
        public IActionResult GetFraseById(int id)
        {
            Frase getFrase = _services.GetFraseById(id);

            if (getFrase != null)
            {
                return Ok(getFrase);
            }

            return BadRequest("No hay frases celebres en la base de datos con ese Id.");
        }
        #endregion

        #region AddFrase
        [Route("AddFrase")]
        [HttpPost]
        public IActionResult AddFrase(string frase, string fecha)
        {
            Frase fraseAInsertar = new()
            {
                Text = frase,
                Date = fecha
            };

            int newId = _services.AddFrase(fraseAInsertar);

            if (newId != null)
            {
                return Ok($"La frase celebre se ha guardado con exito con el Id {newId}");
            }

            return BadRequest("La conexion con la base de datos ha fallado");
        }
        #endregion
    }
}
