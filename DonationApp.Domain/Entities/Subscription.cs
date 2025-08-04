using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public string SubscriptionType { get; set; }
        public bool IsActive { get; set; } 
        public List<Donor> Donor { get; set; }
        public string ReceiptNumber { get; set; }
    }
}
