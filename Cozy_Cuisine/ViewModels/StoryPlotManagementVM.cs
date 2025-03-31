using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class StoryPlotManagementVM
    {
        public StoryPlot? NewStoryPlot { get; set; } = new StoryPlot();
        public List<StoryPlot>? StoryPlots { get; set; } = new List<StoryPlot>(); 
        public List<Wiki>? Wikis { get; set; } = new List<Wiki>();


        // Dictionary to store WikiId and Category
        public List<(int WikiId, string Category)> WikiCategories { get; set; } = new List<(int, string)>();
    }
}
