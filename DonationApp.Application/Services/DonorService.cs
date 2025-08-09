using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Services
    {
    public class DonorService(IUnitOfWork unitOfWork) : IDonorService
        {

        #region Add

        public async Task<bool> AddAsync(DonorDto donorDto)
            {
            //var donor = new DonorDto
            //    {
            //    Name = donorDto.Name,
            //    PhoneNumber = donorDto.PhoneNumber
            //    };

            if ( string.IsNullOrEmpty(donorDto.Name) || donorDto.PhoneNumber <= 0 )
                {
                throw new ArgumentException("Donor name and phone number must be provided.");
                }

            var MappedDonor = new Donor
            (
                name: donorDto.Name,
                donations: new List<Donation>(),
                phoneNumber: donorDto.PhoneNumber
            );

            await unitOfWork.GetRepository<Donor, Guid>()
               .AddAsync(MappedDonor);

            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 )
                {
                throw new Exception("Failed to add donor.");
                }
            return true;
            }


        #endregion

        #region Get All

        public async Task<IEnumerable<DonorDto>> GetAllAsync()
            {
            var donors = await unitOfWork.GetRepository<Donor, Guid>().GetAllAsync(null, false);
            if ( donors is null )
                {
                throw new KeyNotFoundException("No donors found.");
                }

            var mappedDonors = donors.Select(d => new DonorDto
                {
                Id = d.Id,
                Name = d.Name,
                PhoneNumber = d.PhoneNumber,
                Donations = d.Donations.Select(donation => new ReturnDonationDto
                    {
                    Id = donation.Id,
                    Amount = donation.Amount,
                    Date = donation.Date,
                    ReceiptNumber = donation.ReceiptNumber,
                    DonorId = d.Id,
                    DonorName = d.Name
                    }).ToList()
                }).ToList();

            return mappedDonors;
            }


        #endregion

        #region Get By ID

        public async Task<DonorDto> GetByIdAsync(Guid id)
            {

            var donorEntity = await unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(id);
            if ( donorEntity is null )
                {
                throw new KeyNotFoundException($"Donor with id {id} not found.");
                }

            var mappedDonor = new DonorDto
                {
                Id = donorEntity.Id,
                Name = donorEntity.Name,
                PhoneNumber = donorEntity.PhoneNumber,
                Donations = donorEntity.Donations.Select(donation => new ReturnDonationDto
                    {
                    Id = donation.Id,
                    Amount = donation.Amount,
                    Date = donation.Date,
                    ReceiptNumber = donation.ReceiptNumber,
                    DonorId = donorEntity.Id,
                    DonorName = donorEntity.Name
                    }).ToList()
                };
            return mappedDonor;

            }


        #endregion

        #region Update

        public async Task<bool> UpdateAsync(DonorDto donorDto)
            {

            var donorEntity = await unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(donorDto.Id);
            if ( donorEntity == null )
                {
                throw new KeyNotFoundException($"Donor with id {donorDto.Id} not found.");
                }

            donorEntity.Name = donorDto.Name;
            donorEntity.PhoneNumber = donorDto.PhoneNumber;

            unitOfWork.GetRepository<Donor, Guid>().Update(donorEntity);
            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 )
                {
                throw new Exception("Failed to update donor.");
                }
            else

                return true;
            }

        #endregion

        #region Delete

        public async Task<bool> DeleteAsync(Guid id)
            {

            var donorEntity = await unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(id);
            if ( donorEntity == null )
                {
                throw new KeyNotFoundException($"Donor with id {id} not found.");
                }
            unitOfWork.GetRepository<Donor, Guid>().Delete(donorEntity);
            var result = await unitOfWork.SaveChangesAsync();
            if ( result <= 0 )
                {
                throw new Exception("Failed to delete donor.");
                }
            return true;
            }

        #endregion

        }
    }
