using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddServices();
        services.AddRepositories();
        return services;
    }


}