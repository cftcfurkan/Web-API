using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
