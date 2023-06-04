using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Account
    {
        public int account { get; set; }
        public int pass { get; set; }
        public decimal balance { get; set; }
        public List<Incomes> incomes { get; set; }
        public List<Outcomes> outcomes { get; set; }

        public Account(int account, int pass)
        {
            this.account = account;
            this.pass = pass;
        }

        public Account()
        {
            balance = 1000;
            incomes = new List<Incomes>();
            outcomes = new List<Outcomes>();
        }

        public decimal AddIncomes(decimal cash)
        {
            balance += cash;

            incomes.Add(new Incomes(cash));

            return balance;
        }
        public decimal AddOutcomes(decimal cash)
        {            
            balance -= cash;

            outcomes.Add(new Outcomes(cash));
            
            return balance;
        }

        public List<Incomes> GetIncomes() 
        { 
            return incomes; 
        }

        public List<Outcomes> GetOutcomes()
        {
            return outcomes;
        }

        public override string ToString()
        {
            return $"Your current balance is {balance}";
        }
    }
}
