using CrudServices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TestSQLServer.DomainEntities;

namespace TestSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiCrudController : ControllerBase
    {
        private readonly ICrudService _services;
        private readonly ILogger<WebApiCrudController> _logger;

        public WebApiCrudController(ILogger<WebApiCrudController> logger, ICrudService services)
        {
            _logger = logger;
            _services = services;
        }

        #region GetAll
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<UserWorkers> getAllUsersFromDb = _services.GetAllUsersService();

                if (getAllUsersFromDb.Count != 0)
                {
                    string workersToString = string.Join(Environment.NewLine, getAllUsersFromDb.Select(user =>
                    $"Name: {user.Name}, Surname: {user.Surname}, Salary: {user.Salary}, Years of Experience: {user.YearsOfExperience}"));

                    _logger.LogWarning($"The following information was consulted in the database:\n {workersToString}.");

                    return Ok(getAllUsersFromDb);
                }

                _logger.LogError($"The database query has not produced results.");

                return BadRequest("No users registered in the system.");
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred during the query.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion


        #region GetByName
        [Route("Get")]
        [HttpGet]
        public IActionResult Get(string name, string surName)
        {
            try
            {
                if (!(name.IsNullOrEmpty() && surName.IsNullOrEmpty()))
                {
                    UserWorkers findWorker = new()
                    {
                        Name = name,
                        Surname = surName
                    };

                    UserWorkers? getUserFromDb = _services.GetByNameService(findWorker);

                    if (getUserFromDb != null)
                    {
                        string workerToString = $"Name: {getUserFromDb.Name}, Surname: {getUserFromDb.Surname}, Salary: {getUserFromDb.Salary}, Years of Experience: {getUserFromDb.YearsOfExperience}.";

                        _logger.LogWarning($"The following information was consulted in the database:\n {workerToString}.");

                        return Ok(getUserFromDb);
                    }

                    _logger.LogError($"The user of the query is not in the system.");

                    return BadRequest("User not found");
                }

                return BadRequest($"Some of the data entered is not valid.");
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred during the query.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion

        #region Insert
        [Route("Insert")]
        [HttpPost]
        public IActionResult Insert(string name, string surName, decimal salary, int yearsOfExperience)
        {
            try
            {
                if (!(name.IsNullOrEmpty() && surName.IsNullOrEmpty()) && yearsOfExperience >= 0 && salary > 0)
                {
                    UserWorkers insertWorkerServices = new()
                    {
                        Name = name,
                        Surname = surName,
                        Salary = salary,
                        YearsOfExperience = yearsOfExperience
                    };

                    _services.InsertWorkerService(insertWorkerServices);

                    _logger.LogWarning($"The user {insertWorkerServices.Name} {insertWorkerServices.Surname} was successfully created.");

                    return Ok("User successfully created.");
                }

                return BadRequest($"Some of the data entered is not valid.");
            }
            catch (Exception e)
            {
                _logger.LogError("Error when trying to create a user.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion

        #region Update
        [Route("Update")]
        [HttpPut]
        public IActionResult Update(string FindByName, string newName, string newSurName, decimal newSalary, int newYearsOfExperience)
        {
            try
            {
                if (!(FindByName.IsNullOrEmpty() && newName.IsNullOrEmpty() && newSurName.IsNullOrEmpty())
                    && newSalary >= 0 && newYearsOfExperience > 0)
                {
                    UserWorkers updateWorkerServices = new()
                    {
                        Name = newName,
                        Surname = newSurName,
                        Salary = newSalary,
                        YearsOfExperience = newYearsOfExperience
                    };

                    _services.UpdateWorkerService(FindByName, updateWorkerServices);

                    _logger.LogWarning($"The user {updateWorkerServices.Name} {updateWorkerServices.Surname} was successfully update.");

                    return Ok("User successfully update");
                }

                return BadRequest($"Some of the data entered is not valid.");
            }
            catch (Exception e)
            {
                _logger.LogError("Error when trying to update a user.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion

        #region Patch
        [Route("Patch")]
        [HttpPatch]
        public IActionResult Patch(string name, string surName, decimal newSalary)
        {
            try
            {
                if (!(name.IsNullOrEmpty() && surName.IsNullOrEmpty() && newSalary > 0))
                {
                    UserWorkers updateSalary = new()
                    {
                        Name = name,
                        Surname = surName,
                        Salary = newSalary
                    };

                    _services.UpdateSalaryService(updateSalary);

                    _logger.LogWarning($"Updated salary of {updateSalary.Name} {updateSalary.Surname} to {updateSalary.Salary}.");

                    return Ok("Salary successfully update");
                }

                _logger.LogError("Error when trying to update a user's salary.");

                return BadRequest($"Some of the data entered is not valid.");
            }
            catch (Exception e)
            {
                _logger.LogError("Error when trying to update a salary user.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion

        #region Delete
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(string name, string surName)
        {
            try
            {

                if (!(name.IsNullOrEmpty() && surName.IsNullOrEmpty()))
                {
                    UserWorkers deleteWorker = new()
                    {
                        Name = name,
                        Surname = surName
                    };

                    _services.DeleteWorkerService(deleteWorker);

                    _logger.LogWarning($"The user {deleteWorker.Name} {deleteWorker.Surname} was successfully delete.");

                    return Ok("User successfully delete");
                }

                return BadRequest($"Some of the data entered is not valid.");
            }
            catch (Exception e)
            {
                _logger.LogError("Error when trying to delete user.");

                return BadRequest($"Unespected error occurred: {e.Message}");
            }
        }
        #endregion
    }
}
