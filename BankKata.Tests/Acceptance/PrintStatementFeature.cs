using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BankKata.Tests.Acceptance
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private IConsole console = Substitute.For<IConsole>();
        IClock clock = Substitute.For<IClock>();

        private Account account;

        [SetUp]
        public void Setup()
        {
            ITransactionRepository transactionRepository = new TransactionRepository(clock);
            IStatementPrinter statementPrinter = new StatementPrinter(console);
            account = new Account(transactionRepository, statementPrinter);
        }

        [Test]
        public void Print_Statement_Contains_All_Transactions()
        {
            clock.TodayAsString().Returns("01/04/2014");
            account.Deposit(1000);
            clock.TodayAsString().Returns("02/04/2014");
            account.Withdraw(100);
            clock.TodayAsString().Returns("10/04/2014");
            account.Deposit(500);

            account.PrintStatement();

            Received.InOrder(() => {
                console.PrintLine("DATE | AMOUNT | BALANCE");
                console.PrintLine("10/04/2014 | 500.00 | 1400.00");
                console.PrintLine("02/04/2014 | -100.00 | 900.00");
                console.PrintLine("01/04/2014 | 1000.00 | 1000.00");
            });
        }
    }
}