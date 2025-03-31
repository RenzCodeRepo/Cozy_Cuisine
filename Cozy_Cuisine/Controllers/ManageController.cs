using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Data.IServices;
using Cozy_Cuisine.Data.Repositories;
using Cozy_Cuisine.Data.Services;
using Cozy_Cuisine.Models;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Cozy_Cuisine.Controllers
{
    public class ManageController : Controller
    {
        private readonly IManageRepository _manageRepository;
        private readonly IManageServices _manageServices;


        public ManageController(IManageRepository manageRepository, IManageServices manageServices)
        {
            _manageRepository = manageRepository;
            _manageServices = manageServices;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VisitorCount()
        {
            var visitor = new Visitor
            {
                DateVisited = DateTime.Now
            };

            await _manageRepository.AddVisitorAsync(visitor);
            return Json(new { success = true });
        }

        public async Task<IActionResult> Dashboard()
        {

            var dashboardData = new DashboardVM
            {
                TotalDownloads = (await _manageRepository.GetAllDownloadsAsync()).Count(),
                Ratings = (await _manageRepository.GetAllReviewsAsync())
                            .Select(r => r.Rating)
                            .DefaultIfEmpty(0)
                            .Average(),
                DailyVisits = await _manageRepository.GetDailyVisitorsAsync()
            };

            return View(dashboardData);
        }

        public async Task<IActionResult> Dashboard2()
        {

            var dashboardData = new DashboardVM2
            {
                TotalDownloads = (await _manageRepository.GetAllDownloadsAsync()).Count(),
                Ratings = (await _manageRepository.GetAllReviewsAsync())
                            .Select(r => r.Rating)
                            .DefaultIfEmpty(0)
                            .Average(),
                DailyVisits = await _manageRepository.GetDailyVisitorsAsync()
            };

            return View(dashboardData);
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _manageServices.GetAllComments();

            return Json(new { data = comments });
        }

        [HttpGet]
        public async Task<IActionResult> FAQManagement()
        {
            var FAQVM = new FAQManagementVM
            {
                FAQs = await _manageRepository.GetAllFAQsAsync(),
                NewFAQ = null
            };
            return View(FAQVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateFAQ(FAQManagementVM model)
        {
            if(model.NewFAQ != null)
            {
                await _manageRepository.AddFAQAsync(model.NewFAQ);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("FAQManagement"); 
            };

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("FAQManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFAQ(int id)
        {

            var isDeleted = await _manageRepository.DeleteFAQAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("FAQManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFAQ(FAQ model)
        {
            var faq = await _manageRepository.GetFAQByIdAsync(model.FAQId);
            if (faq != null)
            {
                faq.Question = model.Question;
                faq.Answer = model.Answer;
                faq.FAQURLImageList = model.FAQURLImageList;

                await _manageRepository.UpdateFAQAsync(faq); 
                TempData["Success"] = "FAQ updated successfully.";
                return RedirectToAction("FAQManagement");
            }
            
            TempData["Error"] = "FAQ not found.";
            return RedirectToAction("FAQManagement");

        }


        [HttpGet]
        public async Task<IActionResult> ContactManagement()
        {
            var FAQVM = new FAQManagementVM
            {
                FAQs = await _manageRepository.GetAllFAQsAsync(),
                NewFAQ = null
            };
            return View(FAQVM);
        }

    }
}
