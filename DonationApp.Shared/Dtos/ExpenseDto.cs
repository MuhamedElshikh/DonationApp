using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Shared.Dtos
{
    public class ExpenseDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ExpenseType { get; set; }
        public string Description { get; set; }
    }
}
