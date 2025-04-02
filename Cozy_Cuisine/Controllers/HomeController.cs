    using System.Diagnostics;
using System.Threading.Tasks;
using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace Cozy_Cuisine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManageRepository _manageRepository;
        private readonly IPatchRepository _patchRepository;
        public HomeController(ILogger<HomeController> logger, IManageRepository manageRepository, IPatchRepository patchRepository)
        {
            _logger = logger;
            _manageRepository = manageRepository;
            _patchRepository = patchRepository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UnderConstruction()
        {
            return View();
        }
        public async Task<IActionResult> Contacts()
        {
            var CVM = new ContactsVM
            {
                FAQs = await _manageRepository.GetAllFAQsAsync(),
                PatchesDict = await _patchRepository.GetPatchDictionaryAsync()
            };

            return View(CVM);
        }

    }
}
