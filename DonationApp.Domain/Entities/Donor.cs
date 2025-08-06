using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
    {
    public class Donor
        {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int phoneNumber { get; set; }
        public List<Donation> Donations { get; set; }
        }
    }
