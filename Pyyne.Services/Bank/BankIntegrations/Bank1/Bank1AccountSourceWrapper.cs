using Pyyne.Domain.Bank;

namespace Pyyne.Services.Bank.BankIntegrations.Bank1
{
    public class Bank1AccountSourceWrapper : IBankAccountSource
    {
        private readonly Bank1AccountSource _bankAccountSource;

        public Bank1AccountSourceWrapper()
        {
            _bankAccountSource = new Bank1AccountSource();
        }

        public double GetAccountBalance(long accountId)
        {
            return _bankAccountSource.GetAccountBalance(accountId);
        }

        public string GetAccountCurrency(long accountId)
        {
            return _bankAccountSource.GetAccountCurrency(accountId);
        }

        public List<BankAccountTransaction> GetTransactions(long accountId, DateTime fromDate, DateTime toDate)
        {
            var transactions = _bankAccountSource.GetTransactions(accountId, fromDate, toDate);

            return transactions.Select(x => new BankAccountTransaction
            {
                Amount = x.GetAmount(),
                Text = x.GetText(),
                Type = x.GetType() == Bank1Transaction.TYPE_DEBIT ? TransactionTypeEnum.Debit : TransactionTypeEnum.Credit,
            }).ToList();
        }
    }
}
