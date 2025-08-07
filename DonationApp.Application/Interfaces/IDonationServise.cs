using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Shared.Dtos;

namespace DonationApp.Applications.Interfaces
{
    public interface IDonationServise
    {
        Task<bool> CreateDonationAsync(InputDonationDto donation);
        Task<ReturnDonationDto> GetDonationByIdAsync(Guid id);
        Task<IEnumerable<ReturnDonationDto>> GetAllDonationsAsync();
        Task<bool> UpdateDonationAsync(InputDonationDto donation);
        Task<bool> DeleteDonationAsync(Guid id);
    }
}
