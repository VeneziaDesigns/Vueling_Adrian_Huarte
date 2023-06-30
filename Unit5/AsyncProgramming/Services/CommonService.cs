using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AsyncProgramming.CharmanderDTO;
using AsyncProgramming.Repositories;

namespace AsyncProgramming.Services
{
    public class CommonService
    {
        // Devuelve un string, pero al ser asincrono devolvera un Task<string>
        public async Task<PokeInfoDTO> ServiceMethod()
        {
            // Crea una instancia de CommonRepository y espera a que
            // se complete la tarea devuelta por el método RepositoryMethod
            //string result = await new CommonRepository().RepositoryMethod();

            PokeInfoDTO result = await new CommonRepository().RepositoryMethod();

            return result;
        }
    }
}