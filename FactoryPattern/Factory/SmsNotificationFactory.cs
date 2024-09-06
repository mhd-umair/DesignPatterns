using FactoryPattern.Services;

namespace FactoryPattern.Factory
{
    public class SmsNotificationFactory : INotificationFactory
    {
        public INotificationService CreateNotification()
        {
            return new SmsNotificationService();
        }
    }

}
