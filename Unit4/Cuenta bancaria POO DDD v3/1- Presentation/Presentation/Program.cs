using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Presentation.Authentication;
using Presentation.Screens;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool acceso;
            int contador = 0;

            do
            {
                acceso = new Autenticacion().StartAuthentication();
                contador++;

            } while (acceso == false && contador <= 2);
            
            if (acceso == true)
            {
                new MainMenu().Start();
            }
            else
            {
                Console.WriteLine("Maximum number of attempts exceeded");
            }

            Console.Write("Press any key to finish...");
            Console.ReadKey();
        }
    }
}
