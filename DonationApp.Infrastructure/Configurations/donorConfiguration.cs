using DonationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Infrastructure.Configurations
    {
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
        {
        public void Configure(EntityTypeBuilder<Donor> builder)
            {
            builder.HasMany<Donation>(D => D.Donations).WithOne(D => D.Donor)
                 .HasForeignKey(D => D.DonorId)
                 .OnDelete(DeleteBehavior.NoAction);


            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.PhoneNumber).IsRequired();
            }
        }
    }
