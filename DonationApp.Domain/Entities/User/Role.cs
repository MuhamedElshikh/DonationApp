using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace DonationApp.Domain.Entities.IdintityUser
{
    public class Role :IdentityRole<Guid>
    {

        public RoleType Name { get; set; }

    }
}
