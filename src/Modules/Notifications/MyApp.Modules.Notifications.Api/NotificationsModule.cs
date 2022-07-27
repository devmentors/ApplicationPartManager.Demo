using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Modules.Notifications.Api.API;
using MyApp.Shared.Modules;

namespace MyApp.Modules.Notifications.Api;

public class NotificationsModule : IModule
{
    public string Name => "Notifications";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
        endpoints.UseNotificationsApi();
    }
}