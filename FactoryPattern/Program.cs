using FactoryPattern.Factory;
using FactoryPattern.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                 .AddTransient<EmailNotificationFactory>()
                 .AddTransient<SmsNotificationFactory>()
                 .AddTransient<NotificationService>() // Register the service that uses the factories
                 .BuildServiceProvider();

            // Resolve NotificationService and use it
            var notificationService = serviceProvider.GetRequiredService<NotificationService>();

            notificationService.SendNotification("Email", "Welcome to our service!");
            notificationService.SendNotification("SMS", "Your verification code is 123456.");
        }
    }
}
