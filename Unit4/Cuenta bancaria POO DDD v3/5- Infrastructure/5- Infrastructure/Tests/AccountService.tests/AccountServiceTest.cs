using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Domain;
using Domain.IRepositories;
using Moq;
using Xunit;

namespace AccountServices.tests
{
    // Clase de pruebas unitarias para la clase AccountService.
    public class AccountServiceTests
    {
        // Instancia de un objeto simulado (mock) de la interfaz IAccountRepository.
        private readonly Mock<IAccountRepository> _repositoryMock;

        // Instancia de AccountService con el objeto simulado del repositorio inyectado en su constructor.
        private readonly AccountService _accountService;

        public AccountServiceTests()
        {
            _repositoryMock = new Mock<IAccountRepository>();

            // Crea una nueva instancia de la clase AccountService utilizando el objeto simulado
            // (_repositoryMock.Object) del repositorio de cuentas (IAccountRepository).
            _accountService = new AccountService(_repositoryMock.Object);
        }

        [Fact]
        public void AniadirIngreso_ValidCash_ReturnsNewBalance()
        {
            // Arrange
            decimal cash = 100;
            Account accountData = new Account();

            // Configura el comportamiento del objeto simulado del repositorio
            // para que devuelva accountData cuando se llama al método GetBankAccount().
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            decimal? result = _accountService.AniadirIngreso(cash);

            // Assert
            // Verifica que el resultado (result) sea igual al saldo (balance) de accountData.
            Assert.Equal(accountData.balance, result);

            // Verifica que el método SetBankAccount del repositorio se haya llamado
            // exactamente una vez con accountData como argumento.
            _repositoryMock.Verify(r => r.SetBankAccount(accountData), Times.Once);
        }

        [Fact]
        public void AniadirIngreso_InvalidCash_ReturnsNull()
        {
            // Arrange
            decimal cash = -50;

            // Act
            decimal? result = _accountService.AniadirIngreso(cash);

            // Assert
            Assert.Null(result);

            // Verifica que el método GetBankAccount() del repositorio no se haya llamado en ninguna ocasión.
            _repositoryMock.Verify(r => r.GetBankAccount(), Times.Never);

            // Verifica que el método SetBankAccount() del repositorio no se haya llamado en
            // ninguna ocasión con cualquier instancia de la clase Account como argumento.
            _repositoryMock.Verify(r => r.SetBankAccount(It.IsAny<Account>()), Times.Never);
        }

        [Fact]
        public void AniadirGasto_ValidCashAndSufficientBalance_ReturnsNewBalance()
        {
            // Arrange
            decimal cash = 50;
            Account accountData = new Account { balance = 100 };
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            decimal? result = _accountService.AniadirGasto(cash);

            // Assert
            Assert.Equal(accountData.balance, result);
            _repositoryMock.Verify(r => r.SetBankAccount(accountData), Times.Once);
        }

        [Fact]
        public void AniadirGasto_InvalidCash_ReturnsNull()
        {
            // Arrange
            decimal cash = -50;
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(new Account());

            // Act
            decimal? result = _accountService.AniadirGasto(cash);

            // Assert
            Assert.Null(result);
            _repositoryMock.Verify(r => r.GetBankAccount(), Times.Once);
            _repositoryMock.Verify(r => r.SetBankAccount(It.IsAny<Account>()), Times.Never);
        }


        [Fact]
        public void AniadirGasto_InsufficientBalance_ReturnsNull()
        {
            // Arrange
            decimal cash = 150;
            Account accountData = new Account { balance = 100 };
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            decimal? result = _accountService.AniadirGasto(cash);

            // Assert
            Assert.Null(result);
            _repositoryMock.Verify(r => r.SetBankAccount(It.IsAny<Account>()), Times.Never);
        }

        [Fact]
        public void IncomesList_ReturnsIncomesFromRepository()
        {
            // Arrange
            decimal amount1 = 204.68M;
            decimal amount2 = 634.84M;
            Account accountData = new Account();
            List<Income> expectedIncomes = new List<Income> { new Income(amount1), new Income(amount2) };
            accountData.incomes = expectedIncomes;
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            List<Income> incomes = _accountService.IncomesList();

            // Assert
            Assert.Equal(expectedIncomes, incomes);
        }

        [Fact]
        public void OutcomesList_ReturnsOutcomesFromRepository()
        {
            // Arrange
            decimal amount1 = 204.68M;
            decimal amount2 = 634.84M;
            Account accountData = new Account();
            List<Outcome> expectedOutcomes = new List<Outcome> { new Outcome(amount1), new Outcome(amount2) };
            accountData.outcomes = expectedOutcomes;
            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            List<Outcome> outcomes = _accountService.OutcomesList();

            // Assert
            Assert.Equal(expectedOutcomes, outcomes);
        }

        [Fact]
        public void Balance_ReturnsBalanceAsString()
        {
            // Arrange
            Account accountData = new Account { balance = 100 };

            _repositoryMock.Setup(r => r.GetBankAccount()).Returns(accountData);

            // Act
            string balance = _accountService.Balance();

            // Assert
            Assert.Equal(accountData.ToString(), balance);
        }
    }
}
