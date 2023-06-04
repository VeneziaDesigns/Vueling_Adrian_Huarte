using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;

namespace Infrastructure.Data
{

    public class AccountRepository : IAccountRepository
    
    {
        private Account _account;


        public AccountRepository()
        {
            _account = new Account()
            {
                balance = 1000,
                incomes = new List<Incomes>(),
                outcomes = new List<Outcomes>(),
            };
        }

        // devuelve el objeto BankAccount almacenado en el campo _bankAccount.
        // Este método se utiliza para obtener los datos de la cuenta bancaria.
        public Account GetBankAccount()
        {
            return _account;
        }

        // recibe un objeto BankAccount llamado newDataForBankAccount y actualiza el
        // campo _bankAccount con los nuevos datos proporcionados. Este método se utiliza
        // para establecer los datos de la cuenta bancaria.
        public void SetBankAccount(Account newDataForBankAccount)
        {
            _account = newDataForBankAccount;
        }
    }
}
