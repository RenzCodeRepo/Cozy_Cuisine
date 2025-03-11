using Cozy_Cuisine.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class PatchController : Controller
    {
        private readonly IPatchRepository _patchRepository;

        public PatchController(IPatchRepository patchRepository)
        {
            _patchRepository = patchRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
