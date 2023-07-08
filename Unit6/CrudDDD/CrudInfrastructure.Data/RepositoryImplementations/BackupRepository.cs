using CrudDomain.RepositoryContracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TestSQLServer.DomainEntities;

namespace CrudInfrastructure.Data.RepositoryImplementations
{
    public class BackupRepository : IBackupRepository
    {
        private readonly string _backupFilePath;

        public BackupRepository(IConfiguration configuration)
        {
            _backupFilePath = configuration.GetSection("MySettings:BackupFilePath").Value;
        }

        public void InsertBackup(List<UserWorkers> backupUsers)
        {
            string json = JsonConvert.SerializeObject(backupUsers, Formatting.Indented);

            File.WriteAllText(_backupFilePath, json);
        }
    }
}
