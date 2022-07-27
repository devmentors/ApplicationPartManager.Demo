using Microsoft.AspNetCore.Mvc;
using MyApp.Modules.Orders.Core.Services;

namespace MyApp.Modules.Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly IGreetingService _greetingService;

    public OrdersController(IGreetingService greetingService)
        => _greetingService = greetingService;

    public string Get() => _greetingService.Greet();
}