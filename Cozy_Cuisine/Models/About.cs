using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class About
    {
        [Key]
        public int DetailsId { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }

        public string? URLGif { get; set; }

    }
}
