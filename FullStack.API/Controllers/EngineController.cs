using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    public class EngineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
