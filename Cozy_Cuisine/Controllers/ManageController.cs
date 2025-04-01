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
                TotalDownloads = (await _manageRepository.GetAllDownloadsAsync()).Count,
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
                TotalDownloads = (await _manageRepository.GetAllDownloadsAsync()).Count,
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
        public async Task<IActionResult> CreditsManagement()
        {
            var CVM = new CreditsManagementVM
            {
               Credits = await _manageRepository.GetAllCreditsAsync(),
               NewCredits = null
            };
            return View(CVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCredits(CreditsManagementVM model)
        {
            if (model.NewCredits != null)
            {
                await _manageRepository.AddCreditAsync(model.NewCredits);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("CreditsManagement");
            };

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("CreditsManagement");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCredits(Credit model)
        {
            var (isSuccess, credit) = await _manageRepository.GetCreditByIdAsync(model.CreditId);
            if (isSuccess)
            {
                credit.Name = model.Name;
                credit.Role = model.Role;
                credit.URLGif = model.URLGif;

                await _manageRepository.UpdateCreditAsync(credit);
                TempData["Success"] = "Credit updated successfully.";
                return RedirectToAction("CreditsManagement");
            }

            TempData["Error"] = "Credit Record not found.";
            return RedirectToAction("CreditsManagement");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCredit(int id)
        {

            var isDeleted = await _manageRepository.DeleteCreditAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("CreditsManagement");
        }


        [HttpGet]
        public async Task<IActionResult> NewsManagement()
        {
            var NVM = new NewsManagementVM
            {
                Notices = await _manageRepository.GetAllNoticesAsync(),
                NewNotice = null
            };
            return View(NVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNotice(NewsManagementVM model)
        {
            if (model.NewNotice != null)
            {
                await _manageRepository.AddNoticeAsync(model.NewNotice);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("NewsManagement");
            };

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("NewsManagement");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNotice(Notice model)
        {
            var (isSuccess, notice) = await _manageRepository.GetNoticeByIdAsync(model.NoticeId);
            if (isSuccess)
            {
                notice.Headline  = model.Headline;
                notice.Category = model.Category;
                notice.Content = model.Content;
                notice.URLNewsImageList = model.URLNewsImageList;
                notice.URLVideo = model.URLVideo;

                await _manageRepository.UpdateNoticeAsync(notice);
                TempData["Success"] = "News updated successfully.";
                return RedirectToAction("NewsManagement");
            }

            TempData["Error"] = "News record not found.";
            return RedirectToAction("NewsManagement");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNotice(int id)
        {

            var isDeleted = await _manageRepository.DeleteCreditAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("CreditsManagement");
        }

    }
}
