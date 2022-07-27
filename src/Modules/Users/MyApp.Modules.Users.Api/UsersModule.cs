using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Modules.Orders.Core.Services;
using MyApp.Shared.Modules;

namespace MyApp.Modules.Users.Api;

public class UsersModule : IModule
{
    public string Name => "Users";
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void Expose(IEndpointRouteBuilder endpoints)
    {
    }
}