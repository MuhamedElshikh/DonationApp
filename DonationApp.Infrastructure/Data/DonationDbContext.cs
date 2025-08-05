using DonationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Infrastructure.Data
    {
    public class DonationDbContext : DbContext
        {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationDbContext).Assembly);
            }
        public DbSet<Donor> donors { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Expense> expenses { get; set; }
        }
    }
