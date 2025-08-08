using DonationApp.Applications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Applications.Services
    {
    public class ServiceManager(IUnitOfWork _UnitOfWork) : IServiceManager
        {
        public IDonorService DonorService { get; } = new DonorService(_UnitOfWork);

        public IDonationService DonationServise { get; } = new DonationService(_UnitOfWork);

        public IExpenseService ExpenseServise { get; } = new ExpenseService(_UnitOfWork);

        public ISubscriberService SubscriberServise => throw new NotImplementedException();

        public ISubscriptionService SubscriptionServise { get; } = new SubscriptionService(_UnitOfWork);
        }
    }
