using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Commands.v1.CancelAccount;
using Rewardly.Application.Commands.v1.CreateAccount;
using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Commands.v1.RedeemReward;
using Rewardly.Application.Interfaces.Bus.Command;
using Rewardly.Application.Interfaces.Bus.Query;
using Rewardly.Application.Projections.Dispatcher;
using Rewardly.Application.Projections.Handlers;

namespace Rewardly.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotification, NotificationContext>();

        AddMediatr(services);
        AddPipelineBehavior(services);
        AddProjections(services);
        AddRequestHandlers(services);
        AddServices(services);

        return services;
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IRewardlyAccountService, RewardlyAccountService>();
    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();
        services.AddScoped<IRequestInvokerFactory, RequestInvokerFactory>();
        services.AddScoped(typeof(RequestInvoker<,>));
    }

    private static void AddRequestHandlers(IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<BlockAccountCommand, bool>, BlockAccountHandler>();
        services.AddScoped<IRequestHandler<CancelAccountCommand, bool>, CancelAccountHandler>();
        services.AddScoped<IRequestHandler<CreateAccountCommand, bool>, CreateAccountHandler>();
        services.AddScoped<IRequestHandler<CreditPointsCommand, bool>, CreditPointsHandler>();
        services.AddScoped<IRequestHandler<DebitPointsCommand, bool>, DebitPointsHandler>();
        services.AddScoped<IRequestHandler<RedeemRewardCommand, bool>, RedeemRewardHandler>();
    }

    private static void AddPipelineBehavior(IServiceCollection services)
    {
        services.AddScoped<IPipelineExecutor, PipelineExecutor>();
        services.AddScoped<IPipelineBehaviorFactory, PipelineBehaviorFactory>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void AddProjections(IServiceCollection services)
    {
        services.AddScoped<IProjectionDispatcher, ProjectionDispatcher>();
        services.AddScoped<IProjectionInvokerFactory, ProjectionInvokerFactory>();
        services.AddScoped(typeof(ProjectionInvoker<>));

        services.AddScoped<IProjectionHandler<AccountCreated>, AccountCreatedHandler>();
        services.AddScoped<IProjectionHandler<AccountBlocked>, AccountBlockedHandler>();
        services.AddScoped<IProjectionHandler<AccountCancelled>, AccountCancelledHandler>();
        services.AddScoped<IProjectionHandler<PointsCredited>, PointsCreditedHandler>();
        services.AddScoped<IProjectionHandler<PointsDebited>, PointsDebitedHandler>();
        services.AddScoped<IProjectionHandler<PointsExpired>, PointsExpiredHandler>();
        services.AddScoped<IProjectionHandler<RewardRedeemed>, RewardRedeemedHandler>();
    }
}
