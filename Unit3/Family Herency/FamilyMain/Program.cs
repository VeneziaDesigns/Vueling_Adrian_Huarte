using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyMain.Family;

namespace FamilyMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool valid;
            Son hijo = new Son("Pedro", 15, "64839045-U", "Paco", 41, "21460198-P", "Pepe", 62, "79435764-R");

            do
            {
                Console.WriteLine("1 - Mostrar valores");
                Console.WriteLine("2 - Modificar valores");
                Console.WriteLine("3 - Salir");

                valid = int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        hijo.ShowFields();
                        break;
                    case 2:
                        hijo.SetFields();
                        break;
                    case 3:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("La opción introducida no es válida");
                        break;
                }
            } while (option != 3);

        }
    }
}
