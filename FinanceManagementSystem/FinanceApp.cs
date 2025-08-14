using System;
using System.Collections.Generic;
using FinanceManagementSystem.Models;
using FinanceManagementSystem.Processors;
using FinanceManagementSystem.Accounts;
using FinanceManagementSystem.Interfaces;
using System.Transactions;
using MyTransaction = FinanceManagementSystem.Models.Transaction; // Alias for your Transaction class






// namespace FinanceManagementSystem
//     {
//     public class FinanceApp
//     {
//         private readonly List<Transaction> _transactions = new List<Transaction>(); // Fixed CS8370 by explicitly specifying the type

//         public void Run()
//         {
//             Console.WriteLine("=== Finance Management System ===");

//             var account = new SavingsAccount("ACC-1001", 1000m);

//             var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
//             var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
//             var t3 = new Transaction(3, DateTime.Now, 700m, "Entertainment");

//             ITransactionProcessor mobileMoney = new MobileMoneyProcessor();
//             ITransactionProcessor bankTransfer = new BankTransferProcessor();
//             ITransactionProcessor cryptoWallet = new CryptoWalletProcessor();

//             mobileMoney.Process(t1);
//             bankTransfer.Process(t2);
//             cryptoWallet.Process(t3);

//             account.ApplyTransaction(t1);
//             account.ApplyTransaction(t2);
//             account.ApplyTransaction(t3);

//             _transactions.AddRange(new[] { t1, t2, t3 });

//             Console.WriteLine("\nTransactions recorded:");
//             foreach (var tx in _transactions)
//             {
//                 Console.WriteLine($"  #{tx.Id} | {tx.Date:g} | {tx.Amount:C} | {tx.Category}");
//             }

//             Console.WriteLine("\n=== End ===");
//         }
//     }
// }




namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        private List<MyTransaction> transactions = new List<MyTransaction>();

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Finance Management System ===");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View All Transactions");
                Console.WriteLine("3. Calculate Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddTransaction();
                        break;
                    case "2":
                        ViewTransactions();
                        break;
                    case "3":
                        CalculateBalance();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting Finance Management System...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddTransaction()
{
    try
    {
        Console.Write("Enter Transaction ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Category (e.g., BankTransfer, Crypto, MobileMoney): ");
        string category = Console.ReadLine();

        MyTransaction transaction = new MyTransaction(id, DateTime.Now, amount, description, category);
        transactions.Add(transaction);

        Console.WriteLine("Transaction added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error adding transaction: {ex.Message}");
    }
}

        private void ViewTransactions()
        {
            Console.WriteLine("\n--- All Transactions ---");
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            foreach (var t in transactions)
            {
                Console.WriteLine($"ID: {t.Id}, Date: {t.Date}, Amount: {t.Amount:C}, Description: {t.Description}");
            }
        }

        private void CalculateBalance()
        {
            decimal balance = 0;
            foreach (var t in transactions)
            {
                balance += t.Amount;
            }
            Console.WriteLine($"\nCurrent Balance: {balance:C}");
        }
    }
}
