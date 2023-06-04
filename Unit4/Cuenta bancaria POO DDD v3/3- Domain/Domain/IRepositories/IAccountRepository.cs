namespace Domain.IRepositories
{
    public interface IAccountRepository
    {
        Account GetBankAccount();
        void SetBankAccount(Account newDataForBankAccount);
    }
}