using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Domain.Notifications.v1;

public sealed class NotificationContext : INotification
{
    private readonly List<Notification> _notifications = new();

    public IReadOnlyCollection<Notification> Notifications
        => _notifications.AsReadOnly();

    public bool HasNotifications
        => _notifications.Any();

    public void AddNotification(string code, string message)
    {
        _notifications.Add(new Notification(code, message));
    }

    public void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void AddNotification(IEnumerable<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }
}
