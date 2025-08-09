using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
{
    public class Subscriber : Person
    {
        public Subscriber(string name, int? phoneNumber, Guid subscriptionId ,bool isActive ,string receiptNumber) : base(name, phoneNumber)
        {
           
            
            SubscriptionId = subscriptionId;
            IsActive = isActive;
            Donations = new List<Donation>();
            ReceiptNumber = receiptNumber;
        }
       
        public bool IsActive { get; set; }
        public Guid? donationId { get; set; }
        public List<Donation>? Donations { get; set; }
        public string ReceiptNumber { get; set; }
        // Navigation property to link to the Subscription entity
        public Guid SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}
