using CrudDomain.RepositoryContracts;
using Newtonsoft.Json;
using TestSQLServer.DomainEntities;

namespace CrudInfrastructure.Data.RepositoryImplementations
{
    public class BackupRepository : IBackupRepository
    {
        private readonly string _backupFilePath;

        public BackupRepository()
        {
            _backupFilePath = @"..\CrudInfrastructure.Data\Backup\Backup.json";
        }

        public void InsertBackup(List<UserWorkers> backupUsers)
        {
            string json = JsonConvert.SerializeObject(backupUsers, Formatting.Indented);

            File.WriteAllText(_backupFilePath, json);
        }
    }
}
