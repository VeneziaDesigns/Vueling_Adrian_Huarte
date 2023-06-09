using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;

namespace Presentation.Screens
{
    public class Option3Screen
    {
        private readonly IAccountService _accountService;

        public Option3Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            List<Income> incomesList = _accountService.IncomesList();

            if (incomesList.Count == 0)
            {
                Console.WriteLine("There is no income");
            }
            else
            {
                Console.WriteLine("Incomes:");
                incomesList.ForEach(income => Console.WriteLine(income));
            }

            List<Outcome> outcomesList = _accountService.OutcomesList();
            
            if(outcomesList.Count == 0)
            {
                Console.WriteLine("There is no outcome");
            }
            else
            {
                Console.WriteLine("Outcomes:");
                outcomesList.ForEach(outcome => Console.WriteLine(outcome));
            }
        }
    }
}
