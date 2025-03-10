using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozy_Cuisine.Models
{
    public class GameMechanics
    {
        [Key]
        public int GameMechId { get; set; }
        public int WikiId { get; set; }
        [ForeignKey("WikiId")]
        public virtual Wiki Wiki { get; set; }

        public string GMName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public List<string> URLImageList { get; set; }
    }
}
