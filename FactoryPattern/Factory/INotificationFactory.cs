using FactoryPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factory
{

    public interface INotificationFactory
    {
        INotificationService CreateNotification();
    }

}
