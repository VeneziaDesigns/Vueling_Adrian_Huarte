using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Presentation.Screens
{
    public class Option2Screen
    {
        private Account account;
       
        public void Start()
        {
            Console.WriteLine("please enter an amount to withdraw");
            string incomeAsString = Console.ReadLine();
            Console.WriteLine();

            (bool isParseable, decimal parsedIncome) = new Parsing().TryParseDecimalValue(incomeAsString);

            if (isParseable)
            {
                if (account == null)
                {
                    new Account().AddOutcomes(parsedIncome);
                }
                account.AddOutcomes(parsedIncome);
            }
            else
            {
                Console.WriteLine("The format is not correct");
            }
        }
    }
}
