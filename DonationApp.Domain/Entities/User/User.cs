using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DonationApp.Domain.Entities.User
{
    public class User : IdentityUser<Guid>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdentificationNumber { get; set; }

        public string? address { get; set; }

    }
}
