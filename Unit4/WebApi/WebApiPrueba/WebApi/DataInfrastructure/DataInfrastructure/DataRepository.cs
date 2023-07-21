using System;
using System.Collections.Generic;
using System.IO;

using DataDomain.CustomExceptions;
using DataDomain.DomainEntities;
using DataDomain.RepositoryContracts;
using Newtonsoft.Json;

namespace DataInfrastructure
{
    public class DataRepository : IDataRepository
    {
        private readonly string _localDBFullPath;

        public DataRepository()
        {
            _localDBFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Data.json");
        }

        public void Insert(Datos cadenas)
        {
            try
            {
                // Lee el contenido completo del archivo en formato JSON
                string jsonData = File.ReadAllText(_localDBFullPath);

                // Deserializa el contenido JSON en una lista de objetos Strings
                List<Datos> jsonList = JsonConvert.DeserializeObject<List<Datos>>(jsonData);

                // Agrega el objeto cadenas a la lista
                jsonList.Add(cadenas);

                // Serializa la lista completa en formato JSON
                string jsonSerialized = JsonConvert.SerializeObject(jsonList);

                // Guarda el JSON serializado de vuelta en el archivo
                File.WriteAllText(_localDBFullPath, jsonSerialized);
            }
            catch (CanNotSaveDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
