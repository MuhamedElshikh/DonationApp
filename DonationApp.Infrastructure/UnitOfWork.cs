using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using DonationApp.Infrastructure.Data;
using DonationApp.Infrastructure.Repositories;

namespace DonationApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly DonationDbContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork (DonationDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();

        }

             public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
            => (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_context));

           
        

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();

        }
    }
}
