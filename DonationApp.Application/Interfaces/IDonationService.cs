using DonationApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Interfaces
    {
    public interface IDonationService
        {
        Task<bool> CreateDonationAsync(InputDonationDto donation);
        Task<ReturnDonationDto> GetDonationByIdAsync(Guid id);
        Task<IEnumerable<ReturnDonationDto>> GetAllDonationsAsync();
        Task<bool> UpdateDonationAsync(InputDonationDto donation);
        Task<bool> DeleteDonationAsync(Guid id);
        }
    }
