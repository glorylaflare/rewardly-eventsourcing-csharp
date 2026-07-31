namespace Rewardly.Application.IoC;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotification, NotificationContext>();
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddPipeline();
        services.AddScoped<IRewardlyAccountService, RewardlyAccountService>();
        services.AddScoped<IPipelineExecutor, PipelineExecutor>();
        services.AddScoped<ICommandInvokerFactory, CommandInvokerFactory>();
        services.AddScoped<IPipelineBehaviorFactory, PipelineBehaviorFactory>();

        services.AddScoped(typeof(ICommandInvoker), typeof(CommandInvoker<,>));

        return services;
    }

    public static IServiceCollection AddPipeline(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
