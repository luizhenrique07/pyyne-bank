namespace Pyyne.Domain.Bank
{
    public interface IBankAccountSource
    {
        public double GetAccountBalance(long accountId);
        public string GetAccountCurrency(long accountId);
        public List<BankAccountTransaction> GetTransactions(long accountId, DateTime fromDate, DateTime toDate);
    }
}
