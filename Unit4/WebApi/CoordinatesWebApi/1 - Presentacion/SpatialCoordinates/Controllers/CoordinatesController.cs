using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI;
using SpatialCoordinatesDomain;
using SpatialCoordinatesDomain.CustomExceptions;
using SpatialCoordinatesDomain.IContracts;

namespace SpatialCoordinates.Controllers
{
    /// <summary>
    /// Actions to manage coordinates
    /// </summary>
    public class CoordinatesController : ApiController
    {
        private readonly ICoordinateService _service;

        public CoordinatesController(ICoordinateService service)
        {
            _service = service;
        }

        /// <summary>
        /// Actions to manage coodinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(List<decimal> coordinates)
        {
            if (coordinates.Count != 3)
            {
                return BadRequest("Only 3 coordinates list allowed");
            }

            Coordinates coords = new Coordinates
            {
                coordX = coordinates[0],
                coordY = coordinates[1],
                coordZ = coordinates[2]
            };

            try
            {
                _service.Register(coords);

                return Ok(coords);
            }
            catch (InvalidCoordXException ex)
            {
                return BadRequest($"Some problem found in X coordinate: {ex.Message}");
            }
            catch (CanNotSaveDataException ex)
            {
                return BadRequest($"Some error occured while trying to save data: {ex.Message}");
            }
        }
    }
}
