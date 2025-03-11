using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
