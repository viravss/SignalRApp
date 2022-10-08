namespace Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServiceRegistration
{
         public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
}