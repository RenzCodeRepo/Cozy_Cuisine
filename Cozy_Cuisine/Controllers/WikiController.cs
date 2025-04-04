using AspNetCoreGeneratedDocument;
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
        public async Task<IActionResult> WikiManagement()
        {
            var WMVM = new WikiMangementVM
            {
                Wikis = await _wikiRepository.GetAllWikisAsync(),
                NewWiki = null
            };
            return View(WMVM);
        }


     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> WikiCreate(WikiMangementVM model)
        {
            if (model.NewWiki != null)
            {
                await _wikiRepository.AddWikiAsync(model.NewWiki);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("WikiManagement");
            };

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("WikiManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWiki(int id)
        {
            var isDeleted = await _wikiRepository.DeleteWikiAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("WikiManagement");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWiki(Wiki model)
        {

            var wiki = await _wikiRepository.GetWikiByIdAsync(model.WikiId);
            if (wiki == null)
            {
                TempData["Error"] = "Wiki record not found.";
                return RedirectToAction("WikiManagement");
            }

            // Update fields
            wiki.WikiId = model.WikiId;
            wiki.Title = model.Title;
            wiki.Description = model.Description;
            wiki.URLGif = model.URLGif;
            wiki.URLImageList = model.URLImageList;

            await _wikiRepository.UpdateWikiAsync(wiki);

            TempData["Success"] = "Wiki updated successfully.";
            return RedirectToAction("WikiManagement");
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
        public async Task<ActionResult> CreateStoryPlot(StoryPlotManagementVM model)
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

        [HttpGet]
        public async Task<IActionResult> CharacterManagement()
        {
            
            var CMVM = new CharacterManagementVM
            {
               Characters = await _wikiRepository.GetAllCharactersAsync(),
               NewCharacter = null
            };
            return View(CMVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCharacter(CharacterManagementVM model)
        {
            if (model.NewCharacter != null)
            {

                await _wikiRepository.AddCharacterAsync(model.NewCharacter);
                TempData["Success"] = "Data was submitted successfully.";
                return RedirectToAction("CharacterManagement");
            }
            ;

            TempData["Error"] = "Something has gone wrong and data was not added.";
            return RedirectToAction("CharacterManagement");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var isDeleted = await _wikiRepository.DeleteCharacterAsync(id);

            if (!isDeleted)
            {
                TempData["Error"] = "Record does not exist.";
            }
            else
            {
                TempData["Success"] = "Record deleted successfully.";
            }

            return RedirectToAction("CharacterManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCharacter(Characters model)
        {

            var character = await _wikiRepository.GetCharacterByIdAsync(model.CharacterId);
            if (character == null)
            {
                TempData["Error"] = "Character not found.";
                return RedirectToAction("CharacterManagement");
            }

            // Update fields
            character.WikiId = model.WikiId;
            character.Name = model.Name;
            character.Description = model.Description;
            character.Category = model.Category;
            character.URLGif = model.URLGif;

            await _wikiRepository.UpdateCharacterAsync(character);

            TempData["Success"] = "Character updated successfully.";
            return RedirectToAction("CharacterManagement");
        }

    }
}
