
var provider = new UserNotificationProvider();
var service = new ShippingService(provider);
service.ShipItem();
Console.ReadLine();


public interface IUserNotification
{
    void NotifyUser(int userId);
}

public class TestUserNotification : IUserNotification
{
  public void NotifyUser(int userId)
  {
      Console.WriteLine("Test user notification sent.");
  }
}

public class EmailUserNotification : IUserNotification
{
  public void NotifyUser(int userId)
  {
      Console.WriteLine("Email user notification sent.");
  }
}

public class UserNotificationProvider
{
    public IUserNotification GetUserNotifier(NotificationProvider provider)
    {
        switch(provider)
        {
            case NotificationProvider.Email:
                return new EmailUserNotification();
            
            case NotificationProvider.Test:
            default:
                return new TestUserNotification();
        }
    }
}

public enum NotificationProvider
{
    Test,
    Email
}

public class ShippingService
{
    private readonly UserNotificationProvider _notificationProvider;

    public ShippingService(UserNotificationProvider notificationProvider)
    {
        _notificationProvider = notificationProvider;
    }

    public void ShipItem()
    {
        //Shipping Logic
        _notificationProvider.GetUserNotifier(NotificationProvider.Email).NotifyUser(1000);
    }
}