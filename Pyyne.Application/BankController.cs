using Pyyne.Domain.Bank;
using Pyyne.Services.Bank;

namespace Pyyne.Application
{
    public class BankController
    {
        public void PrintBalances(long accountId)
        {
            Console.WriteLine("Implement me to pull balance information from all available bank integrations and display them, one after the other.");
            var allBankIntegrations = Enum.GetValues(typeof(BankTypeEnum));
            foreach (var bankType in allBankIntegrations)
            {
                var bank = new BankAccountSource((BankTypeEnum)bankType);

                Console.WriteLine($"Bank integration: {bankType} / Balance: {bank.GetAccountCurrency(accountId)} {bank.GetAccountBalance(accountId)}");
            }
        }

        public void PrintTransactions(long accountId, DateTime fromDate, DateTime toDate)
        {
            Console.WriteLine("Implement me to pull transactions from all available bank integrations and display them, one after the other.");
            var allBankIntegrations = Enum.GetValues(typeof(BankTypeEnum));
            foreach (var bankType in allBankIntegrations)
            {
                var bank = new BankAccountSource((BankTypeEnum)bankType);
                var currency = bank.GetAccountCurrency(accountId);

                foreach (var transaction in bank.GetTransactions(accountId, fromDate, toDate))
                {
                    Console.WriteLine($"Bank integration: {bankType} / Type: {transaction.Type} - Text {transaction.Text} - Amount {currency} {transaction.Amount}");
                }
            }
        }
    }
}