using FactoryPattern.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryPattern.Services
{
    public class NotificationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void SendNotification(string type, string message)
        {
            INotificationFactory factory = type switch
            {
                "Email" => _serviceProvider.GetRequiredService<EmailNotificationFactory>(),
                "SMS" => _serviceProvider.GetRequiredService<SmsNotificationFactory>(),
                _ => throw new ArgumentException("Invalid notification type", nameof(type)),
            };

            INotificationService notification = factory.CreateNotification();
            notification.Send(message);
        }
    }

}
