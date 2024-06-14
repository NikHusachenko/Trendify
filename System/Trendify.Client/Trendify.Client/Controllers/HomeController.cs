using Microsoft.AspNetCore.Mvc;

namespace Trendify.Client.Controllers;

public class HomeController : Controller
{
    [HttpGet] public async Task<IActionResult> Index() => View();
}