using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Shared.Dtos
    {
    public class SubscriberDto
        {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public List<ReturnDonationDto>? Donations { get; set; }
        public string ReceiptNumber { get; set; }

        public List<ReturnSubscriptionDto> Subscription { get; set; }
        }
    }
