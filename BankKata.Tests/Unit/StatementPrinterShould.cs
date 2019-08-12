using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class StatementPrinterShould
    {
        
        private List<Transaction> NO_TRANSACTIONS = new List<Transaction>();

        [Test]
        public void Always_Print_The_Header()
        {
            IConsole console = Substitute.For<IConsole>();
            StatementPrinter statementPrinter = new StatementPrinter(console);

            statementPrinter.Print(NO_TRANSACTIONS);

            console.Received().PrintLine("DATE | AMOUNT | BALANCE");
        }

        [Test]
        public void Print_Transactions_In_Reverse_Chronological_Order()
        {
            IConsole console = Substitute.For<IConsole>();
            StatementPrinter statementPrinter = new StatementPrinter(console);

            List<Transaction> transactions = new List<Transaction>
            {
                Deposit("01/04/2014", 1000),
                Withdrawal("02/04/2014", 100),
                Deposit("10/04/2014", 500)
            };

            statementPrinter.Print(transactions);

            Received.InOrder(() => {
                console.PrintLine("DATE | AMOUNT | BALANCE");
                console.PrintLine("10/04/2014 | 500.00 | 1400.00");
                console.PrintLine("02/04/2014 | -100.00 | 900.00");
                console.PrintLine("01/04/2014 | 1000.00 | 1000.00");
            });
        }

        private Transaction Withdrawal(string date, int amount)
        {
            return new Transaction(date, -amount);
        }

        private Transaction Deposit(string date, int amount)
        {
            return new Transaction(date, amount);
        }
    }
}