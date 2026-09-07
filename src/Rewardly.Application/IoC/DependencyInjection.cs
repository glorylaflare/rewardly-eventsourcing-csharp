using FluentValidation;
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
using Rewardly.Application.Queries.v1.GetAccount;
using Rewardly.Application.Queries.v1.GetBalance;
using Rewardly.Application.Queries.v1.GetTransactions;

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
        services.AddScoped<IRequestHandler<BlockAccountCommand, bool>, BlockAccountCommandHandler>();
        services.AddScoped<IRequestHandler<CancelAccountCommand, bool>, CancelAccountCommandHandler>();
        services.AddScoped<IRequestHandler<CreateAccountCommand, bool>, CreateAccountCommandHandler>();
        services.AddScoped<IRequestHandler<CreditPointsCommand, bool>, CreditPointsCommandHandler>();
        services.AddScoped<IRequestHandler<DebitPointsCommand, bool>, DebitPointsCommandHandler>();
        services.AddScoped<IRequestHandler<RedeemRewardCommand, bool>, RedeemRewardCommandHandler>();

        services.AddScoped<IRequestHandler<GetAccountQuery, GetAccountResponse>, GetAccountQueryHandler>();
        services.AddScoped<IRequestHandler<GetBalanceQuery, GetBalanceResponse>, GetBalanceQueryHandler>();
        services.AddScoped<IRequestHandler<GetTransactionsQuery, GetTransactionsResponse>, GetTransactionsQueryHandler>();
    }

    private static void AddPipelineBehavior(IServiceCollection services)
    {
        services.AddScoped<IPipelineExecutor, PipelineExecutor>();
        services.AddScoped<IPipelineBehaviorFactory, PipelineBehaviorFactory>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped(typeof(IValidator<>), typeof(GetTransactionsQueryValidator));
    }

    private static void AddProjections(IServiceCollection services)
    {
        services.AddScoped<IProjectionDispatcher, ProjectionDispatcher>();
        services.AddScoped<IProjectionInvokerFactory, ProjectionInvokerFactory>();
        services.AddScoped(typeof(ProjectionInvoker<>));

        services.AddScoped<IProjectionHandler<AccountCreated>, AccountCreatedProjectionHandler>();
        services.AddScoped<IProjectionHandler<AccountBlocked>, AccountBlockedProjectionHandler>();
        services.AddScoped<IProjectionHandler<AccountCancelled>, AccountCancelledProjectionHandler>();
        services.AddScoped<IProjectionHandler<PointsCredited>, PointsCreditedProjectionHandler>();
        services.AddScoped<IProjectionHandler<PointsDebited>, PointsDebitedProjectionHandler>();
        services.AddScoped<IProjectionHandler<PointsExpired>, PointsExpiredProjectionHandler>();
        services.AddScoped<IProjectionHandler<RewardRedeemed>, RewardRedeemedProjectionHandler>();
    }
}
