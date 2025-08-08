using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Services
    {
    public class DonationService(IUnitOfWork _unitOfWork) : IDonationService
        {

        #region Add

        public async Task<bool> CreateDonationAsync(InputDonationDto donationEntity)
            {

            //var donationEntity = new InputDonationDto
            //    {
            //    DonorId = donation.DonorId,
            //    Amount = donation.Amount,
            //    Date = donation.Date,
            //    ReceiptNumber = donation.ReceiptNumber
            //    };

            if ( string.IsNullOrEmpty(donationEntity.ReceiptNumber) )
                {
                throw new ArgumentException("Receipt number must be provided.");
                }
            if ( donationEntity.Amount <= 0 )
                {
                throw new ArgumentException("Donation amount must be greater than zero.");
                }
            if ( donationEntity.DonorId == Guid.Empty )
                {
                throw new ArgumentException("Donor ID must be provided.");
                }
            if ( donationEntity.Date == default(DateOnly) )
                {
                donationEntity.Date = DateOnly.FromDateTime(DateTime.Today);
                }

            var mappedDonation = new Donation(donationEntity.Amount, donationEntity.ReceiptNumber)
                {
                DonorId = donationEntity.DonorId,
                Date = donationEntity.Date,
                Amount = donationEntity.Amount,
                ReceiptNumber = donationEntity.ReceiptNumber,
                Donor = await _unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(donationEntity.DonorId)
                ?? throw new KeyNotFoundException($"Donor with id {donationEntity.DonorId} not found."),

                };

            await _unitOfWork.GetRepository<Donation, Guid>().AddAsync(mappedDonation);


            //await _unitOfWork.GetRepository<InputDonationDto, Guid>()
            //       .AddAsync(new InputDonationDto
            //           {
            //           DonorId = donation.DonorId,
            //           Amount = donation.Amount,
            //           Date = donation.Date,
            //           });

            var result = await _unitOfWork.SaveChangesAsync();

            if ( result > 0 )
                {
                return true;
                }

            return false;
            }


        #endregion

        #region Get All
        public async Task<IEnumerable<ReturnDonationDto>> GetAllDonationsAsync()
            {
            var donor = await _unitOfWork.GetRepository<Donor, Guid>().GetAllAsync(null, false);

            var donation = await _unitOfWork.GetRepository<Donation, Guid>().GetAllAsync(null, false);
            var result = from d in donation
                         join dn in donor on d.DonorId equals dn.Id
                         select new ReturnDonationDto
                             {
                             DonorName = dn.Name,
                             Date = d.Date,
                             Amount = d.Amount,
                             ReceiptNumber = d.ReceiptNumber
                             };
            return result.ToList();

            }


        #endregion

        #region Get By Id

        public async Task<ReturnDonationDto> GetDonationByIdAsync(Guid id)
            {

            var donation = await _unitOfWork.GetRepository<Donation, Guid>().GetByIdAsync(id).ContinueWith(t => t.Result ?? throw new KeyNotFoundException($"Donation with id {id} not found."));

            var donorID = donation.DonorId;
            return new ReturnDonationDto
                {
                Amount = donation.Amount,
                Date = donation.Date,
                DonorName = (await _unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(donorID)).Name,
                ReceiptNumber = donation.ReceiptNumber
                };


            }


        #endregion

        #region Update

        public async Task<bool> UpdateDonationAsync(InputDonationDto donation)
            {
            var existingDonation = await _unitOfWork.GetRepository<Donation, Guid>().GetByIdAsync(donation.Id);
            if ( existingDonation == null )
                {
                throw new KeyNotFoundException($"Donation with id {donation.Id} not found.");
                }

            existingDonation.Amount = donation.Amount;
            existingDonation.ReceiptNumber = donation.ReceiptNumber;
            existingDonation.Date = donation.Date;
            existingDonation.DonorId = donation.DonorId;

            _unitOfWork.GetRepository<Donation, Guid>().Update(existingDonation);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
            }



        #endregion

        #region Delete

        public async Task<bool> DeleteDonationAsync(Guid id)
            {

            var donation = await _unitOfWork.GetRepository<Donation, Guid>().GetByIdAsync(id);
            if ( donation == null )
                {
                return false;
                }
            _unitOfWork.GetRepository<Donation, Guid>().Delete(donation);
            return await _unitOfWork.SaveChangesAsync().ContinueWith(t => t.Result > 0);
            }


        #endregion

        }
    }
