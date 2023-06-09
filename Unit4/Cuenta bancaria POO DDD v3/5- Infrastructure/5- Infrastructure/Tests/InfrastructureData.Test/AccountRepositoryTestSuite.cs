using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Domain;
using Infrastructure.Data;
using Xunit;

namespace InfrastructureData.Test
{
    public class AccountRepositoryTestSuite
    {
        private readonly AccountRepository _repository;

        public AccountRepositoryTestSuite()
        {
            _repository = new AccountRepository();
        }

        [Fact]
        public void Create_InputValid_returnNothing()
        {
            //Arrange
            Account account = new Account
            {
                accountNumber = 3,
                pass = 3333,
                balance = 504,
                incomes = new List<Income> 
                { 
                    new Income 
                    { 
                        incomes = 655 
                    } 
                },

                outcomes = new List<Outcome> 
                { 
                    new Outcome 
                    { 
                        outcomes = 725 
                    } 
                }
            };

            AccountRepository repository = new AccountRepository();

            //Act
            Account result = repository.Create(account);

            //Assert
            Assert.Equal(account.balance, result.balance);
        }

        [Fact]
        public void GetById_InputExistingElementId_ReturnsExistingElement()
        {
            //Arrange
            string AccountId = "1";

            //Act
            Account result = _repository.GetById(AccountId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetListFromDB_InputEmpty_ReturnAllElement()
        {
            // Arrange

            // Act
            List<Account> result = _repository.GetListFromDB();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Update_InputExistingWithDifferentValues_ReturnExistingElementWithModifiedValues()
        {
            // Arrange
            Account ba = new Account
            {
                balance = 13475,
                accountNumber = 3,
                pass = 3333,
                incomes = new List<Income>
                {
                    new Income { incomes = 8739 }
                },
                outcomes = new List<Outcome>
                {
                    new Outcome { outcomes = 5763}
                }
            };

            // Act
            Account result = _repository.Update(ba);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void PhysicalRemoveById_InputExistingId_ReturnTrue()
        {
            // Arrange
            string AccountNumber = "3";

            // Act
            bool result = _repository.PhysicalRemoveById(AccountNumber);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetBankAccountList_ReturnsCorrectAccountList()
        {
            // Arrange
            List<Account> result = new List<Account>();
            int expectedCount = 3;
            int expectedAccountNumber = 1;
            int expectedAccountPin = 1111;
            decimal expectedBalance = 1500;

            // Act
            result = _repository.GetBankAccountList();

            // Assert
            Assert.Equal(expectedCount, result.Count);
            Assert.Equal(expectedAccountNumber, result[0].accountNumber);
            Assert.Equal(expectedAccountPin, result[0].pass);
            Assert.Equal(expectedBalance, result[0].balance);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }
    }
}
