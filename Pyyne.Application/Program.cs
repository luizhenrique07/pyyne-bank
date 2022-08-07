using Pyyne.Application;

var bank = new BankController();

bank.PrintBalances(100);
bank.PrintTransactions(100, DateTime.Now, DateTime.Now);