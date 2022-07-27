using Microsoft.AspNetCore.Mvc;

namespace MyApp.Modules.Notifications.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : Controller
{
    public string Get() => "Notifications API";
}