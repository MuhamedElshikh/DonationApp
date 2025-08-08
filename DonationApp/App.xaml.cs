using DonationApp.Applications.Interfaces;
using DonationApp.Applications.Services;
using DonationApp.Infrastructure;
using DonationApp.Infrastructure.Data;
using DonationApp.UI;
using DonationApp.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace DonationApp
    {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
        {
        private IServiceProvider _serviceProvider;
        private DispatcherTimer _dailyTimer;
        protected override void OnStartup(StartupEventArgs e)
            {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddInfrastructure(configuration);
            services.AddScoped<IServiceManager, ServiceManager>();


            _serviceProvider = services.BuildServiceProvider();


            //  Run once on startup
            RunDailyRefresh();

            // Start the hourly timer to check for daily subscription refresh
            StartDailySubscriptionCheck();

            base.OnStartup(e);


            //var mainWindow = new main();
            //mainWindow.Show();
            }


        #region RunDailyRefresh

        // Refresh subscription statuses Daily on app Launch
        // This is a one-time check to ensure that the subscription statuses are up-to-date
        private void RunDailyRefresh()
            {
            if ( Settings.Default.LastRefreshDate.Date < DateTime.Today )
                {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<DonationDbContext>();

                DbUtils.RefreshSubscriptionStatuses(context);

                Settings.Default.LastRefreshDate = DateTime.Today;
                Settings.Default.Save();
                }
            }

        #endregion

        #region RunDailySubscription Check

        // Hourly check to see if the daily subscription refresh has been run
        // If not, run it
        private void StartDailySubscriptionCheck()
            {
            _dailyTimer = new DispatcherTimer
                {
                Interval = TimeSpan.FromHours(1)
                };

            _dailyTimer.Tick += (s, e) =>
            {
                RunDailyRefresh();
            };

            _dailyTimer.Start();
            }

        #endregion

        }

    }
