using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cozy_Cuisine.Controllers
{
    public class ManageController : Controller
    {
        private readonly IManageRepository _manageRepository;

        public ManageController(IManageRepository manageRepository) 
        {
            _manageRepository = manageRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
