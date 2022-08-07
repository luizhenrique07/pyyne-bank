using Bogus;
using Pyyne.Domain.Bank;
using Pyyne.Services.Bank;
using Pyyne.Services.Bank.BankIntegrations.Bank1;
using Pyyne.Services.Bank.BankIntegrations.Bank2;
using System;
using System.Linq;
using Xunit;

namespace Pyyne.Test.Services
{
    public class BankAccountSourceTest
    {
        private readonly long _accountId;

        public BankAccountSourceTest()
        {
            _accountId = new Faker().Random.Long();
        }

        [Fact]
        public void ShouldReturnBank1Currency()
        {
            var bank1 = new Bank1AccountSource();

            var bank = new BankAccountSource(BankTypeEnum.Bank1);

            Assert.Equal(bank1.GetAccountCurrency(_accountId), bank.GetAccountCurrency(_accountId));
        }

        [Fact]
        public void ShouldReturnBank1Balance()
        {
            var bank1 = new Bank1AccountSource();

            var bank = new BankAccountSource(BankTypeEnum.Bank1);

            Assert.Equal(bank1.GetAccountBalance(_accountId), bank.GetAccountBalance(_accountId));
        }

        [Fact]
        public void ShouldReturnBank1Transactions()
        {
            var bank1 = new Bank1AccountSource();
            var bank1Transactions = bank1.GetTransactions(_accountId, DateTime.Now, DateTime.Now);

            var bank = new BankAccountSource(BankTypeEnum.Bank1);
            var bankTransactions = bank.GetTransactions(_accountId, DateTime.Now, DateTime.Now);

            Assert.Equal(bankTransactions.Count, bank1Transactions.Count);
            Assert.Equal(bankTransactions.FirstOrDefault()?.Amount, bank1Transactions.FirstOrDefault()?.GetAmount());
        }

        [Fact]
        public void ShouldReturnBank2Currency()
        {
            var bank2 = new Bank2AccountSource();
            var bank2Balance = bank2.GetBalance(_accountId);

            var bank = new BankAccountSource(BankTypeEnum.Bank2);

            Assert.Equal(bank2Balance.GetCurrency(), bank.GetAccountCurrency(_accountId));
        }

        [Fact]
        public void ShouldReturnBank2Balance()
        {
            var bank2 = new Bank2AccountSource();
            var bank2Balance = bank2.GetBalance(_accountId);

            var bank = new BankAccountSource(BankTypeEnum.Bank2);

            Assert.Equal(bank2Balance.GetBalance(), bank.GetAccountBalance(_accountId));
        }

        [Fact]
        public void ShouldReturnBank2Transactions()
        {
            var bank2 = new Bank2AccountSource();
            var bank2Transactions = bank2.GetTransactions(_accountId, DateTime.Now, DateTime.Now);

            var bank = new BankAccountSource(BankTypeEnum.Bank2);
            var bankTransactions = bank.GetTransactions(_accountId, DateTime.Now, DateTime.Now);

            Assert.Equal(bankTransactions.Count, bank2Transactions.Count);
            Assert.Equal(bankTransactions.FirstOrDefault()?.Amount, bank2Transactions.FirstOrDefault()?.GetAmount());
        }
    }
}
