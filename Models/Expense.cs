using System;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string? ReceiptUrl { get; set; }
        public string? ReceiptFileName { get; set; }
    }
} 