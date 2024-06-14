using Microsoft.AspNetCore.Mvc;

namespace Trendify.Client.Controllers;

public class AuthenticationController : Controller
{
    [HttpGet] public async Task<IActionResult> SignIn() => View();
}