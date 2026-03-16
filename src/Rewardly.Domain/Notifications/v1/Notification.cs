namespace Rewardly.Domain.Notifications.v1;

public class Notification
{
    public string Code { get; private set; }
    public string Message { get; private set; }

    public Notification(string code, string message)
    {
        Code = code;
        Message = message;
    }
}