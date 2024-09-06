using FactoryPattern.Services;

namespace FactoryPattern.Factory
{
    public class EmailNotificationFactory : INotificationFactory
    {
        public INotificationService CreateNotification()
        {
            return new EmailNotificationService();
        }
    }

}
