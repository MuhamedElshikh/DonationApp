using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
    {
    public class Donor : BaseEntity<Guid>
        {
        public Donor(ICollection<Donation> donations, string name)
            {
            Id = Guid.NewGuid();
            Donations = donations;
            Name = name;
            }
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        }
    }
