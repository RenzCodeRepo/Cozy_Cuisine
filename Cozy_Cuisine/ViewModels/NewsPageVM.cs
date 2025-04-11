using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class NewsPageVM
    {
        public List<Patches> Patches { get; set; } = new List<Patches>();
        public List<Notice> FourLatestNews { get; set; } = new List<Notice>();
        public List<Notice> FeaturedNews { get; set; } = new List<Notice>();
        public Notice? LatestUpdate { get; set; } = new Notice();
    }
}
