using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public bool IsActive { get; set; }
       
        public string ReceiptNumber { get; set; }
        // Navigation property to link to the Subscription entity
        public Subscription Subscription { get; set; }
    }
}
