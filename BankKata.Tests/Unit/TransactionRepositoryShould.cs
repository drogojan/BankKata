using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        public const string TODAY = "10/08/2019";
        private IClock clock = Substitute.For<IClock>();
        private TransactionRepository transactionRepository;

        [SetUp]
        public void Setup()
        {
            clock.TodayAsString().Returns(TODAY);
            transactionRepository = new TransactionRepository(clock);
        }

        [Test]
        public void Create_And_Store_A_Deposit_Transaction()
        {
            transactionRepository.AddDeposit(100);

            List<Transaction> transactions = transactionRepository.AllTransactions();

            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(transactions.First(), new Transaction(TODAY, 100));
        }

        [Test]
        public void Create_And_Store_A_Withdrawal_Transaction()
        {
            transactionRepository.AddWithdrawal(100);

            List<Transaction> transactions = transactionRepository.AllTransactions();

            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(transactions.First(), new Transaction(TODAY, -100));
        }
    }
}