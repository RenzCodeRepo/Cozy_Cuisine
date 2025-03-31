using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Data.Repositories;
using Cozy_Cuisine.Models;
using Cozy_Cuisine.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> StoryPlotManagement()
        {
            var wikis = await _wikiRepository.GetAllWikisAsync();   
            var SPMVM = new StoryPlotManagementVM
            {
                StoryPlots = await _wikiRepository.GetAllStoryPlotsAsync(),
                NewStoryPlot = null,
                //gets all distinct categories in all of the records after retrieving.
                Wikis = wikis,
                WikiCategories = wikis
                                .Where(w => !string.IsNullOrEmpty(w.Category))
                                .GroupBy(w => w.Category)  // Group by category to ensure uniqueness
                                .Select(g => (WikiId: g.First().WikiId, Category: g.Key)) // Take the first WikiId for each category
                                .ToList()

            };
            return View(SPMVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StoryPlotCreate(StoryPlotManagementVM model)
        {
            if (model.NewStoryPlot != null)
            {

                await _wikiRepository.AddStoryPlotAsync(model.NewStoryPlot);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("StoryPlotManagement");
            };

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("StoryPlotManagement");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStoryPlot(int id)
        {
            var isDeleted = await _wikiRepository.DeleteStoryPlotAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("StoryPlotManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStoryPlot(StoryPlot model)
        {

            var storyPlot = await _wikiRepository.GetStoryPlotByIdAsync(model.StoryId);
            if (storyPlot == null)
            {
                TempData["Error"] = "Story Plot not found.";
                return RedirectToAction("StoryPlotManagement");
            }

            // Update fields
            storyPlot.WikiId = model.WikiId;
            storyPlot.Title = model.Title;
            storyPlot.Description = model.Description;
            storyPlot.Content = model.Content;
            storyPlot.URLImageList = model.URLImageList;

            await _wikiRepository.UpdateStoryPlotAsync(storyPlot);

            TempData["Success"] = "Story Plot updated successfully.";
            return RedirectToAction("StoryPlotManagement");
        }
    }
}
