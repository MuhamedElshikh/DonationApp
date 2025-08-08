using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
    {
    public class Expense : BaseEntity<Guid>
        {
        public Expense(DateOnly date, decimal amount, string expenseType, string description)
            {
            Id = Guid.NewGuid();
            Date = date;
            Amount = amount;
            ExpenseType = expenseType;
            Description = description;
            }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public string ExpenseType { get; set; }
        public string Description { get; set; }


        }
    }
