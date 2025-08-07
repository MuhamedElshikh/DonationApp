using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonationApp.Infrastructure.Configurations
{
    public class SupscriberConfigurtion : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.PhoneNumber)
                .IsRequired(false);
            builder.Property(s => s.IsActive)
                .IsRequired();
            builder.Property(s => s.ReceiptNumber)
                .IsRequired();

            builder.HasOne(s => s.Subscription)
                .WithMany(sub => sub.subscribers)
                .HasForeignKey(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Donations)
                .WithOne()
                .HasForeignKey(d => d.SubscriberId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(S => S.IsActive)
               .HasColumnType("BIT")
               .IsRequired()
               .HasDefaultValue(true);
            builder.HasIndex(e => e.IsActive);
        }
    }
}
