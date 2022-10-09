using Application.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class DependencyInjection
{

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddUserService();
        services.AddMessageService();
        services.AddCommonService();
        return services;
    }

    private static void AddCommonService(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommonServices<>), typeof(CommonService<>));
    }

    public static void AddUserService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }


    public static void AddMessageService(this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();
    }

}
