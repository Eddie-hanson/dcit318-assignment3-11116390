using System;
using System.Collections.Generic;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Processors;
using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Interfaces;
using System.Transactions;






namespace FinanceManagementSystem
    {
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new List<Transaction>(); // Fixed CS8370 by explicitly specifying the type

        public void Run()
        {
            Console.WriteLine("=== Finance Management System ===");

            var account = new SavingsAccount("ACC-1001", 1000m);

            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 700m, "Entertainment");

            ITransactionProcessor mobileMoney = new MobileMoneyProcessor();
            ITransactionProcessor bankTransfer = new BankTransferProcessor();
            ITransactionProcessor cryptoWallet = new CryptoWalletProcessor();

            mobileMoney.Process(t1);
            bankTransfer.Process(t2);
            cryptoWallet.Process(t3);

            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            _transactions.AddRange(new[] { t1, t2, t3 });

            Console.WriteLine("\nTransactions recorded:");
            foreach (var tx in _transactions)
            {
                Console.WriteLine($"  #{tx.Id} | {tx.Date:g} | {tx.Amount:C} | {tx.Category}");
            }

            Console.WriteLine("\n=== End ===");
        }
    }
}


