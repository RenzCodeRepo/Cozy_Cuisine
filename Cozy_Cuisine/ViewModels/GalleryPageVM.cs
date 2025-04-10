using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class GalleryPageVM
    {
        public List<Gallery> Galleries { get; set; } = new List<Gallery>();
        public List<Locations> Locations { get; set; } = new List<Locations>();
        public List<Characters> Characters { get; set; } = new List<Characters>();
    }
}
