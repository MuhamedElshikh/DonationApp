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
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
        {
        public void Configure(EntityTypeBuilder<Donation> builder)
            {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Date)
                .IsRequired()
                .HasColumnType("DATE");
            builder.Property(d => d.Amount)
                .HasColumnType("MONEY")
                .IsRequired();


            builder.HasOne(d => d.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.ReceiptNumber)
                .IsRequired();
            }
        }
    }
