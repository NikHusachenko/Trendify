using Microsoft.AspNetCore.Mvc;

namespace Trendify.CuttingWorkshop.Web.Controllers;

public class AuthenticationController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }
}