using System;
using FinanceManagementSystem.Models;

namespace FinanceManagementSystem.Accounts
{
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty.", nameof(accountNumber));
            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void ApplyTransaction(Transaction transaction)
        {
            if (transaction is null) throw new ArgumentNullException(nameof(transaction));
            Balance -= transaction.Amount;
            Console.WriteLine($"[Account {AccountNumber}] Applied transaction of {transaction.Amount:C}. New balance: {Balance:C}");
        }
    }
}
