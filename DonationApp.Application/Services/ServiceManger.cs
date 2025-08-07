using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Applications.Interfaces;

namespace DonationApp.Applications.Services
{
    public class ServiceManger (IUnitOfWork _UnitOfWork) : IServiceManger
    {
        public IDonorService DonarService => throw new NotImplementedException();

        public IDonationServise DonationServise => throw new NotImplementedException();

        public IExpenseService ExpenseServise => throw new NotImplementedException();

        public ISubscriberService SubscriberServise => throw new NotImplementedException();

        public ISubscriptionService SubscriptionServise => throw new NotImplementedException();
    }
}
