using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string STATEMENT_HEADER = "DATE | AMOUNT | BALANCE";
        private readonly IConsole console;

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

        public void Print(List<Transaction> transactions)
        {
            this.console.PrintLine(STATEMENT_HEADER);
            FormattedStatementLines(transactions)
                .Reverse()
                .ToList()
                .ForEach(PrintStatementLine);
        }

        private IEnumerable<string> FormattedStatementLines(List<Transaction> transactions)
        {
            int runningBalance = 0;
            foreach (var transaction in transactions)
            {
                runningBalance += transaction.Amount;
                yield return FormattedStatementLine(transaction, runningBalance);
            }
        }

        private void PrintStatementLine(string statementLine)
        {
            this.console.PrintLine(statementLine);
        }

        private string FormattedStatementLine(Transaction transaction, int runningBalance)
        {
            var formattedTransactionLine = $"{transaction.Date} | {transaction.Amount:0.00} | {runningBalance:0.00}";
            return formattedTransactionLine;
        }
    }
}