using Microsoft.AspNetCore.Mvc;

namespace Trendify.CuttingWorkshop.Web.Controllers
{
    public class ToolsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Tools()
        {
            return View();
        }
    }
}
