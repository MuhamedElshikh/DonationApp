using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Shared.Dtos
{
    public class DonorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int phoneNumber { get; set; }
        public List<ReturnDonationDto> Donations { get; set; }

    }
}
