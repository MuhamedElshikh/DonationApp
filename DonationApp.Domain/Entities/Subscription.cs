using DonationApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
    {
    public class Subscription : BaseEntity<Guid>
        {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Amount { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public List<Subscriber> subscribers { get; set; }
        public string ReceiptNumber { get; set; }
        }
    }
