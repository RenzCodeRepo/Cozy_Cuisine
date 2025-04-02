using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string? URLGifOrVideo { get; set; }
        public string? URLImage { get; set; }
    }
}
