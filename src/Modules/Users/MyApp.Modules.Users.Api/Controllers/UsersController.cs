using Microsoft.AspNetCore.Mvc;
using MyApp.Modules.Orders.Core.Services;

namespace MyApp.Modules.Users.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IGreetingService _greetingService;

    public UsersController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public string Get() => "Users module";
}