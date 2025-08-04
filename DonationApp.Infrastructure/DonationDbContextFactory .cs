using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using DonationApp.Infrastructure.Data;

namespace DonationApp.Infrastructure
{
    public class DonationDbContextFactory : IDesignTimeDbContextFactory<DonationDbContext>
    {
        public DonationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory()) // مكان التشغيل
                 .AddJsonFile("appsettings.json") // اقرا ملف الإعدادات
                 .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DonationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DonationDbContext(optionsBuilder.Options);
        }
    }
}
