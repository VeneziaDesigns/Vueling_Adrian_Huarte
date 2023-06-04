using System;
using System.Security.Principal;
using Business;
using Domain;
using Infrastructure;

namespace Presentation.Screens
{
    public class Option1Screen
    {
        private readonly IAccountService _accountService;

        public Option1Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            Console.WriteLine("Please enter an amount to deposit");
            string incomeAsString = Console.ReadLine();

            (bool isParseable, decimal parsedIncome) = new Parsing().TryParseDecimalValue(incomeAsString);

            if (isParseable)
            {
                decimal? actualizarSaldo = _accountService.AniadirIngreso(parsedIncome);

                if (actualizarSaldo.HasValue)
                {
                    Console.WriteLine($"Your current cash is: {actualizarSaldo:0.##}");
                }
                else
                {
                    Console.WriteLine($"Value '{incomeAsString}' is not a positive number");
                }
            }
            else
            {
                Console.WriteLine("The format is not correct");
            }
        }
    }
}
