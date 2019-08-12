using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class AccountShould
    {
        private ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        private IStatementPrinter statementPrinter = Substitute.For<IStatementPrinter>();
        private Account account;

        [SetUp]
        public void Setup()
        {
            account = new Account(transactionRepository, statementPrinter);
        }

        [Test]
        public void Store_A_Deposit_Transaction()
        {
            account.Deposit(100);
            transactionRepository.Received().AddDeposit(100);
        }

        [Test]
        public void Store_A_Withdrawal_Transaction()
        {
            account.Withdraw(100);
            transactionRepository.Received().AddWithdrawal(100);
        }

        [Test]
        public void Print_A_Statement()
        {
            List<Transaction> transactions = new List<Transaction> { new Transaction("10/08/2019", 100) };
            transactionRepository.AllTransactions().Returns(transactions);

            account.PrintStatement();

            statementPrinter.Received().Print(transactions);
        }
    }
}