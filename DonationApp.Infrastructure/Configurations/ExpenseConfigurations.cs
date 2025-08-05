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
    public class ExpenseConfigurations : IEntityTypeConfiguration<Expense>
        {
        public void Configure(EntityTypeBuilder<Expense> builder)
            {
            builder.Property(e => e.Date)
                            .IsRequired()
                            .HasColumnType("DATE");

            builder.Property(e => e.Amount)
                            .HasColumnType("MONEY")
                            .IsRequired();
            }
        }
    }
