using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
