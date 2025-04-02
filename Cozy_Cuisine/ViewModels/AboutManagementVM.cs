using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class AboutManagementVM
    {
        public About? NewAbout { get; set; } = new About();
        public List<About> Abouts { get; set; } = new List<About>();
    }
}
