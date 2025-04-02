using Cozy_Cuisine.Models;

namespace Cozy_Cuisine.ViewModels
{
    public class MediaManagementVM
    {
        public Gallery NewGallery { get; set; } = new Gallery();
        public List<Gallery> Galleries { get; set; } = new List<Gallery>();
    }
}
