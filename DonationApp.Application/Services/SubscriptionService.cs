using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Services
    {
    public class SubscriptionService(IUnitOfWork unitOfWork) : ISubscriptionService
        {
        #region Get Subscription Names

        public async Task<List<string>> GetAllSubscriptionsAsync()
            {
            var subscriptions = await unitOfWork.GetRepository<Subscription, Guid>().GetAllAsync(null, false);

            if ( subscriptions is null )
                {
                throw new KeyNotFoundException("No subscriptions found.");
                }
            var subscriptionNames = subscriptions.Select(s => s.SubscriptionType.ToString()).ToList()
                ?? throw new KeyNotFoundException("No subscriptions found.");

            return subscriptionNames;
            }

        #endregion

        }
    }
