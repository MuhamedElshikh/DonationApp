using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Shared.Dtos
    {
    public class ReturnSubscriptionDto
        {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal Amount { get; set; }
        public string SubscriptionType { get; set; }

        public string ReceiptNumber { get; set; }
        }
    }
