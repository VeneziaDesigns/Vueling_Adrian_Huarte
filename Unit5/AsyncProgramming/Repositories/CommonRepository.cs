using System.Net.Http;
using System.Threading.Tasks;
using AsyncProgramming.CharmanderDTO;
using Newtonsoft.Json;

namespace AsyncProgramming.Repositories
{
    public class CommonRepository
    {
        public async Task<PokeInfoDTO> RepositoryMethod()
        {
            // "await" indica que se espera a que la tarea se complete antes de continuar.
            // Task.Run() se utiliza para ejecutar una operación en un hilo de fondo.
            // En este caso, se ejecuta una función lambda que devuelve la cadena "hello".
            // El resultado de la tarea se asigna a la variable "result".

            //string result = await Task.Run(() => { return "hello"; });

            //Clase que contiene metodos para hacer peticiones asincronas
            HttpClient httpClient = new HttpClient();

            // Realiza una solicitud HTTP GET a la URL de la PokeApi/charmander y
            // espera a que la tarea devuelta por GetAsync() se complete antes de continuar.
            HttpResponseMessage resultFromURL = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/charmander");

            // Devuelve el contenido de la respuesta HTTP como una cadena utilizando
            // la operación de lectura asíncrona

            //return await result.Content.ReadAsStringAsync();

            // Lee el contenido de la respuesta HTTP recibida en resultFromURL como una cadena
            string resultFromURLAsString = await resultFromURL.Content.ReadAsStringAsync();

            //Convierte la cadena resultFromURLAsString en un objeto de tipo PokeInfoDTO 
            PokeInfoDTO resultFromURLAsDomainEntity = JsonConvert.DeserializeObject<PokeInfoDTO>(resultFromURLAsString);

            return resultFromURLAsDomainEntity;
            // Es útil cuando se trabaja con respuestas HTTP que contienen datos en formato JSON y se desea
            // convertirlos en objetos de dominio más convenientes para su uso en la aplicación.
        }
    }
}