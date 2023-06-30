using TestSQLServer.DomainEntities;

namespace CrudDomain.RepositoryContracts
{
    public interface ICrudRepository
    {
        List<UserWorkers> GetAllUsersRepository();
        UserWorkers? GetByNameRepository(UserWorkers findWorker);
        void InsertWorkerRepository(UserWorkers userWorkers);
        void UpdateWorkerRepository(string findUser, UserWorkers userWorkers);
        void UpdateSalaryRepository(UserWorkers updateSalary);
        void DeleteWorkerRepository(UserWorkers deleteWorker);
    }
}
