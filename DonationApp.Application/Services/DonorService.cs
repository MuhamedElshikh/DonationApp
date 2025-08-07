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
        public async Task<bool> AddAsync(DonorDto donorDto)
            {
            var donor = new DonorDto
                {
                Name = donorDto.Name,
                PhoneNumber = donorDto.PhoneNumber
                };

            if ( string.IsNullOrEmpty(donor.Name) || donor.PhoneNumber <= 0 )
                {
                throw new ArgumentException("Donor name and phone number must be provided.");
                }

            var MappedDonor = new Donor
            (
                donations: new List<Donation>(),
                name: donor.Name
            );

            await unitOfWork.GetRepository<Donor, Guid>()
               .AddAsync(MappedDonor);

            var result = await unitOfWork.SaveChangesAsync();
            return result > 0;
            }

        public async Task<bool> DeleteAsync(Guid id)
            {

            var donorEntity = await unitOfWork.GetRepository<Donor, Guid>().GetByIdAsync(id);
            if ( donorEntity == null )
                {
                throw new KeyNotFoundException($"Donor with id {id} not found.");
                }
            unitOfWork.GetRepository<Donor, Guid>().Delete(donorEntity);
            var result = await unitOfWork.SaveChangesAsync();
            return result > 0;
            }

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
            return result > 0;
            }

        }
    }
