# Notification System with Factory Method and Dependency Injection

This repository demonstrates the use of the Factory Method pattern combined with Dependency Injection (DI) in a real-world scenario. The example features a notification system capable of sending different types of notifications, such as Email and SMS.

## Overview

The Notification System uses the Factory Method pattern to handle the creation of different types of notifications and leverages Dependency Injection for flexible and maintainable code. The `NotificationService` class utilizes DI to obtain the appropriate notification factory and send messages accordingly.

## Project Structure

- **`INotification.cs`**: Defines the `INotification` interface for sending notifications.
- **`EmailNotification.cs`**: Implements the `INotification` interface to send email notifications.
- **`SmsNotification.cs`**: Implements the `INotification` interface to send SMS notifications.
- **`INotificationFactory.cs`**: Defines the factory interface for creating `INotification` instances.
- **`EmailNotificationFactory.cs`**: Creates instances of `EmailNotification`.
- **`SmsNotificationFactory.cs`**: Creates instances of `SmsNotification`.
- **`NotificationService.cs`**: Uses DI to obtain the correct factory and send notifications based on the specified type.
- **`Program.cs`**: Configures DI and demonstrates the usage of `NotificationService`.

## Code Explanation

### **1. Notification Interfaces and Implementations**

**`INotificationService.cs`**

Defines the `INotificationService` interface that all notification types must implement. It includes the `Send()` method, which is used to send a notification.

**`EmailNotificationService.cs`**

Implements `INotificationService` to send email notifications. The `Send()` method outputs the message to the console, simulating sending an email.

**`SmsNotificationService.cs`**

Implements `INotificationService` to send SMS notifications. The `Send()` method outputs the message to the console, simulating sending an SMS.

```csharp
public interface INotificationService
{
    void Send(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}
```
### **2. Factory Interfaces and Implementations**
**`INotificationFactory.cs`**

Defines the **`INotificationFactory`** interface for creating INotification instances. It includes the **`CreateNotification()`** method, which returns an **`INotificationService`** object.

**`EmailNotificationFactory.cs`**

Implements **`INotificationFactory`** to create instances of **`EmailNotificationService`**. The **`CreateNotification()`** method returns a new **`EmailNotificationService`** instance.

**`SmsNotificationFactory.cs`**

Implements **`INotificationFactory`** to create instances of **`SmsNotificationService`**. The **`CreateNotification()`** method returns a new **`SmsNotificationService`** instance.

```csharp
public interface INotificationFactory
{
    INotification CreateNotification();
}

public class EmailNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        return new EmailNotificationService();
    }
}

public class SmsNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        return new SmsNotificationService();
    }
}

```
### **3. Notification Service**
**`NotificationService.cs`**

Uses Dependency Injection to obtain the correct factory based on the notification type and send the notification. The **`SendNotification()`** method takes the notification type and message, selects the appropriate factory, creates the notification, and sends it.

``` csharp

public class NotificationService
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SendNotification(string type, string message)
    {
        INotificationFactory factory = type switch
        {
            "Email" => _serviceProvider.GetRequiredService<EmailNotificationFactory>(),
            "SMS" => _serviceProvider.GetRequiredService<SmsNotificationFactory>(),
            _ => throw new ArgumentException("Invalid notification type", nameof(type)),
        };

        INotification notification = factory.CreateNotification();
        notification.Send(message);
    }
}
```
### **4. Program**
**`Program.cs`**

Configures Dependency Injection using **`Microsoft.Extensions.DependencyInjection`**. Registers the factories and NotificationService with the service provider. Demonstrates how to resolve the NotificationService and use it to send different types of notifications.

``` csharp

using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Configure DI
        var serviceProvider = new ServiceCollection()
            .AddTransient<EmailNotificationFactory>()
            .AddTransient<SmsNotificationFactory>()
            .AddTransient<NotificationService>()
            .BuildServiceProvider();

        // Resolve NotificationService and use it
        var notificationService = serviceProvider.GetRequiredService<NotificationService>();

        notificationService.SendNotification("Email", "Welcome to our service!");
        notificationService.SendNotification("SMS", "Your verification code is 123456.");
    }
}
```
## How to Run
Clone the repository or copy the files into your local development environment.
Open the solution in Visual Studio or your preferred C# IDE.
Build and run the application.
Observe the console output, which demonstrates sending both email and SMS notifications.

## License
This project is licensed under the MIT License.
