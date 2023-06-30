using CrudDomain.RepositoryContracts;
using CrudServices.ServiceContracts;
using TestSQLServer.DomainEntities;

namespace CrudServices.ServiceImplementations
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository _bdRepository;

        private readonly ICacheRepository _cacheRepository;

        public CrudService(ICrudRepository bdRepository, ICacheRepository cacheRepository)
        {
            _bdRepository = bdRepository;
            _cacheRepository = cacheRepository;
        }

        public List<UserWorkers> GetAllUsersService()
        {
            List<UserWorkers>? cacheUsers = _cacheRepository.GetCache();

            if (cacheUsers is not null) return cacheUsers;

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            return getAllUserFromDb;
        }

        public UserWorkers? GetByNameService(UserWorkers findWorker)
        {
            List<UserWorkers>? cacheUsers = _cacheRepository.GetCache();

            UserWorkers? userInCache = cacheUsers?.FirstOrDefault(user => user.Name.Equals(findWorker.Name));

            if (userInCache is not null) return userInCache;
                
            // TODO Setear la cache con un solo user?

            UserWorkers? getUserFromDb = _bdRepository.GetByNameRepository(findWorker);

            if (getUserFromDb != null)
            {
                return getUserFromDb;
            }
             
            return null;
        }

        public void InsertWorkerService(UserWorkers findUser)
        {
            _bdRepository.InsertWorkerRepository(findUser);
        }

        public void UpdateWorkerService(string findUser, UserWorkers userWorkers)
        {
            _bdRepository.UpdateWorkerRepository(findUser, userWorkers);
        }

        public void UpdateSalaryService(UserWorkers updateSalary)
        {
            _bdRepository.UpdateSalaryRepository(updateSalary);
        }

        public void DeleteWorkerService(UserWorkers deleteWorker)
        {
            _bdRepository.DeleteWorkerRepository(deleteWorker);
        }
    }
}
