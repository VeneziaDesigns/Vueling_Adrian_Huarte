using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain.IRepositories;
using Infrastructure.Data;
using Presentation.Authentication;
using Presentation.Screens;
using Unity;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {

            IUnityContainer container = new UnityContainer();

            RegisterTypes(container);

            MainMenu mainMenu = container.Resolve<MainMenu>();

            bool acceso;
            int contador = 0;

            do
            {
                acceso = new Autenticacion().StartAuthentication();
                contador++;

            } while (acceso == false && contador <= 2);
            
            if (acceso == true)
            {
                mainMenu.Start();
            }
            else
            {
                Console.WriteLine("Maximum number of attempts exceeded");
            }

            Console.Write("Press any key to finish...");
            Console.ReadKey();
        }

        static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountRepository, AccountRepository>(TypeLifetime.Singleton);

            container.RegisterType<IAccountService, AccountService>();

            container.RegisterType<MainMenu>();
        }
    }
}
