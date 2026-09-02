namespace Rewardly.Application.Interfaces.Projections;

public interface IProjectionHandler<in TEvent> 
    where TEvent : IEvent
{
    Task HandlerAsync(TEvent @event, CancellationToken cancellationToken);
}
