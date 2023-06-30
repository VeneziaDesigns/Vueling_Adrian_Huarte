using System.Collections.Generic;
using CrudDomain.RepositoryContracts;
using CrudServices.ServiceContracts;
using TestSQLServer.DomainEntities;

namespace CrudServices.ServiceImplementations
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository _bdRepository;

        private readonly ICacheRepository _cacheRepository;

        private readonly IBackupRepository _backupRepository;

        public CrudService(ICrudRepository bdRepository, ICacheRepository cacheRepository, IBackupRepository backupRepository)
        {
            _bdRepository = bdRepository;
            _cacheRepository = cacheRepository;
            _backupRepository = backupRepository;
        }

        public List<UserWorkers> GetAllUsersService()
        {
            List<UserWorkers>? cacheUsers = _cacheRepository.GetCache();

            if (cacheUsers is not null) return cacheUsers;

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);

            return getAllUserFromDb;
        }

        public UserWorkers? GetByNameService(UserWorkers findWorker)
        {
            List<UserWorkers>? cacheUsers = _cacheRepository.GetCache();

            UserWorkers? userInCache = cacheUsers?.FirstOrDefault(user => (user.Name ?? "").Equals(findWorker.Name)
                                       && (user.Surname ?? "").Equals(findWorker.Surname));

            if (userInCache is not null) return userInCache;

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);

            UserWorkers? getWorker = getAllUserFromDb?.FirstOrDefault(user => (user.Name ?? "").Equals(findWorker.Name) 
                                     && (user.Surname ?? "").Equals(findWorker.Surname));

            if (getWorker != null)
            {
                return getWorker;
            }
             
            return null;
        }

        public void InsertWorkerService(UserWorkers findUser)
        {
            _bdRepository.InsertWorkerRepository(findUser);

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);
        }

        public void UpdateWorkerService(string findUser, UserWorkers userWorkers)
        {
            _bdRepository.UpdateWorkerRepository(findUser, userWorkers);

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);
        }

        public void UpdateSalaryService(UserWorkers updateSalary)
        {
            _bdRepository.UpdateSalaryRepository(updateSalary);

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);
        }

        public void DeleteWorkerService(UserWorkers deleteWorker)
        {
            _bdRepository.DeleteWorkerRepository(deleteWorker);

            List<UserWorkers> getAllUserFromDb = _bdRepository.GetAllUsersRepository();

            bool cacheDone = _cacheRepository.SetCache(getAllUserFromDb);

            _backupRepository.InsertBackup(getAllUserFromDb);
        }
    }
}
