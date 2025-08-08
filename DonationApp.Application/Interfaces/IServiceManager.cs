using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Interfaces
    {
    public interface IServiceManager
        {
        public IDonorService DonorService { get; }
        public IDonationService DonationServise { get; }
        public IExpenseService ExpenseServise { get; }
        public ISubscriberService SubscriberServise { get; }
        public ISubscriptionService SubscriptionServise { get; }

        }
    }
