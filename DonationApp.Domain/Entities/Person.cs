using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Domain.Entities
{
    public class Person : BaseEntity<Guid>
    {
        public Person(string name, int? phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
