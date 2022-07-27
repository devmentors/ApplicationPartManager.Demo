using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Modules.Orders.Core.Services;
using MyApp.Shared.Modules;

namespace MyApp.Modules.Orders.Api;

public class OrdersModule : IModule
{
    public string Name => "Orders";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IGreetingService, GreetingService>();
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}