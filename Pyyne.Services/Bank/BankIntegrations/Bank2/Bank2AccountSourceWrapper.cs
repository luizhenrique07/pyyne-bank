using Pyyne.Domain.Bank;

namespace Pyyne.Services.Bank.BankIntegrations.Bank2
{
    public class Bank2AccountSourceWrapper : IBankAccountSource
    {
        private readonly Bank2AccountSource _bankAccountSource;
        public Bank2AccountSourceWrapper()
        {
            _bankAccountSource = new Bank2AccountSource();
        }
        public double GetAccountBalance(long accountId)
        {
            return _bankAccountSource.GetBalance(accountId).GetBalance();
        }

        public string GetAccountCurrency(long accountId)
        {
            return _bankAccountSource.GetBalance(accountId).GetCurrency();
        }

        public List<BankAccountTransaction> GetTransactions(long accountId, DateTime fromDate, DateTime toDate)
        {
            var transactions = _bankAccountSource.GetTransactions(accountId, fromDate, toDate);

            return transactions.Select(x => new BankAccountTransaction
            {
                Amount = x.GetAmount(),
                Text = x.GetText(),
                Type = x.GetType() == Bank2AccountTransaction.TRANSACTION_TYPES.DEBIT ? TransactionTypeEnum.Debit : TransactionTypeEnum.Credit,
            }).ToList();
        }
    }
}
