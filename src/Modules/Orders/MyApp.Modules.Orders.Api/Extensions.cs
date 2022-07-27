using Microsoft.Extensions.DependencyInjection;
using MyApp.Modules.Orders.Core.Services;

namespace MyApp.Modules.Orders.Api;

public static class Extensions
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services)
    {
        services.AddSingleton<IGreetingService, GreetingService>();
        return services;
    }
}