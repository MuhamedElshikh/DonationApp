using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;
using Microsoft.VisualBasic;

namespace DonationApp.Applications.Services
{
    public class DonationServise (IUnitOfWork _unitOfWork) : IDonationServise
    {
        public async Task<bool> CreateDonationAsync(InputDonationDto donation)
        {
         await _unitOfWork.GetRepository<Donation, Guid>()
                .AddAsync(new Donation
                {
                    DonorId = donation.DonorId,
                    Amount = donation.Amount,
                    Date = donation.Date,
                });
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
           
                return false;
        }

        public async Task<bool> DeleteDonationAsync(Guid id)
        {

            var donation = await _unitOfWork.GetRepository<Donation, Guid>().GetByIdAsync(id);
            if (donation == null)
            {
                return false;
            }
            _unitOfWork.GetRepository<Donation, Guid>().Delete(donation);
            return await _unitOfWork.SaveChangesAsync().ContinueWith(t => t.Result > 0);
        }

        public async Task<IEnumerable<ReturnDonationDto>> GetAllDonationsAsync()
        {
            var donor = await _unitOfWork.GetRepository<Donor, Guid>().GetAllAsync(null, false);

            var donation = await _unitOfWork.GetRepository<Donation, Guid>().GetAllAsync(null, false);
            var result = from d in donation
                         join dn in donor on d.DonorId equals dn.Id
                         select new ReturnDonationDto
                         {
                             Amount = d.Amount,
                             Date = d.Date,
                              DonorName= dn.Name,
                             ReceiptNumber = d.ReceiptNumber
                         };
            return result.ToList();

        }

        public async Task<ReturnDonationDto> GetDonationByIdAsync(Guid id)
        {

       var donation = await  _unitOfWork.GetRepository<Donation, Guid>().GetByIdAsync(id).ContinueWith(t => t.Result ?? throw new KeyNotFoundException($"Donation with id {id} not found."));

            var donorID = donation.DonorId;
            return new ReturnDonationDto
            {
                Amount = donation.Amount,
                Date = donation.Date,
                DonorName = (await _unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(donorID)).Name,
                ReceiptNumber = donation.ReceiptNumber
            };


        }

        public async Task<bool> UpdateDonationAsync(InputDonationDto donation)
        {

            _unitOfWork.GetRepository<Donation, Guid>().Update(new Donation
            {
                Amount = donation.Amount,
                ReceiptNumber = donation.ReceiptNumber
            });
            var result = await _unitOfWork.SaveChangesAsync();
            return result>0;
        }
    }
}
