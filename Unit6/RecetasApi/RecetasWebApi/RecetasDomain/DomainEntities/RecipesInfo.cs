using System.Text.Json.Serialization;

namespace RecetasDomain.DomainEntities
{
    public class RecipesInfo
    {

        public string? Name { get; set; }

        public Dictionary<string, decimal>? Ingredients { get; set; }

        public int TimeMinutes { get; set; }
    }
}
