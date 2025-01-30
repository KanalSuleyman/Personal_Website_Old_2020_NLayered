using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
