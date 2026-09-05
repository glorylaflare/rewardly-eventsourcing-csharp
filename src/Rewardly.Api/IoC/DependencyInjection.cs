using Rewardly.Api.Handlers;
using Rewardly.Api.Mapper;

namespace Rewardly.Api.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddSingleton<IExceptionMapper, ExceptionMapper>();

        return services;
    }
}
