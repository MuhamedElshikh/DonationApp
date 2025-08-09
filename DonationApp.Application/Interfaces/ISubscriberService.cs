using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;

namespace DonationApp.Applications.Interfaces
{
    public interface ISubscriberService
    {
        Task<bool> AddSubscriberAsync(SubscriberDto subscriber);
        Task<bool> RemoveSubscriberAsync(Guid id);
        Task<List<SubscriberDto>> GetAllSubscribersAsync();

        Task<SubscriberDto?> GetSubscriberByIdAsync(Guid id);
        Task<bool> UpdateSubscriberAsync( SubscriberDto subscriber);


    }
}
