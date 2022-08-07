namespace Pyyne.Domain.Bank
{
    public class BankAccountTransaction
    {
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public string Text { get; set; }
    }
}
