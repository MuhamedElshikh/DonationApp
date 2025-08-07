using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Shared.Dtos
    {
    public class InputDonationDto
        {
        public Guid Id { get; set; }
        public Guid DonorId { get; set; }
        public string donorName { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }

        public string ReceiptNumber { get; set; }


        }
    }
