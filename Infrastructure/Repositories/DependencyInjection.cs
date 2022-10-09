using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories;

public static class DependencyInjection
{

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddUserRepository();
        services.AddMessageRepository();
        services.AddCommonRepository();
        return services;
    }

    private static void AddCommonRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommonRepositories<>), typeof(CommonRepository<>));
    }

    public static void AddUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }


    public static void AddMessageRepository(this IServiceCollection services)
    {
        services.AddScoped<IMessageRepository, MessageRepository>();
    }

}
