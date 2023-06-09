using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using Domain;
using Domain.IRepositories;
using Infrastructure.Data.DBModel;

namespace Infrastructure.Data
{

    public class AccountRepository : IAccountRepository
    
    {
        private readonly BankAccountEntities _dbConnection;

        public AccountRepository()
        {
            _dbConnection = new BankAccountEntities();
        }

        #region CRUD

        //Create new element
        public Account Create(Account newElementFromDomain)
        {
            Account result = null;

            BankAccount dataToSaveInDB = new BankAccount
            {
                AccountNumber = newElementFromDomain.accountNumber.ToString(),
                AccountPin = newElementFromDomain.pass.ToString(),
                Balance = newElementFromDomain.balance,
                Incomes = new List<Incomes>(),
                Outcomes = new List<Outcomes>(),
            };

            _dbConnection.BankAccount.Add(dataToSaveInDB);
            _dbConnection.SaveChanges();

            foreach (var domainIncomes in newElementFromDomain.incomes)
            {
                dataToSaveInDB.Incomes.Add(new Incomes
                {
                    Ingresos = domainIncomes.incomes,
                    BankAccountId = dataToSaveInDB.Id,
                    BankAccount = dataToSaveInDB
                });
            }

            _dbConnection.SaveChanges();

            foreach (var domainOutcomes in newElementFromDomain.outcomes)
            {
                dataToSaveInDB.Outcomes.Add(new Outcomes
                {
                    Retiradas = domainOutcomes.outcomes,
                    BankAccountId = dataToSaveInDB.Id,
                    BankAccount = dataToSaveInDB
                });
            }

            _dbConnection.SaveChanges();

            result = newElementFromDomain;

            return result;
        }

        public Account GetById(string AccountId)
        {
            Account result = null;

            BankAccount retrievedData =
                _dbConnection.BankAccount.FirstOrDefault(x => x.AccountNumber == AccountId);

            if (retrievedData != null)
            {
                result = new Account
                {
                    accountNumber = int.Parse(retrievedData.AccountNumber),
                    pass = int.Parse(retrievedData.AccountPin),
                    balance = retrievedData.Balance,
                    incomes = new List<Income>(),
                    outcomes = new List<Outcome>()
                };
                foreach (Incomes RelatedIncome in retrievedData.Incomes)
                {
                    result.incomes.Add(new Income
                    {
                        incomes = RelatedIncome.Ingresos
                    });
                }
                foreach (Outcomes RelatedOutcome in retrievedData.Outcomes)
                {
                    result.outcomes.Add(new Outcome
                    {
                        outcomes = RelatedOutcome.Retiradas
                    });
                }
            }

            return result;
        }

        public List<Account> GetListFromDB()
        {
            List<Account> result = null;

            List<BankAccount> retrievedList = _dbConnection.BankAccount.ToList();

            if (retrievedList != null)
            {
                result = new List<Account>();

                foreach (BankAccount retrievedElement in retrievedList)
                {
                    result.Add(new Account
                    {
                        accountNumber = int.Parse(retrievedElement.AccountNumber),
                        pass = int.Parse(retrievedElement.AccountPin),
                        balance = retrievedElement.Balance,
                        incomes = new List<Income>(),
                        outcomes = new List<Outcome>()
                    });
                    foreach (Incomes RelatedIncome in retrievedElement.Incomes)
                    {
                        result.Last().incomes.Add(new Income
                        {
                            incomes = RelatedIncome.Ingresos
                        });
                    }
                    foreach (Outcomes RelatedOutcome in retrievedElement.Outcomes)
                    {
                        result.Last().outcomes.Add(new Outcome
                        {
                            outcomes = RelatedOutcome.Retiradas
                        });
                    }
                }
            }

            return result;
        }

        public Account Update(Account bankAccount)
        {
            Account result = null;

            BankAccount retrievedData =
                _dbConnection.BankAccount.FirstOrDefault(x => x.AccountNumber ==
                                        bankAccount.accountNumber.ToString());

            if (retrievedData != null)
            {
                retrievedData.AccountNumber = bankAccount.accountNumber.ToString();
                retrievedData.AccountPin = bankAccount.pass.ToString();
                retrievedData.Balance = bankAccount.balance;

                foreach (Income movementFromDomain in bankAccount.incomes)
                {
                    if (!retrievedData.Incomes.Any(x => x.Ingresos == movementFromDomain.incomes))
                    {
                        retrievedData.Incomes.Add(new Incomes
                        {
                            Ingresos = movementFromDomain.incomes,
                            BankAccountId = int.Parse(retrievedData.AccountNumber),
                            BankAccount = retrievedData
                        });
                    }
                }
                foreach (Outcome movementFromDomain in bankAccount.outcomes)
                {
                    if (!retrievedData.Outcomes.Any(x => x.Retiradas == movementFromDomain.outcomes))
                    {
                        retrievedData.Outcomes.Add(new Outcomes
                        {
                            Retiradas = movementFromDomain.outcomes,
                            BankAccountId = int.Parse(retrievedData.AccountNumber),
                            BankAccount = retrievedData
                        });
                    }
                }

                _dbConnection.SaveChanges();

                result = bankAccount;
            }

            return result;
        }


        public bool PhysicalRemoveById(string AccountId)
        {
            bool result = false;

            BankAccount retrievedData = _dbConnection.BankAccount.FirstOrDefault
                (x => x.AccountNumber == AccountId);

            if (retrievedData != null)
            {
                if (retrievedData.Incomes.Count() > 0)
                {
                    _dbConnection.Incomes.RemoveRange(retrievedData.Incomes);
                }

                if (retrievedData.Outcomes.Count() > 0)
                {
                    _dbConnection.Outcomes.RemoveRange(retrievedData.Outcomes);
                }

                _dbConnection.BankAccount.Remove(retrievedData);
                _dbConnection.SaveChanges();

                result = true;
            }

            return result;
        }

        
        public List<Account> GetBankAccountList()
        {
            BankAccountEntities dbConnection = new BankAccountEntities();

            List<BankAccount> bankAccountsListFromDB = dbConnection.BankAccount.ToList();

            List<Account> result = new List<Account>();

            foreach (BankAccount bankAccountFromDB in bankAccountsListFromDB)
            {
                result.Add(new Account
                {
                    accountNumber = int.Parse(bankAccountFromDB.AccountNumber),
                    pass = int.Parse(bankAccountFromDB.AccountPin),
                    balance = bankAccountFromDB.Balance,
                    incomes = bankAccountFromDB.Incomes.ToList().Select(x => new Income
                    {
                        incomes = x.Ingresos
                    }).ToList(),
                    outcomes = bankAccountFromDB.Outcomes.ToList().Select(x => new Outcome
                    {
                        outcomes = x.Retiradas
                    }).ToList()
                });
            }

            return result;
        }

        #endregion


        // devuelve el objeto BankAccount almacenado en el campo _bankAccount.
        // Este método se utiliza para obtener los datos de la cuenta bancaria.
        public Account GetBankAccount()
        {
            return null;
        }

        // recibe un objeto BankAccount llamado newDataForBankAccount y actualiza el
        // campo _bankAccount con los nuevos datos proporcionados. Este método se utiliza
        // para establecer los datos de la cuenta bancaria.
        public void SetBankAccount(Account newDataForBankAccount)
        {
            //_account = newDataForBankAccount;
        }
    }
}
