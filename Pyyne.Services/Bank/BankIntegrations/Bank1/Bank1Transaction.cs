namespace Pyyne.Services.Bank.BankIntegrations.Bank1
{
    public class Bank1Transaction
    {
        public static int TYPE_CREDIT = 1;
        public static int TYPE_DEBIT = 2;

        private double amount;
        private int type;
        private string text;

        public Bank1Transaction(double amount, int type, string text)
        {
            this.amount = amount;
            this.type = type;
            this.text = text;
        }

        public double GetAmount()
        {
            return amount;
        }

        public new int GetType()
        {
            return type;
        }

        public string GetText()
        {
            return text;
        }
    }
}
