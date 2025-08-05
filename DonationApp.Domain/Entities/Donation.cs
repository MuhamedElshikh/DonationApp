using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
    {
    public class Donation
        {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Guid DonorId { get; set; }
        public Donor Donor { get; set; }

        public string ReceiptNumber { get; set; }

        }
    }
