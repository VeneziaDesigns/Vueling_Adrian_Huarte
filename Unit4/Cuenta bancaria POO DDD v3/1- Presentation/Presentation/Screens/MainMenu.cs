using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Infrastructure;

namespace Presentation.Screens
{
    public class MainMenu
    {
        //Declaramos option como campo de clase privado
        private string option;

        private readonly IAccountService _accountService;

        private readonly Option1Screen _option1Screen;

        private readonly Option2Screen _option2Screen;

        private readonly Option3Screen _option3Screen;

        private readonly Option4Screen _option4Screen;

        private readonly Option5Screen _option5Screen;

        private readonly Option6Screen _option6Screen;

        public MainMenu(IAccountService accountService)
        {
            _accountService = accountService;
            _option1Screen = new Option1Screen(_accountService);
            _option2Screen = new Option2Screen(_accountService);
            _option3Screen = new Option3Screen(_accountService);
            _option4Screen = new Option4Screen(_accountService);
            _option5Screen = new Option5Screen(_accountService);
            _option6Screen = new Option6Screen(_accountService);
        }

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

            Console.Clear();
        }
        private void ProcessSelectedOption() 
        {
            switch (option)
            {
                case "1":
                    _option1Screen.Start();
                    break;
                case "2":
                    _option2Screen.Start();                    
                    break;
                case "3":
                    _option3Screen.Start();
                    break;
                case "4":
                    _option4Screen.Start();
                    break;
                case "5":
                    _option5Screen.Start();
                    break;
                case "6":
                    _option6Screen.Start();
                    break;
                case "7":
                    Console.WriteLine("Bye!!!");
                    break;
                default: 
                    Console.WriteLine("Please select an option from the list");
                    break;
            }
        }
    }
}
