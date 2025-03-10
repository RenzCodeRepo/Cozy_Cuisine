using System.ComponentModel.DataAnnotations;

namespace Cozy_Cuisine.Models
{
    public class Wiki
    {
        [Key]
        public int WikiId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> URLImageList { get; set; }
        public List<string> URLGif { get; set; }


        public ICollection<StoryPlot> StoryPlot { get; set; }
        public ICollection<GameMechanics> GameMechanics { get; set; }
        public ICollection<Locations> Locations { get; set; }
        public ICollection<GameItems> GameItems { get; set; }
        public ICollection<Characters> Characters { get; set; }
    }
}
