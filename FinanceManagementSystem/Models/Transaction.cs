using System;

namespace FinanceManagementSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // NEW property for processors

        public Transaction(int id, DateTime date, decimal amount, string description, string category)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
            Category = category;
        }
    }
}
