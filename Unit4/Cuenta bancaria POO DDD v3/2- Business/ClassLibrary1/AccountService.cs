using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;
using Infrastructure.Data;
using Unity;

namespace Business
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public decimal? AniadirIngreso(decimal cash)
        {
            decimal? result = null;

            bool ValidIncome = cash > 0;

            if (ValidIncome)
            {
                Account accountData = _repository.GetBankAccount();

                accountData.AddIncomes(cash);
                
                _repository.SetBankAccount(accountData);

                result = accountData.balance;
            }
            
            return result;
        }

        public decimal? AniadirGasto(decimal cash)
        {
            decimal? result = null;

            Account accountData = _repository.GetBankAccount();

            bool ValidOutcome = cash > 0;

            bool sufficientBalance = accountData.balance - cash >= 0;

            if (ValidOutcome && sufficientBalance)
            {
                accountData.AddOutcomes(cash);
                
                _repository.SetBankAccount(accountData);

                result = accountData.balance;
            }

            return result;
        }

        public List<Incomes> IncomesList()
        {
            Account accountData = _repository.GetBankAccount();

            List<Incomes> incomes = accountData.incomes;

            return incomes;
        }

        public List<Outcomes> OutcomesList()
        {
            Account accountData = _repository.GetBankAccount();

            List<Outcomes> outcomes = accountData.outcomes;

            return outcomes;
        }

        public string Balance()
        {
            Account accountData = _repository.GetBankAccount();

            string balance = accountData.ToString();

            return balance;
        }
    }
}
