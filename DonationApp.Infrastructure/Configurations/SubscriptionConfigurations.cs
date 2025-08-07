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
    public class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
        {
        public void Configure(EntityTypeBuilder<Subscription> builder)
            {
            builder.Property(S => S.Amount)
                .HasColumnType("MONEY")
                .IsRequired();

            builder.Property(S => S.StartDate)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(S => S.EndDate)
                .HasColumnType("DATE")
                .IsRequired()
                .HasComputedColumnSql("DATEADD(YEAR, 1, StartDate)", stored: true); ;

           

            }
        }
    }
