using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.tests
{
    public class DomainTest
    {
        private Account InitializeAccount()
        {
            return new Account
            {
                balance = 0,
                incomes = new List<Incomes>(),
                outcomes = new List<Outcomes>(),
            };
        }
           
        [Fact]
        //          NombreMetodo_Input_Output/Throws
        public void AddIncomes_InputPositive_ReturnPositive()
        {
            // Arrange => Inicializacion de variables
            Account account = InitializeAccount();
            int income = 1;

            // Act => Llamamos al metodo a testear
            decimal? result = account.AddIncomes(income);

            // Assert => Verificar resultado
            Assert.True(result > 0);
        }

        [Fact]
        public void AddOutcomes_InputPositive_ReturnPositive()
        {
            // Arrange
            Account account = InitializeAccount();
            int income = 1;

            // Act
            decimal? result = account.AddIncomes(income);

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void GetIncomes_InputList_ReturnCountList()
        {
            // Arrange
            Account account = InitializeAccount();
            int income = 100;
            account.AddIncomes(income);

            // Act
            List<Incomes> incomes = account.GetIncomes();

            // Assert
            Assert.True(incomes.Count == 1);
        }

        [Fact]
        public void GetOutcomes_InputList_ReturnCountList()
        {
            // Arrange
            Account account = InitializeAccount();
            int income1 = 100;
            int income2 = 500;
            account.AddOutcomes(income1);
            account.AddOutcomes(income2);

            // Act
            List<Outcomes> incomes = account.GetOutcomes();

            // Assert
            Assert.True(incomes.Count == 2);
        }

//--------------------------------------------------------------------------------------------------------

        [Fact]
        public void AddIncomes_ShouldIncreaseBalanceAndAddIncome()
        {
            // Arrange
            decimal initialBalance = 1000;
            decimal incomeAmount = 500;
            decimal expectedBalance = initialBalance + incomeAmount;

            var account = new Account();

            // Act
            decimal newBalance = account.AddIncomes(incomeAmount);
            List<Incomes> incomes = account.GetIncomes();

            // Assert
            Assert.Equal(expectedBalance, newBalance);
            Assert.Single(incomes);
            Assert.Equal(incomeAmount, incomes[0].incomes);
        }

        [Fact]
        public void AddOutcomes_ShouldDecreaseBalanceAndAddOutcome()
        {
            // Arrange
            decimal initialBalance = 1000;
            decimal outcomeAmount = 200;
            decimal expectedBalance = initialBalance - outcomeAmount;

            var account = new Account();

            // Act
            decimal newBalance = account.AddOutcomes(outcomeAmount);
            List<Outcomes> outcomes = account.GetOutcomes();

            // Assert
            Assert.Equal(expectedBalance, newBalance);
            Assert.Single(outcomes);
            Assert.Equal(outcomeAmount, outcomes[0].outcomes);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedBalanceString()
        {
            // Arrange
            decimal balance = 1500;
            var account = new Account();
            account.balance = balance;
            string expectedString = $"Your current balance is {balance}";

            // Act
            string balanceString = account.ToString();

            // Assert
            Assert.Equal(expectedString, balanceString);
        }
    }
}
