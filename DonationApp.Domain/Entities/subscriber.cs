using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
{
    public class Subscriber : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public Guid? donationId { get; set; }
        public List<Donation>? Donations { get; set; }
        public string ReceiptNumber { get; set; }
        // Navigation property to link to the Subscription entity
        public Guid SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}
