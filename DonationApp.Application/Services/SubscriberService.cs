using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Shared.Dtos;

namespace DonationApp.Applications.Services
{
    public class SubscriberService (IUnitOfWork _unitOfWork): ISubscriberService
    {
        public async Task<bool> AddSubscriberAsync(SubscriberDto subscriber)
        {
            var newSubscriber = new Subscriber
            (
                 name: subscriber.Name,
                isActive: subscriber.IsActive,
                phoneNumber: subscriber.PhoneNumber,
                receiptNumber: subscriber.ReceiptNumber,
               subscriptionId: subscriber.Subscription.FirstOrDefault()?.Id ?? Guid.Empty);


            await _unitOfWork.GetRepository<Subscriber, Guid>().AddAsync(newSubscriber);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                throw new Exception("Failed to add subscriber.");
            }
            return true;
        }

        public async Task<List<SubscriberDto>> GetAllSubscribersAsync()
        {
            var subscribers = await _unitOfWork.GetRepository<Subscriber, Guid>().GetAllAsync(null, false);
            if (subscribers is null)
            {
                throw new KeyNotFoundException("No subscribers found.");
            }
            var mappedSubscribers = subscribers.Select(s => new SubscriberDto
            {
                Name = s.Name,
                PhoneNumber = s.PhoneNumber,
                IsActive = s.IsActive,
                ReceiptNumber = s.ReceiptNumber,
                Subscription = s.Subscription != null ? new List<ReturnSubscriptionDto> { new ReturnSubscriptionDto { Id = s.Subscription.Id, SubscriptionType = s.Subscription.SubscriptionType.ToString() } } : new List<ReturnSubscriptionDto>()
            }).ToList();
            return mappedSubscribers;
        }

        public async Task<SubscriberDto?> GetSubscriberByIdAsync(Guid id)
        {
            var subscriber = await _unitOfWork.GetRepository<Subscriber, Guid>().GetByIdAsync(id);
            if (subscriber is null)
            {
                throw new KeyNotFoundException("Subscriber not found.");
            }
            var mappedSubscriber = new SubscriberDto
            {
                Name = subscriber.Name,
                PhoneNumber = subscriber.PhoneNumber,
                IsActive = subscriber.IsActive,
                ReceiptNumber = subscriber.ReceiptNumber,
                Subscription = subscriber.Subscription != null ? new List<ReturnSubscriptionDto> { new ReturnSubscriptionDto { Id = subscriber.Subscription.Id, SubscriptionType = subscriber.Subscription.SubscriptionType.ToString() } } : new List<ReturnSubscriptionDto>()
            };
            return mappedSubscriber;
        }

        public async Task<bool> RemoveSubscriberAsync(Guid id)
        {
            var subscriber = await _unitOfWork.GetRepository<Subscriber, Guid>().GetByIdAsync(id);
            if (subscriber is null)
            {
                throw new KeyNotFoundException("Subscriber not found.");
            }
            _unitOfWork.GetRepository<Subscriber, Guid>().Delete(subscriber);
            var result = _unitOfWork.SaveChangesAsync();
            if (result.Result <= 0)
            {
                throw new Exception("Failed to remove subscriber.");
            }
            return true;
        }

        public async Task<bool> UpdateSubscriberAsync(SubscriberDto subscriber)
        {
            var existingSubscriber = await _unitOfWork.GetRepository<Subscriber, Guid>().GetByIdAsync(subscriber.Id);
            if (existingSubscriber is null)
            {
                throw new KeyNotFoundException("Subscriber not found.");
            }
            existingSubscriber.Name = subscriber.Name;
            existingSubscriber.PhoneNumber = subscriber.PhoneNumber;
            existingSubscriber.IsActive = subscriber.IsActive;
            existingSubscriber.ReceiptNumber = subscriber.ReceiptNumber;
            existingSubscriber.SubscriptionId = subscriber.Subscription.FirstOrDefault()?.Id ?? Guid.Empty;
            _unitOfWork.GetRepository<Subscriber, Guid>().Update(existingSubscriber);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                throw new Exception("Failed to update subscriber.");
            }
            return true;
        }
    }
}
