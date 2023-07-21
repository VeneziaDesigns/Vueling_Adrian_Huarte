using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi.Domain.CustomExceptions;
using WebApi.Domain.DomainEntities;
using WebApi.Domain.DomainEntities.ServiceContracts;
using WebApi.Domain.RepositoryContracts;

namespace WebApi.Infrastructure.RepositoryImplementations
{
    public class DataRepository : IDataRepository
    {
        private readonly string _localDbFullPath;

        public DataRepository()
        {
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Registro.json");
        }

        public void Insert(Data datos)
        {
            try
            {
                // Lee el contenido completo del archivo en formato JSON
                string jsonData = File.ReadAllText(_localDbFullPath);

                // Deserializa el contenido JSON en una lista de objetos Strings
                List<Data> jsonList = JsonConvert.DeserializeObject<List<Data>>(jsonData);

                // Agrega el objeto cadenas a la lista
                jsonList.Add(datos);

                // Serializa la lista completa en formato JSON
                string jsonSerialized = JsonConvert.SerializeObject(jsonList);

                // Guarda el JSON serializado de vuelta en el archivo
                File.WriteAllText(_localDbFullPath, jsonSerialized);
            }
            catch (CannotSaveFileException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
