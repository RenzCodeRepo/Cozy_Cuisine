using System.Diagnostics;
using System.Threading.Tasks;
using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Data.IServices;
using Cozy_Cuisine.Models;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace Cozy_Cuisine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManageRepository _manageRepository;
        private readonly IPatchRepository _patchRepository;
        private readonly IWikiRepository _wikiRepository;
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, 
            IManageRepository manageRepository, 
            IPatchRepository patchRepository, 
            IEmailService emailService,
            IWikiRepository wikiRepository)
        {
            _logger = logger;
            _manageRepository = manageRepository;
            _patchRepository = patchRepository;
            _emailService = emailService;
            _wikiRepository = wikiRepository;
        }
       
        public async Task<IActionResult> Index()
        {
            var IPVM = new IndexPageVM
            {
                Patches = await _patchRepository.GetLatestPatch(),
                GameItems = await _wikiRepository.GetAllGameItemsAsync()
            };
            return View(IPVM);
        }
        public async Task<IActionResult> About()
        {

            var APVM = new AboutPageVM
            {
                LatestAbout = await _manageRepository.GetLatestAbout(),
                GameMechanics = await _wikiRepository.GetAllGameMechanicsAsync()
            };
            return View(APVM);
        }

        public async Task<IActionResult> Gallery()
        {
            var GPVM = new GalleryPageVM
            {
                Galleries = await _manageRepository.GetAllGalleryAsync(),
                Locations = await _wikiRepository.GetAllLocationsAsync(),
                Characters = await _wikiRepository.GetAllCharactersAsync()
            };
                return View(GPVM);
        }
        public async Task<IActionResult> News()
        {
            var NPVM = new NewsPageVM
            {
                Patches = await _patchRepository.GetAllPatchesAsync(),
                FourLatestNews = await _manageRepository.GetLatestFourNews(),
                LatestUpdate = await _manageRepository.GetLatestUpdate(),
                FeaturedNews = await _manageRepository.GetFeaturedNews()
            };
            return View(NPVM);
        }
        public async Task<IActionResult> Credits()
        {
            var peeps = await _manageRepository.GetAllCreditsAsync();
            return View(peeps);
        }
        public IActionResult Wiki()
        {
            return View();
        }
        public async Task<IActionResult> Download()
        {
            var DPVM = new DownloadPageVM
            {
                Patches = await _patchRepository.LatestFourPatches(),
                LatestPatch = await _patchRepository.GetLatestPatch(),
                GameReview = null
            };
            return View(DPVM);
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
                PatchesDict = await _patchRepository.GetPatchDictionaryAsync(),
                NewBugReport = null,
                NewContacts = null
            };

            return View(CVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendMessage(ContactsVM model)
        {
           
            if (model.NewContacts == null)
            {
                TempData["Error"] = "Something went wrong. Please try again.";
                return RedirectToAction("Contacts");
            }

            try
            {
                string recipientEmail = "unlibugs938@gmail.com"; // Your email
                string subject = model.NewContacts.EmailSubject;
                string body = model.NewContacts.EmailBody;

                // Append "Reply email:" only if provided
                if (!string.IsNullOrWhiteSpace(model.NewContacts.EmailAddress))
                {
                    body += $"\n\nReply email: {model.NewContacts.EmailAddress}";
                }
                await Task.Delay(2000);
                // Send email
                await _emailService.SendEmailAsync(recipientEmail, subject, body);

                // Store message in the database
                await _manageRepository.CreateContactAsync(model.NewContacts);

                TempData["Success"] = "Your message was submitted successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to send message. Please try again.";
            }

            return RedirectToAction("Contacts");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendBugReport(ContactsVM model)
        {

            if (model.NewBugReport == null)
            {
                TempData["Error"] = "Something went wrong. Please try again.";
                return RedirectToAction("Contacts");
            }

            try
            {
                string recipientEmail = "unlibugs938@gmail.com"; // Your email
                string subject = model.NewBugReport.BugTitle;
                string body = model.NewBugReport.BugDescription;
                await Task.Delay(2000); 
                // Send email
                await _emailService.SendEmailAsync(recipientEmail, subject, body);

                // Store message in the database
                await _patchRepository.AddBugReportAsync(model.NewBugReport);

                TempData["Success"] = "Bug Report was submitted successfully. Thank you for helping us improve our game!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Failed to send Bug Report. Please try again.";
            }

            return RedirectToAction("Contacts");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitReview(GameReview model)
        {
            if (model != null)
            {
                await _manageRepository.AddReviewAsync(model);
                TempData["Success"] = "Review Submitted. Thank you for sending us a Review.";
                return RedirectToAction("Download");
            }
            TempData["Error"] = "Review not Submitted. Something went wrong.";
            return RedirectToAction("Download");
        }

        [HttpGet]
        public async Task<IActionResult> Article(int NoticeId)
        {
            var (isSuccess, notice) = await _manageRepository.GetNoticeByIdAsync(NoticeId);

            if (!isSuccess || notice == null)
            {
                TempData["Error"] = "Article Not Found, something went wrong.";
                return RedirectToAction("News", "Home");
            }

            var APVM = new ArticlePageVM
            {
                Article = notice,
                Articles = await _manageRepository.GetNews()
            };

            return View(APVM);
        }
    }

}

