using Microsoft.Extensions.DependencyInjection;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Domain.Notifications.v1;

namespace Rewardly.Application.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotification, NotificationContext>();

        return services;
    }
}
