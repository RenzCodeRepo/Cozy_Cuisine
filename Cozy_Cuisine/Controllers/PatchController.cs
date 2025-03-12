using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Models;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Cozy_Cuisine.Controllers
{
    public class PatchController : Controller
    {
        private readonly IPatchRepository _patchRepository;

        public PatchController(IPatchRepository patchRepository)
        {
            _patchRepository = patchRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllPatches()
        {
            var patches = await _patchRepository.GetAllPatchesAsync();
            return View(patches);
        }

        [HttpGet]
        public async Task<IActionResult> ViewPatch(int id)
        {
            var patch = await _patchRepository.GetPatchByIdAsync(id);
            if (patch == null) return NotFound();
            return View(patch);
        }


        public IActionResult CreatePatch()
        {
            return View();
        }


        [HttpPost]      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePatch(Patches patch)
        {
            if (ModelState.IsValid)
            {
                await _patchRepository.AddPatchAsync(patch);
                return RedirectToAction(nameof(Index));
            }
            return View(patch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePatch(int id, Patches patch)
        {
            if (id != patch.PatchId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _patchRepository.UpdatePatchAsync(patch);
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Invalid, Something went wrong.";
            return View(patch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePatch(int id)
        {
            await _patchRepository.DeletePatchAsync(id);
            return RedirectToAction(nameof(AllPatches));
        }

        //
        //Bug Related Actions
        //

        [HttpGet]
        public async Task<IActionResult> BugsList()
        {
            var bugList = await _patchRepository.GetAllBugReports();
            return View(bugList);   
        }

        [HttpGet]
        public async Task<IActionResult> ReportBug(int patchId)
        {
            var patch = await _patchRepository.GetPatchByIdAsync(patchId);
            if (patch == null) return NotFound();

            var model = new PatchBaseVM
            {
                Patches = patch
            };
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportBug(int patchId, BugReport bugReport)
        {
            if (ModelState.IsValid)
            {
                bugReport.PatchId = patchId;
                await _patchRepository.AddBugReportAsync(bugReport);
                TempData["Success"] = "Bug Reported Successfully!";
                return RedirectToAction(nameof(ReportBug), new { patchId });
            }
            TempData["Error"] = "Invalid, Something went wrong.";
            return View(bugReport);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBug(int id)
        {
            var bugReport = await _patchRepository.GetBugReportByIdAsync(id);
            if (bugReport == null)
            { 
                TempData["Error"] = "Bug Report not Found."; 
                return NotFound(); 
            }
            return View(bugReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBug(BugReport bugReport)
        {
            if (ModelState.IsValid)
            {
                await _patchRepository.UpdateBugReportAsync(bugReport);
                TempData["Error"] = "Bug Report Changes Saved Successfully!";
                return RedirectToAction(nameof(BugReport));
            }
            TempData["Error"] = "Invalid, Something went wrong.";
            return View(bugReport);
        }
    }
}
