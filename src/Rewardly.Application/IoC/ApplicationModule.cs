using Rewardly.Application.Interfaces.Bus.Command;
using Rewardly.Application.Projections;

namespace Rewardly.Application.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotification, NotificationContext>();
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddPipeline();
        services.AddProjections();
        services.AddScoped<IRewardlyAccountService, RewardlyAccountService>();
        services.AddScoped<IPipelineExecutor, PipelineExecutor>();
        services.AddScoped<IRequestInvokerFactory, RequestInvokerFactory>();
        services.AddScoped<IPipelineBehaviorFactory, PipelineBehaviorFactory>();

        
        services.AddScoped(typeof(RequestInvoker<,>));

        return services;
    }

    public static IServiceCollection AddPipeline(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

    public static IServiceCollection AddProjections(this IServiceCollection services)
    {
        services.AddScoped<IProjectionHandler<AccountCreated>, AccountCreatedHandler>();
        services.AddScoped<IProjectionHandler<AccountBlocked>, AccountBlockedHandler>();
        services.AddScoped<IProjectionHandler<AccountCancelled>, AccountCancelledHandler>();
        services.AddScoped<IProjectionHandler<PointsCredited>, PointsCreditedHandler>();
        services.AddScoped<IProjectionHandler<PointsDebited>, PointsDebitedHandler>();
        services.AddScoped<IProjectionHandler<PointsExpired>, PointsExpiredHandler>();
        services.AddScoped<IProjectionHandler<RewardRedeemed>,RewardRedeemedHandler>();

        return services;
    }
}
