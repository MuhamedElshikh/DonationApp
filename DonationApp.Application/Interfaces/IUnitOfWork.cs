using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Domain.Entities;

namespace DonationApp.Applications.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<TEntity , TKey> GetRepository<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
        public Task<int> SaveChangesAsync();
    }
}
