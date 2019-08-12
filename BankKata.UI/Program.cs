using System;

namespace BankKata.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IClock clock = new Clock();
            ITransactionRepository transactionRepository = new TransactionRepository(clock);
            IConsole console = new Console();
            IStatementPrinter statementPrinter = new StatementPrinter(console);
            Account account = new Account(transactionRepository, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();
        }
    }
}
