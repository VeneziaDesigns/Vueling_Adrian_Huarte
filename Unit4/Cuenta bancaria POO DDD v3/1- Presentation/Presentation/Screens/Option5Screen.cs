using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Domain;

namespace Presentation.Screens
{
    public class Option5Screen
    {
        private readonly IAccountService _accountService;

        public Option5Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            List<Outcome> outcomesList = _accountService.OutcomesList();

            if (outcomesList.Count == 0)
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
