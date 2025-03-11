using Cozy_Cuisine.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Cozy_Cuisine.Controllers
{
    public class WikiController : Controller
    {
        private readonly IWikiRepository _wikiRepository;

        public WikiController(IWikiRepository wikiRepository)
        {
            _wikiRepository = wikiRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
