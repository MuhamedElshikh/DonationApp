using DonationApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Infrastructure
    {
    public static class DbUtils
        {

        /// Refreshes the subscription statuses in the database.
        /// This method updates the IsActive field based on the EndDate of each subscription.
        public static void RefreshSubscriptionStatuses(DonationDbContext context)
            {
            context.Database.ExecuteSqlRaw(@"
            UPDATE Subscriptions
            SET IsActive = CASE WHEN GETUTCDATE() < EndDate THEN 1 ELSE 0 END");
            }
        }
    }
