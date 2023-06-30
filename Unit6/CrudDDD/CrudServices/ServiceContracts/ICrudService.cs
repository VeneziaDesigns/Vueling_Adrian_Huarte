using TestSQLServer.DomainEntities;

namespace CrudServices.ServiceContracts
{
    public interface ICrudService
    {
        List<UserWorkers> GetAllUsersService();
        UserWorkers? GetByNameService(UserWorkers findWorker);
        void InsertWorkerService(UserWorkers userWorkers);
        void UpdateWorkerService(string findUser, UserWorkers userWorkers);
        void UpdateSalaryService(UserWorkers updateSalary);
        void DeleteWorkerService(UserWorkers deleteWorker);
    }
}
