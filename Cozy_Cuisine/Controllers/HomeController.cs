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
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, IManageRepository manageRepository, IPatchRepository patchRepository, IEmailService emailService)
        {
            _logger = logger;
            _manageRepository = manageRepository;
            _patchRepository = patchRepository;
            _emailService = emailService;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Credits()
        {
            return View();
        }
        public IActionResult Wiki()
        {
            return View();
        }
        public IActionResult Download()
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
    }

}

