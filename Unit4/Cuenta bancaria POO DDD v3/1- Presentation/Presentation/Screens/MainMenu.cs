using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Presentation.Screens
{
    public class MainMenu
    {
        //Declaramos option como campo de clase privado
        private string option;

        
        public void Start()
        {
            do
            {
                ShowMenuAndGetOption();
                ProcessSelectedOption();
            } while (option != "7");
        }
        private void ShowMenuAndGetOption()
        {
            Console.WriteLine("¿Que operacion desea realizar?");
            Console.WriteLine("1 -Money income");
            Console.WriteLine("2 -Money outcome");
            Console.WriteLine("3 -List all movements");
            Console.WriteLine("4 -List incomes");
            Console.WriteLine("5 -List outcomes");
            Console.WriteLine("6 -Show current money");
            Console.WriteLine("7 -Exit");
            option = Console.ReadLine();
        }
        private void ProcessSelectedOption() 
        {
            switch (option)
            {
                case "1":
                    new Option1Screen().Start();
                    break;
                case "2":
                    new Option2Screen().Start();
                    break;
                case "3":
                    new Option3Screen().Start();
                    break;
                case "4":
                    new Option4Screen().Start();
                    break;
                case "5":
                    new Option5Screen().Start();
                    break;
                case "6":
                    new Option6Screen().Start();
                    break;
                case "7":
                    new Option7Screen().Start();
                    break;
            }
        }
    }
}
