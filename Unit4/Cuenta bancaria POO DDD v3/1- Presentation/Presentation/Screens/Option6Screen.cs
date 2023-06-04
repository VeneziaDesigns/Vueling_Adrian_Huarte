using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Presentation.Screens
{
    public class Option6Screen
    {
        private readonly IAccountService _accountService;

        public Option6Screen(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Start()
        {
            string actualBalance = _accountService.Balance();
            Console.WriteLine($"{actualBalance:0.##}");
        }
    }
}
