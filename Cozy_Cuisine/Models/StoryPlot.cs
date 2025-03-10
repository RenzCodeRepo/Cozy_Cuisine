using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class StoryPlot
    {
        [Key]
        public int StoryId { get; set; }

        // The Relationship is One to Many using Navigation Property
        // on Child and Parent Class.
        public int WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual Wiki Wiki { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<string> URLImageList { get; set; }

    }
}
