using System;
using System.Security.Principal;
using Domain;
using Infrastructure;

namespace Presentation.Screens
{
    public class Option1Screen
    {
        private Account account;

        public void Start()
        {
            Console.WriteLine("Please enter an amount to deposit");
            string incomeAsString = Console.ReadLine();
            Console.WriteLine();

            (bool isParseable, decimal parsedIncome) = new Parsing().TryParseDecimalValue(incomeAsString);

            if (isParseable)
            {
                if (account == null)
                {
                    new Account().AddIncomes(parsedIncome);
                }
                decimal balance = account.AddIncomes(parsedIncome);

                account.balance = balance;
            }
            else
            {
                Console.WriteLine("The format is not correct");
            }
        }
    }
}
