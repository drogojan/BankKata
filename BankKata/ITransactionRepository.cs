﻿using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionRepository
    {
        void AddDeposit(int amount);
        void AddWithdrawal(int amount);
        List<Transaction> AllTransactions();
    }
}