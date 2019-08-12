namespace BankKata
{
    public class Account
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IStatementPrinter statementPrinter;

        public Account(ITransactionRepository transactionRepository, IStatementPrinter statementPrinter)
        {
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            statementPrinter.Print(transactionRepository.AllTransactions());
        }
    }
}