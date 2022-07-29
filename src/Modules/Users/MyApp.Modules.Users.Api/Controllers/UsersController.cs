using Microsoft.AspNetCore.Mvc;

namespace MyApp.Modules.Users.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{

    public string Get() => "Users API";
}