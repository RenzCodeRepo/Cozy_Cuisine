using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
