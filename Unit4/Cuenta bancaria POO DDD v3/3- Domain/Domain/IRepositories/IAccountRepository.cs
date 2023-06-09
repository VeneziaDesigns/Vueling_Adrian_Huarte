using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IAccountRepository
    {
        List<Account> GetBankAccountList();
        void SetBankAccount(Account newDataForBankAccount);

        Account Create(Account newElementFromDomain);

        Account GetById(string AccountId);

        List<Account> GetListFromDB();

        Account Update(Account bankAccount);

        bool PhysicalRemoveById(string AccountId);
        Account GetBankAccount();
    }
}