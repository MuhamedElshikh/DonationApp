using DonationApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Interfaces
    {
    public interface IDonorService
        {
        Task<IEnumerable<DonorDto>> GetAllAsync();
        Task<DonorDto> GetByIdAsync(Guid id);
        Task<bool> AddAsync(DonorDto donorDto);
        Task<bool> UpdateAsync(DonorDto donorDto);
        Task<bool> DeleteAsync(Guid id);
        }
    }
