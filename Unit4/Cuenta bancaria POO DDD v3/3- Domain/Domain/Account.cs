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

            Console.WriteLine($"Su saldo actual es de {balance}");

            return balance;
        }
        public void AddOutcomes(decimal cash)
        {
            if (balance < cash)
            {
                Console.WriteLine("El saldo de la cuenta es insuficiente");
            }
            else
            {
                balance -= cash;

                outcomes.Add(new Outcomes(cash));

                Console.WriteLine($"Su saldo actual es de {balance}");
            }
        }
    }
}
