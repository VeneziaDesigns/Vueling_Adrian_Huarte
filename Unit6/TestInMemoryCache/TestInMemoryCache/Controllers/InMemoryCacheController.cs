using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace TestInMemoryCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<List<User>> Test()
        {
            // Se intenta obtener un objeto de la memoria caché llamado "users"
            List<User>? output = _memoryCache.Get<List<User>>("users");

            // Si la variable output no es nula, significa que se encontró un objeto
            // en la memoria caché con la clave "users"
            if (output is not null) return output;

            // Otra forma de hacerlo
            //if (_memoryCache.TryGetValue("users", out users))

                // Si no se encontró un objeto en la memoria caché, se crea una nueva instancia de lista
            output = new()
            {

                new() { FirstName = "Tim", LastName = "Corey" },

                new() { FirstName = "Sue", LastName = "Storm" },

                new() { FirstName = "Jane", LastName = "Jones" }

            };

            // Simula una operación asíncrona o una espera.
            await Task.Delay(3000);

            // Se utiliza el método Set del objeto _memoryCache para almacenar el objeto
            // output en la memoria caché con la clave "users" durante 1 minuto
            //_memoryCache.Set("users", output, TimeSpan.FromMinutes(1));

            // Set cache options: 1. Definimos objeto MemoryCacheEntryOptions
            var cacheOptions = new MemoryCacheEntryOptions()
                // 2. Configuramos expiracion Absolute y Sliding
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                .SetSlidingExpiration(TimeSpan.FromSeconds(20));

            // Seteamos la _memoryCache con el cacheOptions como 3er parametro
            _memoryCache.Set("users", output, cacheOptions);

            return output;
        }
    }
}
