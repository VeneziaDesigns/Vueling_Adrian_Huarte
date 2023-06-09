using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  Domain Entities

namespace Domain
{
    public class Account
    {
        public int accountNumber { get; set; }
        public int pass { get; set; }
        public decimal balance { get; set; }
        public List<Income> incomes { get; set; }
        public List<Outcome> outcomes { get; set; }

        public Account(int account, int pass)
        {
            this.accountNumber = account;
            this.pass = pass;
        }

        public Account()
        {
            balance = 1000;
            incomes = new List<Income>();
            outcomes = new List<Outcome>();
        }

        public decimal AddIncomes(decimal cash)
        {
            balance += cash;

            incomes.Add(new Income(cash));

            return balance;
        }
        public decimal AddOutcomes(decimal cash)
        {            
            balance -= cash;

            outcomes.Add(new Outcome(cash));
            
            return balance;
        }

        public List<Income> GetIncomes() 
        { 
            return incomes; 
        }

        public List<Outcome> GetOutcomes()
        {
            return outcomes;
        }

        public override string ToString()
        {
            return $"Your current balance is {balance}";
        }
    }
}
