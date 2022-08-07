namespace Pyyne.Services.Bank.BankIntegrations.Bank2
{
    public class Bank2AccountBalance
    {
        private double balance;
        private string currency;

        public Bank2AccountBalance(double balance, string currency)
        {
            this.balance = balance;
            this.currency = currency;
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetCurrency()
        {
            return currency;
        }
    }
}
