using System.Collections.Generic;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IClock clock;
        private List<Transaction> transactions = new List<Transaction>();

        public TransactionRepository(IClock clock)
        {
            this.clock = clock;
        }

        public void AddDeposit(int amount)
        {
            var deposit = new Transaction(clock.TodayAsString(), amount);
            transactions.Add(deposit);
        }

        public void AddWithdrawal(int amount)
        {
            var withdrawal = new Transaction(clock.TodayAsString(), -amount);
            transactions.Add(withdrawal);
        }

        public List<Transaction> AllTransactions()
        {
            return transactions;
        }
    }
}