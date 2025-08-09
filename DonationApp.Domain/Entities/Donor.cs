using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DonationApp.Domain.Entities
{
    public class Donor : Person
    {
        public Donor(string name, int? phoneNumber, ICollection<Donation> donations) : base(name, phoneNumber)
        {
            Donations = donations;
        }

        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}
