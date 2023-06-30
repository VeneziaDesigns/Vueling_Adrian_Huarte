using CrudApi.DataModels;
using CrudApi.DbContextFolder;
using CrudDomain.RepositoryContracts;
using TestSQLServer.DomainEntities;
using Microsoft.EntityFrameworkCore;
using CrudDomain.CustomException;

namespace CrudInfrastructure.Data.RepositoryImplementations
{
    public class CrudRepository : ICrudRepository
    {
        private readonly ApiCrudNet6Context _dbContext;

        public CrudRepository(ApiCrudNet6Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserWorkers> GetAllUsersRepository()
        {
            List<UserWorkers> resultListFromDb = _dbContext.Users
                .Select(user => new UserWorkers
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Salary = user.Worker.Salary,
                    YearsOfExperience = user.Worker.YearsOfExperience,
                })
                .ToList();

            return resultListFromDb;
        }

        public void InsertWorkerRepository(UserWorkers userWorkers)
        {
            _dbContext.Users.Add(new Users
            {
                Name = userWorkers.Name,
                Surname = userWorkers.Surname,
                Worker = new Worker
                {
                    Salary = userWorkers.Salary,
                    YearsOfExperience = userWorkers.YearsOfExperience
                }
            });
            _dbContext.SaveChanges();
        }

        public void UpdateWorkerRepository(string findUser, UserWorkers userWorkers)
        {
            Users? findUserByName = _dbContext.Users.Include(user => user.Worker)
            .FirstOrDefault(user => user.Name.Equals(findUser));

            if (findUserByName != null)
            {
                findUserByName.Name = userWorkers.Name;
                findUserByName.Surname = userWorkers.Surname;
                findUserByName.Worker.Salary = userWorkers.Salary;
                findUserByName.Worker.YearsOfExperience = userWorkers.YearsOfExperience;

                _dbContext.SaveChanges();
            }
        }

        public void UpdateSalaryRepository(UserWorkers updateSalary)
        {
            Users? findUserByName = _dbContext.Users.Include(user => user.Worker)
                    .FirstOrDefault(user => user.Name.Equals(updateSalary.Name) && 
                        user.Surname.Equals(updateSalary.Surname));

            if (findUserByName != null)
            {
                findUserByName.Worker.Salary = updateSalary.Salary;

                _dbContext.SaveChanges();
            }
            
        }

        public void DeleteWorkerRepository(UserWorkers deleteWorker)
        {
            Users? findUser = _dbContext.Users.Include(user => user.Worker)
                .FirstOrDefault(user => user.Name.Equals(deleteWorker.Name)
                                && user.Surname.Equals(deleteWorker.Surname));

            if (findUser != null)
            {
                _dbContext.Remove(findUser.Worker);
                            
                _dbContext.Remove(findUser);

                _dbContext.SaveChanges();
            }
        }
    }
}
