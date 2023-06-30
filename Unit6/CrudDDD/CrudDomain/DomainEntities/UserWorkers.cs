using System.ComponentModel.DataAnnotations;

namespace TestSQLServer.DomainEntities
{
    public class UserWorkers
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public decimal? Salary { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
