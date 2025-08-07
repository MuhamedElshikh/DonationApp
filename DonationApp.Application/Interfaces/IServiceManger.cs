using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Interfaces
{
    public interface IServiceManger 
    {
        public IDonorService DonarService { get; }
        public IDonationServise DonationServise { get; }
        public IExpenseService ExpenseServise { get; }
        public ISubscriberService SubscriberServise { get; }
        public ISubscriptionService SubscriptionServise { get; }


        

    }
}
