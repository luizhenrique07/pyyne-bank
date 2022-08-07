namespace Pyyne.Services.Bank.BankIntegrations.Bank2
{
    public class Bank2AccountTransaction
    {
        public enum TRANSACTION_TYPES
        {
            DEBIT, CREDIT
        }

        private double amount;
        private TRANSACTION_TYPES type;
        private string text;

        public Bank2AccountTransaction(double amount, TRANSACTION_TYPES type, string text)
        {
            this.amount = amount;
            this.type = type;
            this.text = text;
        }

        public double GetAmount()
        {
            return amount;
        }

        public TRANSACTION_TYPES GetType()
        {
            return type;
        }

        public string GetText()
        {
            return text;
        }

    }
}
