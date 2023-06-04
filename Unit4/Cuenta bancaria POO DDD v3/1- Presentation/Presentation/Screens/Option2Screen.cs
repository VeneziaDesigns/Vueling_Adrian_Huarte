using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;
using Infrastructure;

namespace Presentation.Screens
{
    public class Option2Screen
    {
        private readonly IAccountService _accountService;

        public Option2Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            Console.WriteLine("Please enter an amount to withdraw");
            string incomeAsString = Console.ReadLine();

            (bool isParseable, decimal parsedIncome) = new Parsing().TryParseDecimalValue(incomeAsString);

            if (isParseable)
            {
                decimal? actualizarSaldo = _accountService.AniadirGasto(parsedIncome);

                if (actualizarSaldo.HasValue)
                {
                    Console.WriteLine($"Your current cash is: {actualizarSaldo:0.##}");
                }
                else
                {
                    Console.WriteLine($"Withdrawal exceeds account balance or '{incomeAsString}' is a negative number");
                }
            }
            else
            {
                Console.WriteLine("The format is not correct");
            }
        }
    }
}
