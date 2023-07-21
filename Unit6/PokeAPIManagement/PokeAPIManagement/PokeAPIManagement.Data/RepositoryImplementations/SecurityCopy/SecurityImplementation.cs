using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeAPIManagement.Data.RepositoryImplementations.SecurityCopy
{
    public class SecurityImplementation : ISecurityImplementation
    {

        private readonly string _filePath = @"C:\Users\ahuarte\source\repos\Vueling_Adrian_Huarte\PokeAPIManagement\PokeAPIManagement\PokeAPIManagement.Data\RepositoryImplementations\SecurityCopy\SecurityCopy.json";

        public bool SecurityCopy(List<string> copy)
        {
                // Leer el contenido del archivo JSON
                string jsonContent = File.ReadAllText(_filePath);

                // Deserializar el contenido del archivo en una lista de strings
                List<string> existingData = JsonConvert.DeserializeObject<List<string>>(jsonContent) ?? new List<string>();

                // Verificar si los elementos ya existen en el archivo JSON
                List<string> newData = copy.Except(existingData).ToList();

                // Si hay nuevos datos, agregarlos a la lista existente
                if (newData.Count > 0)
                {
                    existingData.AddRange(newData);

                    // Serializar la lista actualizada a JSON
                    string updatedJson = JsonConvert.SerializeObject(existingData);

                    // Escribir el contenido actualizado en el archivo JSON
                    File.WriteAllText(_filePath, updatedJson);
                }

                return true;
        }
    }
}
    

