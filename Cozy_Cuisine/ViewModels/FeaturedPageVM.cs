using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class FeaturedPageVM
    {
        public List<Notice> Features { get; set; } = new List<Notice>();
        public Notice Feature { get; set; } = new Notice();
    }
}
