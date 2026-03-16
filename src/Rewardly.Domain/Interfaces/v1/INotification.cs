using Rewardly.Domain.Notifications.v1;

namespace Rewardly.Domain.Interfaces.v1;

public interface INotification
{
    IReadOnlyCollection<Notification> Notifications { get; }
    bool HasNotifications { get; }

    void AddNotification(string code, string message);
    void AddNotification(Notification notification);
    void AddNotification(IEnumerable<Notification> notifications);
}
