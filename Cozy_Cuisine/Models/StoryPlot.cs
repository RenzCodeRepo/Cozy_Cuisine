using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class StoryPlot
    {
        [Key]
        public int StoryId { get; set; }
        public int? WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual Wiki? Wiki { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string URLImageList { get; set; }

    }
}
