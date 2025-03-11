using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
