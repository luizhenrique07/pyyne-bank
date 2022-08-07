using Pyyne.Domain.Bank;
using Pyyne.Services.Bank.BankIntegrations.Bank1;
using Pyyne.Services.Bank.BankIntegrations.Bank2;

namespace Pyyne.Services.Bank
{
    public class BankAccountSource : IBankAccountSource
    {
        private readonly IBankAccountSource _bankSource;

        public BankAccountSource(BankTypeEnum bankType)
        {

            // to create a new bank integration, create a wrapper that inherits from IBankAccountSource and add it here
            var banks = new Dictionary<BankTypeEnum, Func<IBankAccountSource>>()
            {
                { BankTypeEnum.Bank1, () => new Bank1AccountSourceWrapper() },
                { BankTypeEnum.Bank2, () => new Bank2AccountSourceWrapper() }
            };

            _bankSource = banks[bankType].Invoke();
        }

        public double GetAccountBalance(long accountId)
        {
            return _bankSource.GetAccountBalance(accountId);
        }

        public string GetAccountCurrency(long accountId)
        {
            return _bankSource.GetAccountCurrency(accountId);
        }

        public List<BankAccountTransaction> GetTransactions(long accountId, DateTime fromDate, DateTime toDate)
        {
            return _bankSource.GetTransactions(accountId, fromDate, toDate);
        }
    }
}
