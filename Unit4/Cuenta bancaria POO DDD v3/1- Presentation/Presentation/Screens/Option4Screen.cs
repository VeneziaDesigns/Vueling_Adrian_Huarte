using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;

namespace Presentation.Screens
{
    public class Option4Screen
    {
        private readonly IAccountService _accountService;

        public Option4Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            List<Incomes> incomesList = _accountService.IncomesList();

            if (incomesList.Count == 0)
            {
                Console.WriteLine("There is no income");
            }
            else
            {
                Console.WriteLine("Incomes:");
                incomesList.ForEach(income => Console.WriteLine(income));
            }
        }
    }
}
