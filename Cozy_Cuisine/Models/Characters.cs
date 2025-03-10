

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class Characters
    {
        [Key]
        public int CharacterId { get; set; }
        public int WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual Wiki Wiki { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string URLGif { get; set; }

    }
}
