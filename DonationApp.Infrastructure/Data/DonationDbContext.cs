using DonationApp.Domain.Entities;
using DonationApp.Domain.Entities.IdintityUser;
using DonationApp.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Infrastructure.Data
    {
    public class DonationDbContext : IdentityDbContext<User , Role ,Guid>
        {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
            {
            
            }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User> ()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired(false)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.NormalizedEmail)
                .IsRequired(false)
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>().HasIndex(u => u.UserName)
               .IsUnique();

            modelBuilder.Entity<User>().HasIndex(u => u.NormalizedUserName)
                .IsUnique();
            
            

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationDbContext).Assembly);
            }
        public DbSet<Donor> donors { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Expense> expenses { get; set; }
        }
    }
