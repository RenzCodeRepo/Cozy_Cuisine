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
        public string? URLImageList { get; set; }
        public string? URLGif { get; set; }


        public ICollection<StoryPlot> StoryPlot { get; set; } = new HashSet<StoryPlot>();
        public ICollection<GameMechanics> GameMechanics { get; set; } = new HashSet<GameMechanics>();
        public ICollection<Locations> Locations { get; set; } = new HashSet<Locations>();
        public ICollection<GameItems> GameItems { get; set; } = new HashSet<GameItems>();
        public ICollection<Characters> Characters { get; set; } = new HashSet<Characters>();
    }
}
